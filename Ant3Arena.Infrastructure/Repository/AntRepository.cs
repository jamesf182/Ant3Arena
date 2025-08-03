using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Repository;
using Ant3Arena.Infrastructure.FileSystem;
using Ant3Arena.Infrastructure.LogsMessages;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Ant3Arena.Infrastructure.Repository;

public class AntRepository : IAntRepository
{
    private readonly ILogger<AntRepository> _logger;
    private readonly IFileReader _fileReader;

    public AntRepository(ILogger<AntRepository> logger, IFileReader fileReader)
    {
        _logger = logger;
        _fileReader = fileReader;
    }

    public List<AntDto> GetAnts()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "Data", "ants.json");

        if (!_fileReader.Exists(filePath))
        {
            _logger.LogWarning(AntLogMessages.FileNotFound, filePath);
            return [];
        }

        string json = _fileReader.ReadAllText(filePath);
        if (string.IsNullOrEmpty(json))
        {
            _logger.LogWarning(AntLogMessages.FileEmpty);
            return [];
        }

        try
        {
            List<AntDto>? result = JsonSerializer.Deserialize<List<AntDto>>(json);
            if (result is null)
            {
                _logger.LogError(AntLogMessages.DeserializationNull);
                return [];
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, AntLogMessages.DeserializationError);
            return [];
        }
    }
}
