namespace Ant3Arena.Infrastructure.FileSystem;

public class FileReader : IFileReader
{
    public bool Exists(string path) => File.Exists(path);
    public string ReadAllText(string path) => File.ReadAllText(path);
}

