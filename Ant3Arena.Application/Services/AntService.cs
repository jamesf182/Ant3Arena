using Ant3Arena.Application.Interfaces;
using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Factories;
using Ant3Arena.Domain.Repository;
using System.Drawing;

namespace Ant3Arena.Application.Services;

public class AntService : IAntService
{
    private readonly IAntRepository _repository;
    private readonly IAntFactory _factory;

    public AntService(IAntRepository repository, IAntFactory factory)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public List<Ant> GetAnts(Bitmap bitmap, Size clientSize)
    {
        List<AntDto> dtos = _repository.GetAnts();

        List<Ant> ants = [];

        foreach (AntDto dto in dtos)
        {
            ants.AddRange(_factory.CreateAntsFromDto(dto, bitmap, clientSize));
        }

        return ants;
    }
}