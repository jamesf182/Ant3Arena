using Ant3Arena.Domain.DTO;

namespace Ant3Arena.Domain.Repository;

public interface IAntRepository
{
    List<AntDto> GetAnts();
}
