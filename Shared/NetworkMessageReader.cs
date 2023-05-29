using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Shared;

public static class NetworkMessageReader
{
    public static async IAsyncEnumerable<string> Read(TcpClient client)
    {
        var stream = client.GetStream();
        var buffer = new byte[1024];
        int bytesRead;
        var messageJson = new StringBuilder();
        var stack = new Stack<byte>();

        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            var requestChunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            foreach (var c in requestChunk)
            {
                switch (c)
                {
                    case '{':
                        stack.Push(0);
                        break;
                    case '}':
                        stack.Pop();
                        break;
                }

                messageJson.Append(c);

                if (stack.Count != 0) continue;

                yield return messageJson.ToString();

                messageJson.Clear();
            }
        }
    }
}