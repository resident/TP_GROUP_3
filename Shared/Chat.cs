using Newtonsoft.Json;
using System;

namespace Shared;

public class Chat
{
    public string Id;
    public string Title;
    public List<User> Users;
    public List<ChatMessage> Messages;

    public Chat()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Chat(string title, List<User>? users = null, List<ChatMessage>? messages = null) : this()
    {
        Title = title;
        Users = users ?? new List<User>();
        Messages = messages ?? new List<ChatMessage>();
    }

    public void AddMessage(ChatMessage message)
    {
        Messages ??= new List<ChatMessage>();

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

    private string[] GetChatMessageDirectories()
    {
        return Directory.GetDirectories(GetChatMessagesDirectoryPath());
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

    public static Chat Load(string path, bool full = false)
    {
        var chat = FromJson(File.ReadAllText(path));

        if (full)
            foreach (var directory in chat.GetChatMessageDirectories())
                chat.AddMessage(ChatMessage.Load($"{directory}/message.json"));

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