using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Shared;

public class ChatsCollection : Collection<Chat>
{
    public void AddChats(IEnumerable<Chat> chats)
    {
        AddItems(chats);
    }

    public bool ExistsById(string id)
    {
        return Items.Any(c => c.Id == id);
    }

    public bool ExistsByTitle(string title)
    {
        return Items.Any(c => c.Title == title);
    }

    public Chat? GetByChat(Chat chat)
    {
        return this.FirstOrDefault(c => c == chat);
    }

    public Chat? GetById(string id)
    {
        return this.FirstOrDefault(c => c.Id == id);
    }

    public void RemoveById(string id)
    {
        RemoveAll(u => u.Id == id);
    }
}