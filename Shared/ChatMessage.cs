using System.Data;
using Newtonsoft.Json;

namespace Shared;

public class ChatMessage
{
    public string Id;
    public Chat Chat;
    public User Sender;
    public string Message;
    public bool HasFile;
    public ChatFile? ChatFile;
    public DateTime CreatedAt;
    
    public ChatMessage(User sender, Chat chat, string message, ChatFile? chatFile = null)
    {
        Id = Guid.NewGuid().ToString();
        Chat = chat;
        Sender = sender;
        Message = message;
        HasFile = null != chatFile;
        ChatFile = chatFile;
        CreatedAt = DateTime.Now;
    }

    private string GetMessageDirectoryPath()
    {
        return $"Chats/{Chat.Id}/Messages/{Id}";
    }

    private string GetMessageFilePath()
    {
        return $"{GetMessageDirectoryPath()}/message.json";
    }

    private string GetMessageChatFilePath()
    {
        return $"{GetMessageDirectoryPath()}/file.json";
    }

    private string GetMessageChatFileContentPath()
    {
        return $"{GetMessageDirectoryPath()}/file.bin";
    }

    public void Save(bool force = false)
    {
        var messageDirectoryPath = GetMessageDirectoryPath();
        var messageFilePath = GetMessageFilePath();

        if (!Directory.Exists(messageDirectoryPath)) Directory.CreateDirectory(messageDirectoryPath);
        if (!File.Exists(messageFilePath) || force) File.WriteAllText(messageFilePath, ToJson());
    }

    public void SaveChatFile(bool force = false, bool flush = true)
    {
        if (null == ChatFile || ChatFile.FileContent.Length == 0) return;

        var messageChatFilePath = GetMessageChatFilePath();
        var messageChatFileContentPath = GetMessageChatFileContentPath();

        if (!File.Exists(messageChatFilePath) || force) File.WriteAllText(messageChatFilePath, ChatFile.ToJson());
        if (!File.Exists(messageChatFileContentPath) || force) File.WriteAllBytes(messageChatFileContentPath, ChatFile.FileContent);

        if (flush) ChatFile.FileContent = Array.Empty<byte>();
    }
    
    public static ChatMessage Load(string path, bool full = false)
    {
        var message = FromJson(File.ReadAllText(path));

        if (!message.HasFile) return message;

        message.ChatFile = Shared.ChatFile.FromJson(File.ReadAllText(message.GetMessageChatFilePath()));

        if (full) message.LoadChatFileContent();

        return message;
    }

    public byte[] GetChatFileContentFromDisk()
    {
        return HasFile ? File.ReadAllBytes(GetMessageChatFileContentPath()) : Array.Empty<byte>();
    }

    public ChatFile? GetChatFileFromDisk(bool full = false)
    {
        var messageChatFilePath = GetMessageChatFilePath();

        if (!File.Exists(messageChatFilePath)) return null;

        var chatFile = ChatFile.FromJson(File.ReadAllText(messageChatFilePath));

        if (full) chatFile.FileContent = GetChatFileContentFromDisk();

        return chatFile;
    }

    public void LoadChatFileContent()
    {
        if (null != ChatFile) ChatFile.FileContent = File.ReadAllBytes(GetMessageChatFileContentPath());
    }

    public string ToJson(bool full = false)
    {
        var chatMessage = full ? this : new ChatMessage(Sender, Chat, Message, ChatFile)
        {
            Id = Id,
            Chat = Chat,
            Sender = Sender,
            CreatedAt = CreatedAt,
        };

        return JsonConvert.SerializeObject(chatMessage);
    }

    public static ChatMessage FromJson(string json)
    {
        return JsonConvert.DeserializeObject<ChatMessage>(json) ?? throw new NoNullAllowedException();
    }

    public override string ToString()
    {
        var file = HasFile ? "\ud83d\udcc1" : "";

        return $"{Sender.Login} :: {CreatedAt} :: {file} {Message}";
    }
}