namespace Ant3Arena.Infrastructure.LogsMessages;

public static class AntLogMessages
{
    public const string FileNotFound = "File 'ants.json' not found at path: {Path}";
    public const string FileEmpty = "File 'ants.json' is empty.";
    public const string DeserializationNull = "Deserialization of 'ants.json' returned null.";
    public const string DeserializationError = "An error occurred while deserializing 'ants.json'.";
}

