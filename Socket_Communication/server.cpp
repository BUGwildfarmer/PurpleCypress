#include"EasyTcpServer.hpp"

int main()
{
	EasyTcpServer server;
	server.InitSocket();
	server.Bind(NULL, 4567);
	server.Listen(5);
	while (server.isRun())
	{
		server.OnRun();
		//printf("空闲时间处理其他任务\n");
	}
	server.Close();
	//-----------------------------------------------------------

	//getchar();
	return 0;
}