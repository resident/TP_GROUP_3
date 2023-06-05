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
    public class RegistrationRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var user = request.Get<User>("user");

                if (UsersRepository.RegisteredUsers.ExistsByLogin(user.Login))
                {
                    throw new RequestHandlerException("User already exists");
                }
                else
                {
                    UsersRepository.RegisteredUsers.Add(user);

                    user.Save();

                    Sync.UpdateLastChangeTime();

                    response.Status = Response.StatusOk;
                    response.Message = "User successfully registered";
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
