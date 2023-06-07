using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Collections;
using Server.Exceptions;
using Shared;

namespace Server.RequestHandlers
{
    // ReSharper disable once UnusedType.Global
    public class DeleteMessageRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var user = request.Get<User>("user");
                var message = request.Get<ChatMessage>("message");
                var chat = ChatsRepository.Items.GetById(message.ChatId) ?? throw new RequestHandlerException("Chat not found");

                message = chat.Messages.GetById(message.Id) ?? throw new RequestHandlerException("Message not found");

                if (!user.IsAdmin && message.Sender.Id != user.Id)
                    throw new RequestHandlerException("You don't have permission for delete this message");

                chat.Messages.RemoveById(message.Id);

                message.Remove();

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = $"Message removed";
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
