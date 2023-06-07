using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections;
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
            {
                var chats = Directory.GetDirectories(chatsDirectoryPath).Select(directory => Chat.Load($"{directory}/chat.json", true)).ToList();

                chats.Sort((c1, c2) => c1.CreatedAt.CompareTo(c2.CreatedAt));

                Items.AddChats(chats);
            }
            else
            {
                // Add default chat for all messages
                var generalChat = Settings.Get<Dictionary<string, string>>("general_chat");
                var chat = new Chat(generalChat["title"]){Id = generalChat["id"]};

                chat.Save();

                ChatsRepository.Items.Add(chat);
            }
        }
    }
}
