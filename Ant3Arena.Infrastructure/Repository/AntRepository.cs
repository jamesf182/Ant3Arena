using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Repository;
using System.Text.Json;

namespace Ant3Arena.Infrastructure.Repository;

public class AntRepository : IAntRepository
{
    public Dictionary<AntColorEnum, int> GetAnts()
    {        
        string basePath = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(basePath, "Data", "ants.json");
             
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Arquivo ants.json não encontrado.", filePath);
                
        string json = File.ReadAllText(filePath);
        var rawData = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
                
        var result = new Dictionary<AntColorEnum, int>();
        foreach (var pair in rawData)
        {
            if (Enum.TryParse(pair.Key, true, out AntColorEnum color))
                result[color] = pair.Value;
        }

        return result;
    }
}

