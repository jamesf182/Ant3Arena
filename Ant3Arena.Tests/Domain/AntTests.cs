using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Strategy;
using NSubstitute;
using System.Drawing;

namespace Ant3Arena.Tests.Domain;

public class AntTests
{
    [Fact]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        Bitmap baseImage = new(10, 10);
        Size borders = new(100, 100);
        IMoveStrategy moveStrategy = Substitute.For<IMoveStrategy>();

        // Act
        Ant ant = new(baseImage, borders, moveStrategy, 2, 3, "#FF0000", DirectionEnum.LeftDown);

        // Assert
        Assert.Equal(2, ant.HorizontalVelocity);
        Assert.Equal(3, ant.VerticalVelocity);
        Assert.Equal("#FF0000", ant.Color);
        Assert.Equal(DirectionEnum.LeftDown, ant.Direction);
        Assert.NotNull(ant.AntImage);
        Assert.InRange(ant.X, 0, borders.Width);
        Assert.InRange(ant.Y, 0, borders.Height);
    }

    [Fact]
    public void Constructor_ShouldClampNegativeVelocitiesToZero()
    {
        // Arrange
        Bitmap baseImage = new(10, 10);
        Size borders = new(100, 100);
        IMoveStrategy moveStrategy = Substitute.For<IMoveStrategy>();

        // Act
        Ant ant = new(baseImage, borders, moveStrategy, -5, -10, "#00FF00", DirectionEnum.LeftDown);

        // Assert
        Assert.Equal(0, ant.HorizontalVelocity);
        Assert.Equal(0, ant.VerticalVelocity);
    }

    [Fact]
    public void Move_ShouldUpdatePositionAndDirection()
    {
        // Arrange
        Bitmap baseImage = new(10, 10);
        Size borders = new(100, 100);
        IMoveStrategy moveStrategy = Substitute.For<IMoveStrategy>();

        moveStrategy.Move(ref Arg.Any<int>(), ref Arg.Any<int>(), Arg.Any<MovementContext>())
                    .Returns(call =>
                    {
                        call[0] = (int)call[0] + 2;
                        call[1] = (int)call[1] + 2;
                        return DirectionEnum.RightDown;
                    });

        Ant ant = new(baseImage, borders, moveStrategy, 2, 2, "#0000FF", DirectionEnum.LeftDown);

        int originalX = ant.X;
        int originalY = ant.Y;

        // Act
        ant.Move(borders);

        // Assert
        Assert.Equal(originalX + 2, ant.X);
        Assert.Equal(originalY + 2, ant.Y);
        Assert.Equal(DirectionEnum.RightDown, ant.Direction);
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenMoveStrategyIsNull()
    {
        // Arrange
        Bitmap baseImage = new(10, 10);
        Size borders = new(100, 100);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new Ant(baseImage, borders, null!, 1, 1, "#FFFFFF", DirectionEnum.LeftDown));
    }

    [Fact]
    public void GenerateColoredImage_ShouldFallbackToDefaultColor_WhenInvalidHex()
    {
        // Arrange
        Bitmap baseImage = new(10, 10);
        Size borders = new(100, 100);
        IMoveStrategy moveStrategy = Substitute.For<IMoveStrategy>();

        // Act
        Ant ant = new(baseImage, borders, moveStrategy, 1, 1, "invalid-color", DirectionEnum.LeftDown);

        // Assert
        Assert.NotNull(ant.AntImage);
    }
}

