#ifndef _EasyTcpClient_hpp_
#define _EasyTcpClient_hpp_

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
#include"MessageHeader.hpp"



class EasyTcpClient
{
	SOCKET _sock;

public:
	EasyTcpClient()
	{
		_sock = INVALID_SOCKET;
	}

	// ����������
	virtual ~EasyTcpClient()
	{
		Close();
	}

	// ��ʼ��socket
	void InitSocket()
	{
		// ���� WinSock 2.x����
#ifdef _WIN32
		WORD ver = MAKEWORD(2, 2);  // �汾��
		WSADATA dat;  // ����winsows socketʵ��ϸ�ڵĽṹ��
		WSAStartup(ver, &dat);  // ��socket��,��ʼ�����ӿ�
#endif
		// 1.����һ��socket
		if (_sock != INVALID_SOCKET)
		{
			printf("<socket = %d>�رվ�����\n",_sock);
			Close();
		}
		_sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);  // ͬ����˲�ͬ�����ﲻ��ָ��TCPЭ��
		if (INVALID_SOCKET == _sock)
		{
			printf("����socketʧ��\n");
		}
		else
		{
			printf("����socket�ɹ�\n");
		}
	}

	// ���ӷ�����
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
		_sin.sin_addr.S_un.S_addr = inet_addr(ip);  // �����滻��Ӧ��ip��ַ
#else
		_sin.sin_addr.s_addr = inet_addr(ip);
#endif
		int ret = connect(_sock, (sockaddr*)&_sin, sizeof(sockaddr_in));
		if (SOCKET_ERROR == ret)
		{
			printf("���ӷ�����ʧ��\n");
		}
		else
		{
			printf("���ӷ������ɹ�\n");
		}
		return ret;
	}

	// �ر�socket
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

	// ��������
	int SendData(DataHeader *header)
	{
		if (isRun() && header)
		{
			return send(_sock, (const char*)header, header->dataLength, 0);
		}	
		return SOCKET_ERROR;
	}

	// �������� ����ճ�� ���
	int Recv()
	{
		// ������
		char szRecv[1024] = {};
		int nlen = recv(_sock, szRecv, sizeof(DataHeader), 0);
		DataHeader* header = (DataHeader*)szRecv;
		if (nlen <= 0)
		{
			printf("�������ر�\n");
			return -1;
		}
		recv(_sock, szRecv + sizeof(DataHeader), header->dataLength - sizeof(DataHeader), 0);
		OnNetMsg(header);
		return 0;
	}

	// ��Ӧ������Ϣ
	virtual void OnNetMsg(DataHeader* header)
	{
		switch (header->cmd)
		{
		case CMD_LOGIN_RESULT:
		{
			LoginResult* loginret = (LoginResult*)header;
			printf("�յ����������%d,���ݳ��ȣ�%d , Ӧ�� %d\n", loginret->cmd, loginret->dataLength, loginret->result);
		}
		break;

		case CMD_LOGOUT_RESULT:
		{
			LogOutResult* logoutret = (LogOutResult*)header;
			printf("�յ����������%d,���ݳ��ȣ�%d , Ӧ�� %d\n", logoutret->cmd, logoutret->dataLength, logoutret->result);
		}
		break;

		case CMD_NEW_USER_JOIN:
		{
			NewUserJoin* userjoin = (NewUserJoin*)header;
			printf("�յ����������%d,���ݳ��ȣ�%d , Ӧ�� �ͻ���%d�Ѽ���\n", userjoin->cmd, userjoin->dataLength, userjoin->nsock);
		}
		break;

		default:
			DataHeader header = { 0,CMD_ERROR };
			send(_sock, (const char*)&header, sizeof(header), 0);
			break;
		}
	}

	//��ѯ������Ϣ
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
				printf("<socket = %d>selectʧ��\n", _sock);
				return false;
			}
			if (FD_ISSET(_sock, &fdRead))
			{
				FD_CLR(_sock, &fdRead);
				if (-1 == Recv())
				{
					printf("<socket = %d>�������\n", _sock);
					return false;
				}
			}
			return true;
			//printf("����ʱ�䴦������ҵ��\n");
		}
		return false;
	}

	// �Ƿ�����
	bool isRun()
	{
		return _sock != INVALID_SOCKET;
	}

};

#endif