namespace Shared;

public class Chat
{
    public string Title;
    public List<User> Users;
    public List<ChatMessage> Messages;

    public Chat(string title, List<User>? users = null, List<ChatMessage>? messages = null)
    {
        Title = title;
        Users = users ?? new List<User>();
        Messages = messages ?? new List<ChatMessage>();
    }

    public void AddMessage(ChatMessage message)
    {
        Messages.Add(message);
    }

    public override string ToString()
    {
        return $"{Title} ({Messages.Count})";
    }
}