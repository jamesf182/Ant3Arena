using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Application.Factory;

public static class AntFactory
{
    public static List<Ant> CreateAntsFromDto(AntDto dto, Bitmap bitmap, Size borders)
    {
        var ants = new List<Ant>();

        IMoveStrategy strategy = dto.Strategy.ToLower() switch
        {
            "red" => new RedAntMoveStrategy(),
            "black" => new BlackAntMoveStrategy(),
            "yellow" => new YellowAntMoveStrategy(),
            "white" => new WhiteAntMoveStrategy(),
            _ => throw new ArgumentException($"Unknown strategy: {dto.Strategy}")
        };

        for (int i = 0; i < dto.Quantity; i++)
        {
            var ant = new Ant(bitmap, borders, strategy, dto.HorizontalVelocity, dto.VerticalVelocity, dto.Color);
            ants.Add(ant);
        }

        return ants;
    }
}

