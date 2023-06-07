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
    internal class RemoveUserInChatRequestHandler : RequestHandler
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
                    throw new RequestHandlerException("Can't delete user in general chat");

                foreach (var user in users)
                {
                    if (chat!.Users.ExistsById(user!.Id))
                    {
                        chat.Users.RemoveById(user.Id);
                    }
                }

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = "User Successfully removed";
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
