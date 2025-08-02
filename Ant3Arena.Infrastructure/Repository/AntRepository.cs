using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Repository;
using System.Text.Json;

namespace Ant3Arena.Infrastructure.Repository;

public class AntRepository : IAntRepository
{
    public List<AntDto> GetAnts()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "Data", "ants.json");

        if (!File.Exists(filePath))
        {
            //throw new FileNotFoundException("Arquivo ants.json não encontrado.", filePath);
            return [];
        }            

        string json = File.ReadAllText(filePath);
        var result = JsonSerializer.Deserialize<List<AntDto>>(json);

        if (result is null)
        {
            //throw new InvalidOperationException("Erro ao deserializar o arquivo ants.json.");
            return [];
        }

        return result;
    }
}
