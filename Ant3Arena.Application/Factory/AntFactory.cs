using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Application.Factory;

public static class AntFactory
{
    public static List<Ant> CreateAntsFromDto(AntDto dto, Bitmap bitmap, Size borders)
    {
        MoveStrategy strategy = new(dto.Strategies);

        var ants = new List<Ant>();

        for (int i = 0; i < dto.Quantity; i++)
        {
            var ant = new Ant(bitmap, borders, strategy,
                dto.HorizontalVelocity, dto.VerticalVelocity, dto.Hex);

            ants.Add(ant);
        }

        return ants;
    }
}

