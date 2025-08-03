using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Factories;
using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Application.Factory;

public class AntFactory : IAntFactory
{
    public IEnumerable<Ant> CreateAntsFromDto(AntDto dto, Bitmap bitmap, Size borders)
    {
        IMoveStrategy strategy = new MoveStrategy(dto.Strategies);

        List<Ant> ants = [];

        for (int i = 0; i < dto.Quantity; i++)
        {
            Ant ant = new(bitmap, borders, strategy,
                dto.HorizontalVelocity, dto.VerticalVelocity, dto.Color, dto.Direction);

            ants.Add(ant);
        }

        return ants;
    }

}

