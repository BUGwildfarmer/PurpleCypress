#ifndef _EasyTcpServer_hpp_
#define _EasyTcpServer_hpp_

#define _WINSOCK_DEPRECATED_NO_WARNINGS
#ifdef _WIN32
#define WIN32_LEAN_AND_MEAN
#include<windows.h>
#include<WinSock2.h>
#pragma comment(lib,"ws2_32.lib")   // 指定动态链接库
#else
#include<unistd.h>  //  unix std
#include<arpa/inet.h>
#include<string.h>

#define SOCKET int  // Linux下没有包装SOCKET,需要从windows查看重新进行宏定义
#define INVALID_SOCKET  (SOCKET)(~0)
#define SOCKET_ERROR            (-1)
#endif

#include<cstdio>
#include<vector>
#include"MesaageHeader.hpp"

using namespace std;


class EasyTcpServer
{
	SOCKET _sock;
	vector<SOCKET> g_clients;
public:

	EasyTcpServer()
	{
		_sock = INVALID_SOCKET;
		g_clients.clear();
	}

	virtual ~EasyTcpServer()
	{
		Close();
	}

	// 初始化socket
	SOCKET InitSocket()
	{
		// 启动 WinSock 2.x环境
#ifdef _WIN32
		WORD ver = MAKEWORD(2, 2);  // 版本号
		WSADATA dat;  // 接收winsows socket实现细节的结构体
		WSAStartup(ver, &dat);  // 绑定socket库,初始化链接库
#endif
		if (_sock != INVALID_SOCKET)
		{
			printf("<socket = %d>关闭旧连接\n", _sock);
			Close();
		}
		_sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);  // 同服务端不同，这里不用指明TCP协议
		if (INVALID_SOCKET == _sock)
		{
			printf("服务器创建socket失败\n");
		}
		else
		{
			printf("服务器创建socket成功\n");
		}
		return _sock;
	}

	// 绑定ip地址和端口
	int Bind(const char* ip, unsigned short port)
	{
		sockaddr_in _sin = {};  // 不直接用sockaddr类型是因为sockaddr_in类型更适合填写
		_sin.sin_family = AF_INET;
		_sin.sin_port = htons(port);  // host to net unsigned short主机类型和网络类型的short类型不同
		//_sin.sin_addr.S_un.S_addr = INADDR_ANY;  // inet_addr("127.0.0.1"),任意ip地址
#ifdef _WIN32
		if (ip)
		{
			_sin.sin_addr.S_un.S_addr = inet_addr(ip);  // 这里替换相应的ip地址
		}
		else
		{
			_sin.sin_addr.S_un.S_addr = INADDR_ANY;
		}
#else
		if (ip)
		{
			_sin.sin_addr.s_addr = inet_addr(ip);
		}
		else
		{
			_sin.sin_addr.s_addr = INADDR_ANY;
		}
#endif
		int ret = bind(_sock, (sockaddr*)&_sin, sizeof(_sin));
		if (ret == SOCKET_ERROR)
		{
			printf("服务器绑定端口<%d>失败\n",port);
		}
		else
		{
			printf("服务器绑定端口<%d>成功\n",port);
		}
		return ret;
	}

	// 监听端口
	int Listen(int n)
	{
		int ret = listen(_sock, n);
		if (SOCKET_ERROR == ret)  // 最多需要等待多少人进行连接
		{
			printf("<socket = %d>服务器监听失败\n",_sock);
		}
		else
		{
			printf("<socket = %d>服务器监听成功\n",_sock);
		}
		return ret;
	}

	// 接受客户端连接
	SOCKET Accept()
	{
		sockaddr_in clientAddr = {};
		int nAddrlen = sizeof(clientAddr);
		SOCKET cSock = INVALID_SOCKET;
		cSock = accept(_sock, (sockaddr*)&clientAddr, &nAddrlen);
		if (INVALID_SOCKET == cSock)
		{
			printf("服务器<socket = %d>接受到无效客户端...\n",_sock);
		}
		else
		{
			printf("服务器<socket = %d>收到新客户端:",_sock);
			printf("客户端IP = %s,socket = %d\n", inet_ntoa(clientAddr.sin_addr), (int)cSock);
			/*for (int n = g_clients.size() - 1; n >= 0; n--)
			{
				NewUserJoin userjoin;
				userjoin.nsock = (int)cSock;
				SendData(&userjoin, g_clients[n]);
			}*/
			NewUserJoin userjoin;
			userjoin.nsock = (int)cSock;
			SendDataToAll(&userjoin);
			g_clients.push_back(cSock);
		}
		return cSock;
	}

	// 单发消息
	int SendData(DataHeader *header,SOCKET cSock)
	{
		if (isRun() && header)
		{
			return send(cSock, (const char*)header, header->dataLength, 0);
		}
		return SOCKET_ERROR;
	}

	// 群发消息
	void SendDataToAll(DataHeader* header)
	{
		if (isRun() && header)
		{
			for (int n = g_clients.size() - 1; n >= 0; n--)
			{
				SendData(header, g_clients[n]);
			}
		}
	}

	// 响应消息
	virtual void OnNetMsg(DataHeader *header,SOCKET cSock)
	{
		switch (header->cmd)
		{
		case CMD_LOGIN:
		{
			Login* login = (Login*)header;
			printf("收到客户端%d命令：%d,数据长度：%d , username = %s userpsw = %s\n", (int)cSock, login->cmd, login->dataLength, login->userName, login->password);

			// 数据库查看密码是否正确
			LoginResult ret;
			SendData(&ret, cSock);
		}
		break;

		case CMD_LOGOUT:
		{
			LogOut* logout = (LogOut*)header;
			printf("收到客户端%d命令：%d,数据长度：%d , username = %s\n", (int)cSock,logout->cmd, logout->dataLength, logout->userName);

			// 数据库查看密码是否正确
			LogOutResult ret;
			SendData(&ret, cSock);
		}
		break;

		default:
			DataHeader header = { 0,CMD_ERROR };
			SendData(&header, cSock);
			break;
		}
	}

	// 接受消息
	int Recv(SOCKET cSock)
	{
		// 缓冲区
		char szRecv[1024] = {};
		int nlen = recv(cSock, szRecv, sizeof(DataHeader), 0);
		DataHeader* header = (DataHeader*)szRecv;
		if (nlen <= 0)
		{
			printf("客户端%d退出\n", (int)cSock);
			return -1;
		}
		recv(cSock, szRecv + sizeof(DataHeader), header->dataLength - sizeof(DataHeader), 0);
		OnNetMsg(header, cSock);
		return 0;
	}

	// 查询网络消息
	bool OnRun()
	{
		if (isRun())
		{
			// 伯克利套接字 BSD socket描述符
			fd_set fdRead;  // 描述符集合
			fd_set fdWrite;
			fd_set fdExp;

			FD_ZERO(&fdRead);
			FD_ZERO(&fdWrite);
			FD_ZERO(&fdExp);

			FD_SET(_sock, &fdRead);
			FD_SET(_sock, &fdWrite);
			FD_SET(_sock, &fdExp);

			for (int n = g_clients.size() - 1; n >= 0; n--)
			{
				FD_SET(g_clients[n], &fdRead);
			}

			timeval t = { 1,0 };
			// nfds是一个整数值，指一个fd_set集合所有描述符(socket)的范围而非数量（所有描述符最大值+1）
			// 当 time == NULL时，则select会阻塞查询直到有数据可以操作,否则超时立即返回
			int ret = select(_sock + 1, &fdRead, &fdWrite, &fdExp, &t);
			if (ret < 0)
			{
				printf("服务端<socket = %d>select任务失败\n",_sock);
				Close();
				return false;
			}
			if (FD_ISSET(_sock, &fdRead))
			{
				FD_CLR(_sock, &fdRead);
				Accept();
			}
			for (int n = 0; n < fdRead.fd_count; n++)
			{
				if (-1 == Recv(fdRead.fd_array[n]))
				{
					auto iter = find(g_clients.begin(), g_clients.end(), fdRead.fd_array[n]);  // std::vector<SOCKET>::iterator
					if (iter != g_clients.end())
					{
						g_clients.erase(iter);
					}
				}
			}
			return true;
		}
		return false;
	}

	// 是否工作中
	bool isRun()
	{
		return _sock != INVALID_SOCKET;
	}

	// 关闭socket
	void Close()
	{
		if (_sock != INVALID_SOCKET)
		{
#ifdef _WIN32
			closesocket(_sock);
			for (int n = g_clients.size() - 1; n >= 0; n--)
			{
				closesocket(g_clients[n]);
			}
			WSACleanup();
#else
			close(_sock);
			for (int n = g_clients.size() - 1; n >= 0; n--)
			{
				close(g_clients[n]);
			}
#endif
			_sock = INVALID_SOCKET;
		}
		
	}

};



#endif