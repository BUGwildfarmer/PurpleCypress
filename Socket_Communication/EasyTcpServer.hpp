#ifndef _EasyTcpServer_hpp_
#define _EasyTcpServer_hpp_

#define _WINSOCK_DEPRECATED_NO_WARNINGS
#ifdef _WIN32
#define WIN32_LEAN_AND_MEAN
#include<windows.h>
#include<WinSock2.h>
#pragma comment(lib,"ws2_32.lib")   // ָ����̬���ӿ�
#else
#include<unistd.h>  //  unix std
#include<arpa/inet.h>
#include<string.h>

#define SOCKET int  // Linux��û�а�װSOCKET,��Ҫ��windows�鿴���½��к궨��
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

	// ��ʼ��socket
	SOCKET InitSocket()
	{
		// ���� WinSock 2.x����
#ifdef _WIN32
		WORD ver = MAKEWORD(2, 2);  // �汾��
		WSADATA dat;  // ����winsows socketʵ��ϸ�ڵĽṹ��
		WSAStartup(ver, &dat);  // ��socket��,��ʼ�����ӿ�
#endif
		if (_sock != INVALID_SOCKET)
		{
			printf("<socket = %d>�رվ�����\n", _sock);
			Close();
		}
		_sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);  // ͬ����˲�ͬ�����ﲻ��ָ��TCPЭ��
		if (INVALID_SOCKET == _sock)
		{
			printf("����������socketʧ��\n");
		}
		else
		{
			printf("����������socket�ɹ�\n");
		}
		return _sock;
	}

	// ��ip��ַ�Ͷ˿�
	int Bind(const char* ip, unsigned short port)
	{
		sockaddr_in _sin = {};  // ��ֱ����sockaddr��������Ϊsockaddr_in���͸��ʺ���д
		_sin.sin_family = AF_INET;
		_sin.sin_port = htons(port);  // host to net unsigned short�������ͺ��������͵�short���Ͳ�ͬ
		//_sin.sin_addr.S_un.S_addr = INADDR_ANY;  // inet_addr("127.0.0.1"),����ip��ַ
#ifdef _WIN32
		if (ip)
		{
			_sin.sin_addr.S_un.S_addr = inet_addr(ip);  // �����滻��Ӧ��ip��ַ
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
			printf("�������󶨶˿�<%d>ʧ��\n",port);
		}
		else
		{
			printf("�������󶨶˿�<%d>�ɹ�\n",port);
		}
		return ret;
	}

	// �����˿�
	int Listen(int n)
	{
		int ret = listen(_sock, n);
		if (SOCKET_ERROR == ret)  // �����Ҫ�ȴ������˽�������
		{
			printf("<socket = %d>����������ʧ��\n",_sock);
		}
		else
		{
			printf("<socket = %d>�����������ɹ�\n",_sock);
		}
		return ret;
	}

	// ���ܿͻ�������
	SOCKET Accept()
	{
		sockaddr_in clientAddr = {};
		int nAddrlen = sizeof(clientAddr);
		SOCKET cSock = INVALID_SOCKET;
		cSock = accept(_sock, (sockaddr*)&clientAddr, &nAddrlen);
		if (INVALID_SOCKET == cSock)
		{
			printf("������<socket = %d>���ܵ���Ч�ͻ���...\n",_sock);
		}
		else
		{
			printf("������<socket = %d>�յ��¿ͻ���:",_sock);
			printf("�ͻ���IP = %s,socket = %d\n", inet_ntoa(clientAddr.sin_addr), (int)cSock);
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

	// ������Ϣ
	int SendData(DataHeader *header,SOCKET cSock)
	{
		if (isRun() && header)
		{
			return send(cSock, (const char*)header, header->dataLength, 0);
		}
		return SOCKET_ERROR;
	}

	// Ⱥ����Ϣ
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

	// ��Ӧ��Ϣ
	virtual void OnNetMsg(DataHeader *header,SOCKET cSock)
	{
		switch (header->cmd)
		{
		case CMD_LOGIN:
		{
			Login* login = (Login*)header;
			printf("�յ��ͻ���%d���%d,���ݳ��ȣ�%d , username = %s userpsw = %s\n", (int)cSock, login->cmd, login->dataLength, login->userName, login->password);

			// ���ݿ�鿴�����Ƿ���ȷ
			LoginResult ret;
			SendData(&ret, cSock);
		}
		break;

		case CMD_LOGOUT:
		{
			LogOut* logout = (LogOut*)header;
			printf("�յ��ͻ���%d���%d,���ݳ��ȣ�%d , username = %s\n", (int)cSock,logout->cmd, logout->dataLength, logout->userName);

			// ���ݿ�鿴�����Ƿ���ȷ
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

	// ������Ϣ
	int Recv(SOCKET cSock)
	{
		// ������
		char szRecv[1024] = {};
		int nlen = recv(cSock, szRecv, sizeof(DataHeader), 0);
		DataHeader* header = (DataHeader*)szRecv;
		if (nlen <= 0)
		{
			printf("�ͻ���%d�˳�\n", (int)cSock);
			return -1;
		}
		recv(cSock, szRecv + sizeof(DataHeader), header->dataLength - sizeof(DataHeader), 0);
		OnNetMsg(header, cSock);
		return 0;
	}

	// ��ѯ������Ϣ
	bool OnRun()
	{
		if (isRun())
		{
			// �������׽��� BSD socket������
			fd_set fdRead;  // ����������
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
			// nfds��һ������ֵ��ָһ��fd_set��������������(socket)�ķ�Χ�����������������������ֵ+1��
			// �� time == NULLʱ����select��������ѯֱ�������ݿ��Բ���,����ʱ��������
			int ret = select(_sock + 1, &fdRead, &fdWrite, &fdExp, &t);
			if (ret < 0)
			{
				printf("�����<socket = %d>select����ʧ��\n",_sock);
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

	// �Ƿ�����
	bool isRun()
	{
		return _sock != INVALID_SOCKET;
	}

	// �ر�socket
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