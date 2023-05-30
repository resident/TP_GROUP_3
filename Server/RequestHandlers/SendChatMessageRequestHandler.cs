using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.Exceptions;
using Shared;

namespace Server.RequestHandlers
{
    public class SendChatMessageRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var json = request.Payload["message"].ToString() ?? throw new ArgumentNullException("message");
                var message = JsonConvert.DeserializeObject<ChatMessage>(json) ?? throw new ArgumentNullException("message");
                var chat = ChatsRepository.Items.Find(message.ChatId) ?? throw new RequestHandlerException($"Chat '{message.ChatId}' not found in server");

                chat.Messages.Add(message);

                chat.SaveFull();

                response.Status = Response.StatusOk;
                response.Message = "Message successfully sent";
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
