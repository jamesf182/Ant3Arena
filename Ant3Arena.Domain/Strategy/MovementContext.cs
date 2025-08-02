using Ant3Arena.Domain.Enums;
using System.Drawing;

namespace Ant3Arena.Domain.Strategy;

public record MovementContext(int HorizontalVelocity, int VerticalVelocity, Size Borders, DirectionEnum Direction);

