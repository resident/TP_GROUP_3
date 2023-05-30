using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Shared;

public class ChatsCollection : BindingList<Chat>
{
    public void AddChats(IEnumerable<Chat> chats)
    {
        foreach (var chat in chats) Add(chat);
    }

    public bool Exists(string title)
    {
        return this.Any(c => c.Title == title);
    }

    public bool Exists(Chat chat)
    {
        return this.Any(c => c == chat);
    }

    public Chat? Find(string id)
    {
        return this.FirstOrDefault(c => c.Id == id);
    }

    public Chat? Find(Chat chat)
    {
        return this.FirstOrDefault(c => c == chat);
    }
}