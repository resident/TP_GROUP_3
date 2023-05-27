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
                var json = request.Payload["user"].ToString() ?? throw new ArgumentNullException("user");
                var user = User.FromJson(json) ?? throw new ArgumentNullException("user"); ;

                if (UsersRepository.RegisteredUsers.UserExists(user.Login))
                {
                    throw new RequestHandlerException("User already exists");
                }
                else
                {
                    UsersRepository.RegisteredUsers.AddUser(user);

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
