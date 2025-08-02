using Ant3Arena.Application.Services;
using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Factories;
using Ant3Arena.Domain.Repository;
using Ant3Arena.Domain.Strategy;
using NSubstitute;
using System.Drawing;

namespace Ant3Arena.Tests.Application;

public class AntServiceTests
{
    [Fact]
    public void GetAnts_ReturnsExpectedAnts()
    {
        // Arrange
        IAntRepository repository = Substitute.For<IAntRepository>();
        IAntFactory factory = Substitute.For<IAntFactory>();
        IMoveStrategy strategy = Substitute.For<IMoveStrategy>();

        Bitmap bitmap = new(10, 10);
        Size clientSize = new(100, 100);

        AntDto dto = new() { };
        List<AntDto> dtos = [dto];

        List<Ant> expectedAnts = [
            new Ant(bitmap, clientSize, strategy, 2, 2, "#FF0000"),
            new Ant(bitmap, clientSize, strategy, 6, 4, "#FFFF00"),
        ];

        repository.GetAnts()
            .Returns(dtos);

        factory.CreateAntsFromDto(dto, bitmap, clientSize).Returns(expectedAnts);

        var service = new AntService(repository, factory);

        // Act
        var result = service.GetAnts(bitmap, clientSize);

        // Assert
        Assert.Equal(expectedAnts.Count, result.Count);
        Assert.All(result, ant => Assert.IsType<Ant>(ant));

        repository.Received(1).GetAnts();
        factory.Received(1).CreateAntsFromDto(dto, bitmap, clientSize);
    }

    [Fact]
    public void GetAnts_NullBitmap_ThrowsArgumentNullException()
    {
        // Arrange
        var repository = Substitute.For<IAntRepository>();
        var factory = Substitute.For<IAntFactory>();

        var service = new AntService(repository, factory);

        Bitmap? bitmap = null;
        Size clientSize = new(100, 100);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => service.GetAnts(bitmap!, clientSize));
    }

    [Theory]
    [InlineData(0, 100)]
    [InlineData(100, 0)]
    [InlineData(-50, 100)]
    [InlineData(100, -50)]
    public void GetAnts_InvalidClientSize_ThrowsArgumentException(int width, int height)
    {
        // Arrange
        var repository = Substitute.For<IAntRepository>();
        var factory = Substitute.For<IAntFactory>();

        var service = new AntService(repository, factory);

        Bitmap bitmap = new Bitmap(10, 10);
        var clientSize = new Size(width, height);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => service.GetAnts(bitmap, clientSize));
    }

    [Fact]
    public void GetAnts_RepositoryReturnsNull_ReturnsEmptyList()
    {
        // Arrange
        var repository = Substitute.For<IAntRepository>();
        var factory = Substitute.For<IAntFactory>();

        var service = new AntService(repository, factory);

        repository.GetAnts()
            .Returns((List<AntDto>?)null);

        Bitmap bitmap = new Bitmap(10, 10);
        var clientSize = new Size(100, 100);

        // Act
        var result = service.GetAnts(bitmap, clientSize);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetAnts_FactoryReturnsNull_IgnoresAndContinues()
    {
        // Arrange
        var repository = Substitute.For<IAntRepository>();
        var factory = Substitute.For<IAntFactory>();

        var service = new AntService(repository, factory);

        var dto = new AntDto 
        { 
            Quantity = 1, 
            Color = "#FF0000", 
            HorizontalVelocity = 1, 
            VerticalVelocity = 1, 
            Strategies = [] 
        };

        repository.GetAnts().Returns([dto]);

        factory.CreateAntsFromDto(dto, Arg.Any<Bitmap>(), Arg.Any<Size>())
            .Returns((IEnumerable<Ant>?)null);

        Bitmap bitmap = new(10, 10);
        var clientSize = new Size(100, 100);

        // Act
        var result = service.GetAnts(bitmap, clientSize);

        // Assert
        Assert.Empty(result);
    }


}

