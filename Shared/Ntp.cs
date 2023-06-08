using System.Net.Sockets;
using System.Net;

namespace Shared;

public static class Ntp
{
    public static DateTime GetNetworkTimeUtc()
    {
        var config = Settings.Get<Dictionary<string, object>>("ntp");

        var host = (string) config["host"];
        var port = Convert.ToInt32(config["port"]);

        var ntpData = new byte[48];

        ntpData[0] = 0x1B;

        var addresses = Dns.GetHostEntry(host).AddressList;

        var ipEndPoint = new IPEndPoint(addresses[0], port);

        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
            socket.Connect(ipEndPoint);

            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();
        }

        const byte serverReplyTime = 40;

        ulong intPart = SwapEndianness(BitConverter.ToUInt32(ntpData, serverReplyTime));
        ulong fractPart = SwapEndianness(BitConverter.ToUInt32(ntpData, serverReplyTime + 4));

        var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
        var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((ulong)milliseconds);

        return networkDateTime;
    }

    static uint SwapEndianness(ulong x)
    {
        return (uint)(((x & 0x000000ff) << 24) +
                      ((x & 0x0000ff00) << 8) +
                      ((x & 0x00ff0000) >> 8) +
                      ((x & 0xff000000) >> 24));
    }
}