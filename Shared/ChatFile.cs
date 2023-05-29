namespace Shared;

public class ChatFile
{
    public string? Name;
    public string? FileBase64;

    public ChatFile()
    {
    }

    public ChatFile(string path, string? name = null)
    {
        using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        var fileBytes = new byte[fileStream.Length];
        _ = fileStream.Read(fileBytes, 0, fileBytes.Length);

        Name = name ?? Path.GetFileName(path);
        FileBase64 = Convert.ToBase64String(fileBytes);
    }

    public override string ToString()
    {
        return FileBase64 ?? "";
    }
}