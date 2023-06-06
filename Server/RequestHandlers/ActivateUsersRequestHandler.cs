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
    public class ActivateUsersRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var users = request.Get<UsersCollection>("users");
                int activatedUsersCount = 0;
                foreach (var user in users)
                {
                    var currentUser = UsersRepository.RegisteredUsers.GetById(user.Id);
                    if (currentUser != null)
                    {
                        currentUser.IsActive = true;
                        currentUser.Save(true);
                        activatedUsersCount++;
                    }
                }

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = $"Activated: {activatedUsersCount} users";
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
