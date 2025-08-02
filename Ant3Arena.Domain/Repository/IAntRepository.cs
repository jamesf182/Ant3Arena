using Ant3Arena.Domain.Enums;

namespace Ant3Arena.Domain.Repository;

public interface IAntRepository
{
    Dictionary<AntColorEnum, int> GetAnts();
}
