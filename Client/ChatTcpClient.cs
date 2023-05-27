using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ChatTcpClient
    {
        private readonly string _ipAddress;
        private readonly int _port;
        public readonly TcpClient TcpClient;

        public ChatTcpClient(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
            TcpClient = new TcpClient();
        }

        public async void Connect()
        {
            await TcpClient.ConnectAsync(_ipAddress, _port);
        }

        public async void SendMessage(string message)
        {
            var stream = TcpClient.GetStream();
            var data = Encoding.UTF8.GetBytes(message);
            
            await stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<string> ReceiveMessage()
        {
            var stream = TcpClient.GetStream();
            var responseBuffer = new byte[1024];
            var bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
            var response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

            return response;
        }

        public void Close()
        {
            TcpClient.Close();
        }
    }
}
