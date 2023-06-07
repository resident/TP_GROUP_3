using System.Data;
using System.Net.Sockets;
using Newtonsoft.Json;
using Server.Exceptions;
using Shared;

namespace Server.RequestHandlers;

// ReSharper disable once UnusedType.Global
public class LoginRequestHandler : RequestHandler
{
    public override void Handle(TcpClient client, Request request)
    {
        var response = new Response();

        try
        {
            if (UsersRepository.OnlineUsers.GetUserByMetadata("TcpClient", client) != null)
                throw new RequestHandlerException("User already logged in");
            
            var auth = request.Get<Dictionary<string, string>>("auth");

            var login = auth["login"];
            var passwordHash = Hash.Make(auth["password"], login);

            if (UsersRepository.RegisteredUsers.GetUser(login, passwordHash)?.Clone() is User user)
            {
                user.Metadata.Add("TcpClient", client);

                UsersRepository.OnlineUsers.Add(user);

                user = user.Clone() as User ?? throw new NoNullAllowedException();

                user.Metadata.Remove("TcpClient");

                response.Status = Response.StatusOk;
                response.Message = "User successfully logged in";
                response.Payload.Add("user", user);
            }
            else
            {
                throw new RequestHandlerException("Invalid login or password");
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