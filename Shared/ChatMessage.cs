namespace Shared;

public class ChatMessage
{
    public User Sender;
    public DateTime DateTime;
    public string Message;
    public ChatFile? File;
    public string ChatTitle;

    public ChatMessage(User sender, string chat, string message, ChatFile? file = null)
    {
        Sender = sender;
        DateTime = DateTime.Now;
        Message = message;
        File = file;
        ChatTitle = chat;
    }

    public bool HasFile()
    {
        return File != null;
    }

    public override string ToString()
    {
        return $"{Sender.Login} :: {DateTime.ToString()} :: {Message}";
    }
}