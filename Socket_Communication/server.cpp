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
		//printf("����ʱ�䴦����������\n");
	}
	server.Close();
	//-----------------------------------------------------------

	//getchar();
	return 0;
}