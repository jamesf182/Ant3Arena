using Ant3Arena.Application.Interfaces;
using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Repository;

namespace Ant3Arena.Application.Services;

public class AntService : IAntService
{
    private readonly IAntRepository _repository;

    public AntService(IAntRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Dictionary<AntColorEnum, int> GetAnts()
    {
        return _repository.GetAnts();
    }
}
