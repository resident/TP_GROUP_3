using System.Data;
using Newtonsoft.Json;
using System.Formats.Tar;
using System.Reflection;

namespace Shared;

public class ChatFile
{
    public string Id;
    public string Name;
    public byte[] FileContent;
    
    public ChatFile(string path, string? name = null)
    {
        Id = Guid.NewGuid().ToString();
        Name = name ?? Path.GetFileName(path);

        using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        
        FileContent = new byte[fileStream.Length];
        
        _ = fileStream.Read(FileContent, 0, FileContent.Length);
    }

    public string ToJson(bool full = false)
    {
        var file = full ? this : new ChatFile(string.Empty)
        {
            Id = Id,
            Name = Name,
        };

        return JsonConvert.SerializeObject(file);
    }

    public static ChatFile FromJson(string json)
    {
        return JsonConvert.DeserializeObject<ChatFile>(json) ?? throw new NoNullAllowedException();
    }
}