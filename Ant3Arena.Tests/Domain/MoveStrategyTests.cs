using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Tests.Domain;

public class MoveStrategyTests
{
    [Fact]
    public void Move_ShouldNotChangePosition_WhenStrategyIsNull()
    {
        // Arrange
        List<DirectionStrategyDto> strategies = [];
        MoveStrategy moveStrategy = new(strategies);

        int x = 5, y = 5;
        MovementContext context = new(1, 1, new Size(10, 10), DirectionEnum.LeftUp);

        // Act
        DirectionEnum result = moveStrategy.Move(ref x, ref y, context);

        // Assert
        Assert.Equal(5, x);
        Assert.Equal(5, y);
        Assert.Equal(DirectionEnum.LeftUp, result);
    }

    [Fact]
    public void Move_ShouldApplyMovementAndReturnSameDirection_WhenNoConditionMatches()
    {
        // Arrange
        List<DirectionStrategyDto> strategies = [
            new DirectionStrategyDto
            {
                Direction = DirectionEnum.LeftUp,
                X = AxisOperation.Decrease,
                Y = AxisOperation.Decrease,
                NextDirection = [
                    new NextDirectionDto { Condition = "x > 10 AND y > 10", Direction = DirectionEnum.RightDown }
                ]
            }
        ];

        MoveStrategy moveStrategy = new(strategies);

        int x = 10, y = 10;
        MovementContext context = new(2, 2, new Size(1000, 1000), DirectionEnum.LeftUp);

        // Act
        DirectionEnum result = moveStrategy.Move(ref x, ref y, context);

        // Assert
        Assert.Equal(8, x);
        Assert.Equal(8, y);
        Assert.Equal(DirectionEnum.LeftUp, result);
    }

    [Fact]
    public void Move_ShouldApplyMovementAndChangeDirection_WhenConditionMatches()
    {
        // Arrange
        List<DirectionStrategyDto> strategies = [
            new DirectionStrategyDto
            {
                Direction = DirectionEnum.LeftUp,
                X = AxisOperation.Decrease,
                Y = AxisOperation.Decrease,
                NextDirection = [
                    new NextDirectionDto { Condition = "x < 10 AND y < 10", Direction = DirectionEnum.RightDown }
                ]
            }
        ];

        MoveStrategy moveStrategy = new(strategies);

        int x = 11, y = 11;
        MovementContext context = new(2, 2, new Size(1000, 1000), DirectionEnum.LeftUp);

        // Act
        DirectionEnum result = moveStrategy.Move(ref x, ref y, context);

        // Assert
        Assert.Equal(9, x); 
        Assert.Equal(9, y);
        Assert.Equal(DirectionEnum.RightDown, result);
    }

    [Fact]
    public void Move_ShouldEvaluateConditionWithBorders_WhenConditionUsesContextBorders()
    {
        // Arrange
        List<DirectionStrategyDto> strategies = [
            new DirectionStrategyDto
            {
                Direction = DirectionEnum.LeftDown,
                X = AxisOperation.Decrease,
                Y = AxisOperation.Increase,
                NextDirection = [
                    new NextDirectionDto 
                    { 
                        Condition = "y > Height", 
                        Direction = DirectionEnum.LeftUp 
                    }
                ]
            }
        ];

        MoveStrategy moveStrategy = new(strategies);

        int x = 5, y = 9;
        MovementContext context = new(2, 2, new Size(10, 10), DirectionEnum.LeftDown);

        // Act
        DirectionEnum result = moveStrategy.Move(ref x, ref y, context);

        // Assert
        Assert.Equal(3, x);
        Assert.Equal(11, y);
        Assert.Equal(DirectionEnum.LeftUp, result);
    }
}

