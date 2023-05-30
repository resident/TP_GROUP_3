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
    public class SyncRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var lastSyncTime = DateTime.Parse(request.Payload["lastSyncTime"].ToString() ?? throw new ArgumentNullException("lastSyncTime"));
                var userJson = request.Payload["user"].ToString() ?? throw new ArgumentNullException("user");
                var user = JsonConvert.DeserializeObject<User>(userJson) ?? throw new ArgumentNullException("user");

                var users = new List<User>();

                foreach (var (item, metadata) in UsersRepository.RegisteredUsers) users.Add(item);

                var chats = ChatsRepository.Items.Where(chat => chat.Users.Count == 0 || chat.Users.Any(u => u.Id == user.Id)).ToList();

                response.Status = Response.StatusOk;
                response.Message = "Fresh data sent";
                response.Payload.Add("users", users);
                response.Payload.Add("chats", chats);
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
