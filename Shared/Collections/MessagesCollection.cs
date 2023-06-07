using Shared;

namespace Collections;

public class MessagesCollection : Collection<ChatMessage>
{
    public void AddMessages(IEnumerable<ChatMessage> messages)
    {
        AddItems(messages);
    }

    public bool ExistsById(string id)
    {
        return Items.Any(u => u.Id == id);
    }

    public ChatMessage? GetByMessage(ChatMessage message)
    {
        return Items.FirstOrDefault(u => u == message);
    }

    public ChatMessage? GetById(string id)
    {
        return this.FirstOrDefault(u => u.Id == id);
    }

    public void RemoveById(string id)
    {
        RemoveAll(u => u.Id == id);
    }
}