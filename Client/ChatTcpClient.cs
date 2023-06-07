using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Client
{
    internal class ChatTcpClient
    {
        private readonly string _ipAddress;
        private readonly int _port;
        private TcpClient _tcpClient = new();
        private IAsyncEnumerable<string>? _responses;

        public ChatTcpClient(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public void Connect()
        {
            _tcpClient = new TcpClient();
            
            _tcpClient.Connect(_ipAddress, _port);

            _responses = NetworkMessageReader.Read(_tcpClient);
        }

        public async Task ConnectAsync()
        {
            _tcpClient = new TcpClient();

            await _tcpClient.ConnectAsync(_ipAddress, _port);

            _responses = NetworkMessageReader.Read(_tcpClient);
        }

        public void Disconnect()
        {
            _tcpClient.Client.Disconnect(false);

            _tcpClient.Close();
        }

        public async Task DisconnectAsync()
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
            if (null == _responses) throw new NoNullAllowedException();

            await using var enumerator = _responses.GetAsyncEnumerator();
            await enumerator.MoveNextAsync();

            return enumerator.Current;
        }

        public void Close()
        {
            _tcpClient.Close();
        }
    }
}
