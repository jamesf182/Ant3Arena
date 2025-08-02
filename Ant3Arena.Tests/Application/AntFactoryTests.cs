using Ant3Arena.Application.Factory;
using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Entities;
using System.Drawing;

namespace Ant3Arena.Tests.Application;

public class AntFactoryTests
{
    [Fact]
    public void CreateAntsFromDto_CreatesCorrectAnts()
    {
        // Arrange
        AntFactory factory = new();

        Bitmap bitmap = new(10, 10);
        Size borders = new(100, 100);

        AntDto dto = new()
        {
            Quantity = 2,
            HorizontalVelocity = 5,
            VerticalVelocity = 3,
            Color = "#ABCDEF",
            Strategies = []
        };

        // Act
        List<Ant> ants = factory.CreateAntsFromDto(dto, bitmap, borders).ToList();

        // Assert
        Assert.Equal(dto.Quantity, ants.Count);

        foreach (Ant? ant in ants)
        {
            Assert.Equal(dto.HorizontalVelocity, ant.HorizontalVelocity);
            Assert.Equal(dto.VerticalVelocity, ant.VerticalVelocity);
            Assert.Equal(dto.Color, ant.Color);
        }
    }
}

