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
            var adminCredentials = Settings.Get<Dictionary<string, string>>("default_admin_credentials") ?? throw new ArgumentNullException("default_admin_credentials");
            var admin = new User(adminCredentials["login"], adminCredentials["password"])
            {
                IsAdmin = true
            };

            UsersRepository.RegisteredUsers.AddUser(admin);
            Alert.Successful($"Default admin account: {adminCredentials["login"]}:{adminCredentials["password"]}");

            // Add default chat for all messages
            var generalChatTitle = Settings.Get<string>("general_chat_title") ?? throw new ArgumentNullException("general_chat_title");
            ChatsRepository.Items.Add(new Chat(generalChatTitle));
            Alert.Successful($"Chat '{generalChatTitle}' added");
        }

        public async Task Start()
        {
            _listener.Start();
            Alert.Successful($"Server started. Waiting for connections on {_ipAddress}:{_port}...");

            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            Alert.Successful($"Client connected {client.Client.RemoteEndPoint}");

            try
            {
                var requests = NetworkMessageReader.Read(client);

                await foreach (var requestJson in requests)
                {
                    Alert.Show($"Received: {requestJson}");

                    var request = Request.FromJson(requestJson.ToString()) ?? new Request();

                    RequestHandlersProvider.Handle(client, request, new DefaultRequestHandler());
                }
            }
            catch (IOException ex)
            {
                Alert.Error($"IO error: {ex.Message}");
            }
            catch (SocketException ex)
            {
                Alert.Error($"Socket error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Alert.Error($"Error: {ex.ToString()}");
            }
            finally
            {
                Alert.Error($"Client disconnected: {client.Client.RemoteEndPoint}");

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
