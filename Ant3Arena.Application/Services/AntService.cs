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
        ArgumentNullException.ThrowIfNull(bitmap);

        if (clientSize.Width <= 0 || clientSize.Height <= 0)
        {
            throw new ArgumentException("Client size must have positive dimensions.", nameof(clientSize));
        }

        List<AntDto> dtos = _repository.GetAnts() ?? [];

        List<Ant> ants = [];

        foreach (AntDto dto in dtos)
        {
            IEnumerable<Ant> createdAnts = _factory.CreateAntsFromDto(dto, bitmap, clientSize);

            if (createdAnts != null)
                ants.AddRange(createdAnts);
        }

        return ants;
    }
}