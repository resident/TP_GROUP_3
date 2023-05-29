using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Shared;

public class ChatsCollection : BindingList<Chat>
{
    public void AddNew(Chat item)
    {
        int index = this.Count;
        InsertItem(index, item);
    }

    public bool Exists(string title)
    {
        return this.Any(c => c.Title == title);
    }

    public bool Exists(Chat chat)
    {
        return this.Any(c => c == chat);
    }

    public Chat? Find(string title)
    {
        return this.FirstOrDefault(c => c.Title == title);
    }

    public Chat? Find(Chat chat)
    {
        return this.FirstOrDefault(c => c == chat);
    }
}