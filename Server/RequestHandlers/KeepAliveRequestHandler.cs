using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Server.RequestHandlers
{
    // ReSharper disable once UnusedType.Global
    public class KeepAliveRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response
            {
                Status = Response.StatusOk,
                Message = $"OK"
            };

            TcpServer.SendResponse(client, response);
        }
    }
}

