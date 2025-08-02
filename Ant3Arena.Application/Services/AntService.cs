using Ant3Arena.Application.Factory;
using Ant3Arena.Application.Interfaces;
using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Repository;
using System.Drawing;

namespace Ant3Arena.Application.Services;

public class AntService : IAntService
{
    private readonly IAntRepository _repository;

    public AntService(IAntRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public List<Ant> GetAnts(Bitmap bitmap, Size clientSize)
    {
        var dtos = _repository.GetAnts();
        var ants = new List<Ant>();

        foreach (var dto in dtos)
        {
            ants.AddRange(AntFactory.CreateAntsFromDto(dto, bitmap, clientSize));
        }

        return ants;
    }
}

