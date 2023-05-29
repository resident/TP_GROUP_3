namespace Shared;

public class ChatFile
{
    public string? Name;
    public byte[]? FileContent;


    public ChatFile()
    {
    }

    public ChatFile(string path, string? name = null)
    {
        Name = name ?? Path.GetFileName(path);

        using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        
        FileContent = new byte[fileStream.Length];
        
        _ = fileStream.Read(FileContent, 0, FileContent.Length);
    }
}