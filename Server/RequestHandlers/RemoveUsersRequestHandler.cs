using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandlers
{
    // ReSharper disable once UnusedType.Global
    public class RemoveUsersRequestHandler:RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var users = request.Get<UsersCollection>("users");
                var removedUsersCount = 0;

                foreach (var user in users)
                {
                    var currentUser = UsersRepository.RegisteredUsers.GetById(user.Id);

                    if (currentUser is null or {IsAdmin: true}) continue;

                    UsersRepository.RegisteredUsers.RemoveById(user.Id);
                    currentUser.Remove();
                    removedUsersCount++;
                }

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = $"Removed: {removedUsersCount} users";
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
