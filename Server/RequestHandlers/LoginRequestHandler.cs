using System.Net.Sockets;
using Newtonsoft.Json;
using Server.Exceptions;
using Shared;

namespace Server.RequestHandlers;

public class LoginRequestHandler : RequestHandler
{
    public override void Handle(TcpClient client, Request request)
    {
        var response = new Response();

        try
        {
            if (UsersRepository.OnlineUsers.GetUserByMetadata("TcpClient", client) != null)
                throw new RequestHandlerException("User already logged in");

            var json = request.Payload["auth"].ToString() ?? throw new ArgumentNullException("auth");
            var auth = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? throw new ArgumentNullException("auth"); ;
            var login = auth["login"];
            var passwordHash = Hash.Make(auth["password"], login);
            var user = UsersRepository.RegisteredUsers.GetUser(login, passwordHash);

            if (null != user)
            {
                UsersRepository.OnlineUsers.AddUser(user);
                UsersRepository.OnlineUsers.AddUserMetadata(login, "TcpClient", client);

                response.Status = Response.StatusOk;
                response.Message = "User successfully logged in";
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