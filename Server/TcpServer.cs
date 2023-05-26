using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class TcpServer
    {
        private readonly string _ipAddress;
        private readonly int _port;
        private readonly TcpListener _listener;
        
        public TcpServer(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
            _listener = new TcpListener(IPAddress.Parse(ipAddress), port);
        }

        public async Task Start()
        {
            _listener.Start();
            Console.WriteLine($"Server started. Waiting for connections on {_ipAddress}:{_port}...");

            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            Console.WriteLine($"Client connected {client.Client.RemoteEndPoint}");

            try
            {
                using var stream = client.GetStream();
                var buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    var receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {receivedData}");


                    var response = Encoding.ASCII.GetBytes($"Server response: {receivedData}");
                    await stream.WriteAsync(response, 0, response.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
