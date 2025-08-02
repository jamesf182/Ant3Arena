using Ant3Arena.Domain.Enums;

namespace Ant3Arena.Application.Interfaces;

public interface IAntService
{
    Dictionary<AntColorEnum, int> GetAnts();
}

