using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Server.RequestHandlers
{
    public abstract class RequestHandler
    {
        public abstract void Handle(TcpClient client, Request request);
    }
}
