#pragma warning(disable:4996)
#include"EasyTcpClient.hpp"
#include<thread>
using namespace std;
void cmdThread(EasyTcpClient *client)
{
	while (true)
	{
		char cmdBuf[128] = {};
		scanf("%s", cmdBuf);
		if (0 == strcmp(cmdBuf, "Exit"))
		{
			client->Close();
			break;
		}
		else if(0 == strcmp(cmdBuf,"login"))
		{
			Login login;
			strcpy(login.userName, "zizi");
			strcpy(login.password, "zizi19991203");
			client->SendData(&login);

		}
		else if (0 == strcmp(cmdBuf, "logout"))
		{
			LogOut logout;
			strcpy(logout.userName, "zizi");
			client->SendData(&logout);

		}
		else
		{
			printf("不支持该命令,请重新输入\n");
		}
	}
}

int main()
{
	EasyTcpClient client;
	client.InitSocket();
	client.Connect("127.0.0.1", 4567);
	thread t1(cmdThread, &client);
	t1.detach();
	// 3.循环发送明林和接收服务器信息
	while (client.isRun())
	{
		client.OnRun();
	}
	client.Close();
	getchar();
	return 0;
}