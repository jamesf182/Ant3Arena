using Ant3Arena.Domain.Enums;

namespace Ant3Arena.Domain.Strategy;

public interface IMoveStrategy
{
    DirectionEnum Move(ref int x, ref int y, MovementContext context);
}

