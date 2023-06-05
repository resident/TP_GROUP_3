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
    internal class BanUserRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var login = request.Get<string>("login");
                var passwordHash = request.Get<string>("passwordHash");

                if(UsersRepository.RegisteredUsers.GetUser(login, passwordHash)?.IsBanned == true)
                    throw new RequestHandlerException("User already banned");

                UsersRepository.RegisteredUsers.GetUser(login, passwordHash).IsBanned = true;
                UsersRepository.RegisteredUsers.GetUser(login, passwordHash).BanExpiration = request.Get<DateTime>("bannedExpiration");
                UsersRepository.RegisteredUsers.GetUser(login, passwordHash).BannedAt = DateTime.Now;

                response.Status = Response.StatusOk;
                response.Message = "User successfully banned";
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
