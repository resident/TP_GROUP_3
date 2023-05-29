using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Shared;
using System.Text.Json;
using System.IO;
using Server.RequestHandlers;

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

            // Add default admin account
            UsersRepository.RegisteredUsers.AddUser(new User("admin", "password"){IsAdmin = true});
            Alert.Show($"Default admin account: admin:password");

            // Add default chat for all messages
            ChatsRepository.Items.Add(new Chat("General"));
            Alert.Show("Chat 'General' added");
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
                var stream = client.GetStream();
                var buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    try
                    {
                        var json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received: {json}");

                        var request = Request.FromJson(json) ?? new Request();

                        RequestHandlersProvider.Handle(client, request, new DefaultRequestHandler());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error: {ex.Message}");
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            finally
            {
                Console.WriteLine($"Client disconnected: {client.Client.RemoteEndPoint}");

                var user = UsersRepository.OnlineUsers.GetUserByMetadata("TcpClient", client);

                if (null != user) UsersRepository.OnlineUsers.RemoveUser(user);

                client.Close();
            }
        }

        public static async void SendResponse(TcpClient client, Response response)
        {
            var stream = client.GetStream();
            var responseBytes = Encoding.UTF8.GetBytes(response.ToJson());
            await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
