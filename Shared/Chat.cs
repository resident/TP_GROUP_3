using Newtonsoft.Json;
using System;

namespace Shared;

public class Chat
{
    public string Id;
    public string Title;
    public UsersCollection Users = new();
    public List<ChatMessage> Messages = new();
    public DateTime CreatedAt = DateTime.Now;

    public Chat()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Chat(string title, UsersCollection? users = null, List<ChatMessage>? messages = null) : this()
    {
        Title = title;
        Users = users ?? new();
        Messages = messages ?? new();
    }

    public void AddMessage(ChatMessage message)
    {
        Messages ??= new();

        Messages.Add(message);
    }

    private string GetChatDirectoryPath()
    {
        return $"Chats/{Id}";
    }

    private string GetChatMessagesDirectoryPath()
    {
        return $"Chats/{Id}/Messages";
    }

    private string GetChatFilePath()
    {
        return $"{GetChatDirectoryPath()}/chat.json";
    }

    private IEnumerable<string> GetChatMessageDirectories()
    {
        var chatMessagesDirectoryPath = GetChatMessagesDirectoryPath();

        return Directory.Exists(chatMessagesDirectoryPath) ? Directory.GetDirectories(GetChatMessagesDirectoryPath()) : new string[]{};
    }

    public void Save(bool force = false)
    {
        var chatDirectoryPath = GetChatDirectoryPath();
        var chatFilePath = GetChatFilePath();

        if (!Directory.Exists(chatDirectoryPath)) Directory.CreateDirectory(chatDirectoryPath);

        if (!File.Exists(chatFilePath) || force) File.WriteAllText(chatFilePath, ToJson());
    }

    public void SaveFull(bool force = false)
    {
        Save(force);

        Messages.ForEach(m => m.Save(force));
    }

    public void Remove()
    {
        var chatDirectoryPath = GetChatDirectoryPath();

        if (Directory.Exists(chatDirectoryPath))
            Directory.Delete(chatDirectoryPath, true);
    }

    public static Chat Load(string path, bool full = false)
    {
        var chat = FromJson(File.ReadAllText(path));

        if (full)
            foreach (var directory in chat.GetChatMessageDirectories())
            {
                var messageFilePath = $"{directory}/message.json";
                
                if (File.Exists(messageFilePath))
                    chat.AddMessage(ChatMessage.Load(messageFilePath));
            }

        return chat;
    }

    public string ToJson(bool full = false)
    {
        var chat = full ? this : new Chat()
        {
            Id = Id,
            Title = Title,
            Users = Users,
        };

        return JsonConvert.SerializeObject(chat);
    }

    public static Chat FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Chat>(json) ?? throw new ArgumentNullException("Chat");
    }

    public override string ToString()
    {
        return $"{Title} ({Messages.Count})";
    }
}