using Collections;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandlers
{
    internal class EditUsersBanRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var users = request.Get<UsersCollection>("users");
                var banExpirations = request.Get<List<DateTime>>("banExpirations");

                var editedUsersCount = 0;

                for (int i = 0; i < users.Count; i++)
                {               
                    var registeredUser = UsersRepository.RegisteredUsers.GetById(users[i].Id);

                    if (registeredUser == null || registeredUser.IsAdmin) continue;

                    registeredUser.IsBanned = true;
                    registeredUser.BanExpiration = banExpirations[i];
                    registeredUser.Save(true);

                    editedUsersCount++;
                }

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = $"Edited {editedUsersCount} users";
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
