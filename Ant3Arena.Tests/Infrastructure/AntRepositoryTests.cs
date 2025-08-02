using Ant3Arena.Domain.DTO;
using Ant3Arena.Infrastructure.FileSystem;
using Ant3Arena.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Ant3Arena.Tests.Infrastructure;
public class AntRepositoryTests
{
    [Fact]
    public void GetAnts_FileDoesNotExist_ReturnsEmptyListAndLogsWarning()
    {
        // Arrange
        ILogger<AntRepository> logger = Substitute.For<ILogger<AntRepository>>();
        IFileReader fileReader = Substitute.For<IFileReader>();

        fileReader.Exists(Arg.Any<string>())
            .Returns(false);

        AntRepository repo = new(logger, fileReader);

        // Act
        List<AntDto> result = repo.GetAnts();

        // Assert
        Assert.Empty(result);
        Assert.Contains(logger.ReceivedCalls(), call => call.GetMethodInfo().Name.Contains("Log"));
    }

    [Fact]
    public void GetAnts_FileIsEmpty_ReturnsEmptyListAndLogsWarning()
    {
        // Arrange
        ILogger<AntRepository> logger = Substitute.For<ILogger<AntRepository>>();
        IFileReader fileReader = Substitute.For<IFileReader>();

        fileReader.Exists(Arg.Any<string>())
            .Returns(true);

        fileReader.ReadAllText(Arg.Any<string>())
            .Returns("");

        AntRepository repo = new(logger, fileReader);

        // Act
        List<AntDto> result = repo.GetAnts();

        // Assert
        Assert.Empty(result);
        Assert.Contains(logger.ReceivedCalls(), call => call.GetMethodInfo().Name.Contains("Log"));
    }

    [Fact]
    public void GetAnts_InvalidJson_ReturnsEmptyListAndLogsError()
    {
        // Arrange
        ILogger<AntRepository> logger = Substitute.For<ILogger<AntRepository>>();
        IFileReader fileReader = Substitute.For<IFileReader>();

        fileReader.Exists(Arg.Any<string>())
            .Returns(true);

        fileReader.ReadAllText(Arg.Any<string>())
            .Returns("invalid json");

        AntRepository repo = new(logger, fileReader);

        // Act
        List<AntDto> result = repo.GetAnts();

        // Assert
        Assert.Empty(result);
        Assert.Contains(logger.ReceivedCalls(), call => call.GetMethodInfo().Name.Contains("Log"));
    }

    [Fact]
    public void GetAnts_ValidJson_ReturnsAntList()
    {
        // Arrange
        ILogger<AntRepository> logger = Substitute.For<ILogger<AntRepository>>();
        IFileReader fileReader = Substitute.For<IFileReader>();

        fileReader.Exists(Arg.Any<string>())
            .Returns(true);

        string json = """
        [
            { 
                "Color": "#FF0000", 
                "HorizontalVelocity": 2, 
                "VerticalVelocity": 2, 
                "Quantity": 1, 
                "Strategy": [] 
            }
        ]
        """;

        fileReader.ReadAllText(Arg.Any<string>())
            .Returns(json);

        AntRepository repo = new(logger, fileReader);

        // Act
        List<AntDto> result = repo.GetAnts();

        // Assert
        Assert.Single(result);
        Assert.Equal("#FF0000", result[0].Color);
    }
}
