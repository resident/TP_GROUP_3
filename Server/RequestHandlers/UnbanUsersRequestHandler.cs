﻿using Collections;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.RequestHandlers
{
    internal class UnbanUsersRequestHandler : RequestHandler
    {
        public override void Handle(TcpClient client, Request request)
        {
            var response = new Response();

            try
            {
                var users = request.Get<UsersCollection>("users");
                var unbannedUsersCount = 0;

                foreach (var user in users)
                {
                    var registeredUser = UsersRepository.RegisteredUsers.GetById(user.Id);

                    if (registeredUser == null || registeredUser.IsAdmin) continue;

                    registeredUser.IsBanned = false;
                    registeredUser.Save(true);

                    unbannedUsersCount++;
                }

                Sync.UpdateLastChangeTime();

                response.Status = Response.StatusOk;
                response.Message = $"Unbanned {unbannedUsersCount} users";
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
