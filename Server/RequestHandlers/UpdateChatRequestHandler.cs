using Collections;
using Server.Exceptions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandlers
{
    internal class UpdateChatRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var newChat = request.Get<Chat>("newChat");
                var oldChat = request.Get<Chat>("oldChat");

                oldChat = ChatsRepository.Items.GetById(oldChat.Id);
                
                var generalChatSettings = Settings.Get<Dictionary<string, string>>("general_chat");

                if (newChat!.Id == generalChatSettings!["id"])
                    throw new RequestHandlerException("Can't add user in general chat");

                ChatsRepository.Items.RemoveById(oldChat.Id);
                ChatsRepository.Items.AddChat(newChat);
                newChat.Save();

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = "User Successfully added";
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

