﻿using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Enums;
using System.Data;
using System.Drawing;

namespace Ant3Arena.Domain.Strategy;

public class MoveStrategy : IMoveStrategy
{
    private readonly List<DirectionStrategyDto> _directionStrategies;

    public MoveStrategy(List<DirectionStrategyDto> directionStrategies)
    {
        _directionStrategies = directionStrategies;
    }

    public DirectionEnum Move(ref int x, ref int y, MovementContext context)
    {
        DirectionStrategyDto? current = _directionStrategies.FirstOrDefault(s => s.Direction == context.Direction);

        if (current == null)
            return context.Direction;

        ApplyMovement(current, ref x, ref y, context);

        return EvaluateNextDirection(current, x, y, context.Borders) ?? context.Direction;
    }

    private static void ApplyMovement(DirectionStrategyDto strategy, ref int x, ref int y, MovementContext context)
    {
        if (strategy.X == AxisOperation.Increase)
            x += context.HorizontalVelocity;
        else if (strategy.X == AxisOperation.Decrease)
            x -= context.HorizontalVelocity;

        if (strategy.Y == AxisOperation.Increase)
            y += context.VerticalVelocity;
        else if (strategy.Y == AxisOperation.Decrease)
            y -= context.VerticalVelocity;
    }

    private static DirectionEnum? EvaluateNextDirection(DirectionStrategyDto strategy, int x, int y, Size borders)
    {
        foreach (NextDirectionDto next in strategy.NextDirection)
        {
            if (EvaluateCondition(next.Condition, x, y, borders))
                return next.Direction;
        }

        return null;
    }

    private static bool EvaluateCondition(string condition, int x, int y, Size borders)
    {
        string resolved = ResolveConditionVariables(condition, borders);
        resolved = resolved.Replace("x", x.ToString()).Replace("y", y.ToString());

        object result = new DataTable().Compute(resolved, "");
        return Convert.ToBoolean(result);
    }

    private static string ResolveConditionVariables(string condition, Size borders)
    {
        return condition
            .Replace("Height", borders.Height.ToString())
            .Replace("Width", borders.Width.ToString())
            .Replace("&&", "AND")
            .Replace("||", "OR")
            .Trim();
    }
}