using Newtonsoft.Json;
using System.Formats.Tar;
using System.Reflection;

namespace Shared;

public class ChatFile
{
    public string Id;
    public string? Name;
    public byte[]? FileContent;


    public ChatFile()
    {
        Id = Guid.NewGuid().ToString();
    }

    public ChatFile(string path, string? name = null) : this()
    {
        Name = name ?? Path.GetFileName(path);

        using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        
        FileContent = new byte[fileStream.Length];
        
        _ = fileStream.Read(FileContent, 0, FileContent.Length);
    }

    public string ToJson(bool full = false)
    {
        var file = full ? this : new ChatFile()
        {
            Id = Id,
            Name = Name,
        };

        return JsonConvert.SerializeObject(file);
    }

    public static ChatFile FromJson(string json)
    {
        return JsonConvert.DeserializeObject<ChatFile>(json) ?? throw new ArgumentNullException("ChatFile");
    }
}