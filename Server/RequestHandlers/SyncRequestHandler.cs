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
    // ReSharper disable once UnusedType.Global
    public class SyncRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var lastSyncTime = request.Get<DateTime>("lastSyncTime");
                var user = request.Get<User>("user");

                if (lastSyncTime < Sync.GetLastChangeTime())
                {
                    var chats = ChatsRepository.Items.Where(chat => chat.Users.Count == 0 || chat.Users.ExistsById(user.Id)).ToList();
                    var users = UsersRepository.RegisteredUsers.ToList();

                    response.Status = Response.StatusOk;
                    response.Message = "Fresh data sent";
                    response.Payload.Add("syncStatus", "updates");
                    response.Payload.Add("users", users);
                    response.Payload.Add("chats", chats);
                }
                else
                {
                    response.Status = Response.StatusOk;
                    response.Payload.Add("syncStatus", "no updates");
                    response.Message = "Don't have fresh data";
                }
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
