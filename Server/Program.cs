namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            RequestHandlersProvider.InitHandlers();

            var server = new TcpServer("127.0.0.1", 1234);

            await server.Start();
        }
    }
}