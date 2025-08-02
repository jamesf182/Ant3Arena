using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Ant3Arena.Infrastructure.Repository;

public class AntRepository : IAntRepository
{
    private readonly ILogger<AntRepository> _logger;

    public AntRepository(ILogger<AntRepository> logger)
    {
        _logger = logger;
    }

    public List<AntDto> GetAnts()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "Data", "ants.json");

        if (!File.Exists(filePath))
        {
            _logger.LogWarning("File 'ants.json' not found at path: {Path}", filePath);
            return [];
        }

        string json = File.ReadAllText(filePath);
        if (string.IsNullOrEmpty(json))
        {
            _logger.LogWarning("File 'ants.json' is empty.");
            return [];
        }

        try
        {
            List<AntDto>? result = JsonSerializer.Deserialize<List<AntDto>>(json);
            if (result is null)
            {
                _logger.LogError("Deserialization of 'ants.json' returned null.");
                return [];
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deserializing 'ants.json'.");
            return [];
        }
    }
}
