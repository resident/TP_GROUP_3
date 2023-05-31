using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Server.RequestHandlers
{
    public class CreateChatRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var chat = request.Get<Chat>("chat");
                
                ChatsRepository.Items.Add(chat!);
                chat!.Save();

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = "Chat Successfully added";
            }
            catch (Exception ex)
            {
                response.Status = Response.StatusError;
                response.Message = ex.Message;
            }

            TcpServer.SendResponse(client, response);
        }
    }
}
