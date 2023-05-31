using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Exceptions;
using Shared;

namespace Server.RequestHandlers
{
    public class RemoveChatRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var user = request.Get<User>("user");
                var chat = request.Get<Chat>("chat");

                chat = ChatsRepository.Items.GetById(chat!.Id);

                var generalChatSettings = Settings.Get<Dictionary<string, string>>("general_chat");

                if (chat!.Id == generalChatSettings!["id"])
                    throw new RequestHandlerException("Can't delete general chat");

                if (chat!.Users.ExistsById(user!.Id))
                {
                    chat.Users.RemoveById(user.Id);
                }

                if (chat.Users.Count == 0)
                {
                    ChatsRepository.Items.RemoveById(chat.Id);

                    // Remove chat from disk
                    chat.Remove();
                }
                else
                    chat.Save(true);

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = "Chat Successfully removed";
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
