using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Server
{
    public static class ChatsRepository
    {
        public static readonly ChatsCollection Items;

        static ChatsRepository()
        {
            Items = new ChatsCollection();

            const string chatsDirectoryPath = "Chats";

            if (Directory.Exists(chatsDirectoryPath))
                foreach (var directory in Directory.GetDirectories(chatsDirectoryPath))
                    Items.Add(Chat.Load($"{directory}/chat.json", true));
            else
            {
                // Add default chat for all messages
                var generalChat = Settings.Get<Dictionary<string, string>>("general_chat") ?? throw new ArgumentNullException("general_chat");
                var chat = new Chat(generalChat["title"]){Id = generalChat["id"]};

                chat.Save();

                ChatsRepository.Items.Add(chat);
            }
        }
    }
}
