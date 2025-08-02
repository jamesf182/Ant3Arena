using Ant3Arena.Domain.Enums;

namespace Ant3Arena.Domain.Strategy;

public class BlackAntMoveStrategy : IMoveStrategy
{
    public DirectionEnum Move(ref int x, ref int y, MovementContext context)
    {
        return context.Direction switch
        {
            DirectionEnum.LeftUp => MoveLeftUp(ref x, ref y, context),
            DirectionEnum.LeftDown => MoveLeftDown(ref x, ref y, context),
            DirectionEnum.RightUp => MoveRightUp(ref x, ref y, context),
            DirectionEnum.RightDown => MoveRightDown(ref x, ref y, context),
            _ => context.Direction
        };
    }

    private static DirectionEnum MoveLeftUp(ref int x, ref int y, MovementContext context)
    {
        x -= context.HorizontalVelocity;
        y -= context.VerticalVelocity;

        if (x < 0 && y < 500)
            return DirectionEnum.RightDown;
        else if (x < 0)
            return DirectionEnum.RightUp;
        else if (y < 500)
            return DirectionEnum.LeftDown;

        return DirectionEnum.LeftUp;
    }

    private static DirectionEnum MoveLeftDown(ref int x, ref int y, MovementContext context)
    {
        x -= context.HorizontalVelocity;
        y += context.VerticalVelocity;

        if (x < 0 && y > context.Borders.Height)
            return DirectionEnum.RightUp;
        else if (x < 0)
            return DirectionEnum.RightDown;
        else if (y > context.Borders.Height)
            return DirectionEnum.LeftUp;

        return DirectionEnum.LeftDown;
    }

    private static DirectionEnum MoveRightUp(ref int x, ref int y, MovementContext context)
    {
        x += context.HorizontalVelocity;
        y -= context.VerticalVelocity;

        if (x > context.Borders.Width && y < 500)
            return DirectionEnum.LeftDown;
        else if (x > context.Borders.Width)
            return DirectionEnum.LeftUp;
        else if (y < 500)
            return DirectionEnum.RightDown;

        return DirectionEnum.RightUp;
    }

    private static DirectionEnum MoveRightDown(ref int x, ref int y, MovementContext context)
    {
        x += context.HorizontalVelocity;
        y += context.VerticalVelocity;

        if (x > context.Borders.Width && y > context.Borders.Height)
            return DirectionEnum.LeftUp;
        else if (x > context.Borders.Width)
            return DirectionEnum.LeftDown;
        else if (y > context.Borders.Height)
            return DirectionEnum.RightUp;

        return DirectionEnum.RightDown;
    }
}


