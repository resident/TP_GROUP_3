using Newtonsoft.Json;
using System;
using System.Data;

namespace Shared;

public class Chat
{
    public string Id;
    public readonly string Title;
    public readonly UsersCollection Users;
    public List<ChatMessage> Messages;
    public DateTime CreatedAt = DateTime.Now;
    
    public Chat(string title, UsersCollection? users = null, List<ChatMessage>? messages = null)
    {
        Id = Guid.NewGuid().ToString();
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

        if (!full) return chat;

        foreach (var directory in chat.GetChatMessageDirectories())
        {
            var messageFilePath = $"{directory}/message.json";
                
            if (File.Exists(messageFilePath))
                chat.AddMessage(ChatMessage.Load(messageFilePath));
        }

        chat.Sort();

        return chat;
    }

    public void Sort()
    {
        Messages.Sort((m1, m2) => m1.CreatedAt.CompareTo(m2.CreatedAt));
    }

    public string ToJson(bool full = false)
    {
        var chat = full ? this : new Chat(Title, Users)
        {
            Id = Id
        };

        return JsonConvert.SerializeObject(chat);
    }

    public static Chat FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Chat>(json) ?? throw new NoNullAllowedException();
    }

    public override string ToString()
    {
        return $"{Title} ({Messages.Count})";
    }
}