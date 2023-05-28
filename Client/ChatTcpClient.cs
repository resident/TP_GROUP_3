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
        private TcpClient _tcpClient = new TcpClient();

        public ChatTcpClient(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public async void Connect()
        {
            _tcpClient = new TcpClient();
            
            await _tcpClient.ConnectAsync(_ipAddress, _port);
        }

        public async void Disconnect()
        {
            await _tcpClient.Client.DisconnectAsync(false);
            
            _tcpClient.Close();
        }

        public bool IsConnected()
        {
            return _tcpClient.Connected;
        }

        public bool IsDisconnected()
        {
            return !IsConnected();
        }

        public async void SendMessage(string message)
        {
            var stream = _tcpClient.GetStream();
            var data = Encoding.UTF8.GetBytes(message);
            
            await stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<string> ReceiveMessage()
        {
            var stream = _tcpClient.GetStream();
            var responseBuffer = new byte[1024];
            var bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
            var response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

            return response;
        }

        public void Close()
        {
            _tcpClient.Close();
        }
    }
}
