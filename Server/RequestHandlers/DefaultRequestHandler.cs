using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Server.RequestHandlers
{
    public class DefaultRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response
            {
                Status = Response.StatusError,
                Message = "Not found handler for this action"
            };

            TcpServer.SendResponse(client, response);
        }
    }
}
