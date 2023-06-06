using Newtonsoft.Json;

namespace Shared;

public class ChatMessage
{
    public string Id;
    public string ChatId;
    public User Sender;
    public DateTime DateTime;
    public string Message;
    public bool HasFile;
    public ChatFile? ChatFile;
    public DateTime CreatedAt = DateTime.Now;

    public ChatMessage()
    {
        Id = Guid.NewGuid().ToString();
    }

    public ChatMessage(User sender, Chat chat, string message, ChatFile? chatFile = null) : this()
    {
        ChatId = chat.Id;
        Sender = sender;
        DateTime = DateTime.Now;
        Message = message;
        HasFile = null != chatFile;
        ChatFile = chatFile;
    }

    private string GetMessageDirectoryPath()
    {
        return $"Chats/{ChatId}/Messages/{Id}";
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
        var chatMessage = full ? this : new ChatMessage()
        {
            Id = Id,
            ChatId = ChatId,
            Sender = Sender,
            DateTime = DateTime,
            Message = Message,
            HasFile = HasFile,
        };

        return JsonConvert.SerializeObject(chatMessage);
    }

    public static ChatMessage FromJson(string json)
    {
        return JsonConvert.DeserializeObject<ChatMessage>(json) ?? throw new ArgumentNullException("ChatMessage");
    }

    public override string ToString()
    {
        var file = HasFile ? "\ud83d\udcc1" : "";

        return $"{Sender.Login} :: {DateTime} :: {file} {Message}";
    }
}