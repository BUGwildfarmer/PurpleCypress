#ifndef _EasyTcpClient_hpp_
#define _EasyTcpClient_hpp_

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
#include"MessageHeader.hpp"



class EasyTcpClient
{
	SOCKET _sock;

public:
	EasyTcpClient()
	{
		_sock = INVALID_SOCKET;
	}

	// 虚析构函数
	virtual ~EasyTcpClient()
	{
		Close();
	}

	// 初始化socket
	void InitSocket()
	{
		// 启动 WinSock 2.x环境
#ifdef _WIN32
		WORD ver = MAKEWORD(2, 2);  // 版本号
		WSADATA dat;  // 接收winsows socket实现细节的结构体
		WSAStartup(ver, &dat);  // 绑定socket库,初始化链接库
#endif
		// 1.建立一个socket
		if (_sock != INVALID_SOCKET)
		{
			printf("<socket = %d>关闭旧连接\n",_sock);
			Close();
		}
		_sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);  // 同服务端不同，这里不用指明TCP协议
		if (INVALID_SOCKET == _sock)
		{
			printf("创建socket失败\n");
		}
		else
		{
			printf("创建socket成功\n");
		}
	}

	// 连接服务器
	int Connect(const char* ip, unsigned short port)
	{
		if (INVALID_SOCKET == _sock)
		{
			InitSocket();
		}
		sockaddr_in _sin = {};
		_sin.sin_family = AF_INET;
		_sin.sin_port = htons(port);
#ifdef _WIN32
		_sin.sin_addr.S_un.S_addr = inet_addr(ip);  // 这里替换相应的ip地址
#else
		_sin.sin_addr.s_addr = inet_addr(ip);
#endif
		int ret = connect(_sock, (sockaddr*)&_sin, sizeof(sockaddr_in));
		if (SOCKET_ERROR == ret)
		{
			printf("连接服务器失败\n");
		}
		else
		{
			printf("连接服务器成功\n");
		}
		return ret;
	}

	// 关闭socket
	void Close()
	{
		if (_sock != INVALID_SOCKET)
		{
#ifdef _WIN32
			closesocket(_sock);
			WSACleanup();
#else
			close(_sock);
#endif
			_sock = INVALID_SOCKET;
		}
	}

	// 发送数据
	int SendData(DataHeader *header)
	{
		if (isRun() && header)
		{
			return send(_sock, (const char*)header, header->dataLength, 0);
		}	
		return SOCKET_ERROR;
	}

	// 接收数据 处理粘包 拆包
	int Recv()
	{
		// 缓冲区
		char szRecv[1024] = {};
		int nlen = recv(_sock, szRecv, sizeof(DataHeader), 0);
		DataHeader* header = (DataHeader*)szRecv;
		if (nlen <= 0)
		{
			printf("服务器关闭\n");
			return -1;
		}
		recv(_sock, szRecv + sizeof(DataHeader), header->dataLength - sizeof(DataHeader), 0);
		OnNetMsg(header);
		return 0;
	}

	// 响应网络消息
	virtual void OnNetMsg(DataHeader* header)
	{
		switch (header->cmd)
		{
		case CMD_LOGIN_RESULT:
		{
			LoginResult* loginret = (LoginResult*)header;
			printf("收到服务器命令：%d,数据长度：%d , 应答： %d\n", loginret->cmd, loginret->dataLength, loginret->result);
		}
		break;

		case CMD_LOGOUT_RESULT:
		{
			LogOutResult* logoutret = (LogOutResult*)header;
			printf("收到服务器命令：%d,数据长度：%d , 应答： %d\n", logoutret->cmd, logoutret->dataLength, logoutret->result);
		}
		break;

		case CMD_NEW_USER_JOIN:
		{
			NewUserJoin* userjoin = (NewUserJoin*)header;
			printf("收到服务器命令：%d,数据长度：%d , 应答： 客户端%d已加入\n", userjoin->cmd, userjoin->dataLength, userjoin->nsock);
		}
		break;

		default:
			DataHeader header = { 0,CMD_ERROR };
			send(_sock, (const char*)&header, sizeof(header), 0);
			break;
		}
	}

	//查询网络消息
	bool OnRun()
	{
		if (isRun())
		{
			fd_set fdRead;
			FD_ZERO(&fdRead);
			FD_SET(_sock, &fdRead);
			timeval t = { 1,0 };
			int ret = select(_sock + 1, &fdRead, 0, 0, &t);
			if (ret == -1)
			{
				printf("<socket = %d>select失败\n", _sock);
				return false;
			}
			if (FD_ISSET(_sock, &fdRead))
			{
				FD_CLR(_sock, &fdRead);
				if (-1 == Recv())
				{
					printf("<socket = %d>任务结束\n", _sock);
					return false;
				}
			}
			return true;
			//printf("空闲时间处理其他业务\n");
		}
		return false;
	}

	// 是否工作中
	bool isRun()
	{
		return _sock != INVALID_SOCKET;
	}

};

#endif