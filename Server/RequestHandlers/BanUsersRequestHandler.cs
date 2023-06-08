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
    // ReSharper disable once UnusedType.Global
    public class BanUsersRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var users = request.Get<UsersCollection>("users");
                var banExpiration = request.Get<DateTime>("banExpiration");

                var bannedUsersCount = 0;

                foreach (var user in users)
                {
                    var registeredUser = UsersRepository.RegisteredUsers.GetById(user.Id);

                    if (registeredUser == null || registeredUser.IsAdmin) continue;

                    registeredUser.IsBanned = true;
                    registeredUser.BannedAt = DateTimeSync.UtcNow;
                    registeredUser.BanExpiration = banExpiration;
                    registeredUser.Save(true);

                    bannedUsersCount++;
                }

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = $"Banned {bannedUsersCount} users";
            }
            catch(Exception ex)
            {
                response.Status = Response.StatusError;
                response.Message = ex.Message;
            }

            TcpServer.SendResponse(client, response);
        }
    }
}
