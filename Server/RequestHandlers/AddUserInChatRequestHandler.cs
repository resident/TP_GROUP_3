using Server.Exceptions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Collections;

namespace Server.RequestHandlers
{
    internal class AddUserInChatRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var users = request.Get<UsersCollection>("users");
                var chat = request.Get<Chat>("chat");

                chat = ChatsRepository.Items.GetById(chat.Id);

                var generalChatSettings = Settings.Get<Dictionary<string, string>>("general_chat");

                if (chat!.Id == generalChatSettings!["id"])
                    throw new RequestHandlerException("Can't add user in general chat");

                foreach (var user in users)
                {
                    chat!.Users.Add(user);
                }
                

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

