using Newtonsoft.Json;
using System;
using System.Data;
using Collections;

namespace Shared;

public class Chat : ICloneable, IEquatable<Chat>
{
    public string Id;
    public string Title;
    public readonly UsersCollection Users;
    public MessagesCollection Messages;
    public DateTime CreatedAt = DateTimeSync.UtcNow;
    
    public Chat(string title, UsersCollection? users = null, MessagesCollection? messages = null)
    {
        Id = Guid.NewGuid().ToString();
        Title = title;
        Users = users ?? new();
        Messages = messages ?? new();
    }

    public void ChangeTitle(string title)
    {
        Title = title;
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

        foreach (var message in Messages) message.Save(true);
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
        var sorted = Messages.OrderBy(m => m.CreatedAt).ToList();
        Messages.Clear();
        Messages.AddMessages(sorted);
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

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public bool Equals(Chat? other)
    {
        throw new NotImplementedException();
    }
}