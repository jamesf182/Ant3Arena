namespace Ant3Arena.Infrastructure.FileSystem;

public interface IFileReader
{
    bool Exists(string path);
    string ReadAllText(string path);
}

