using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Domain.Entities;

public sealed class AntRed : Ant
{
    public AntRed(Bitmap baseImage, Size borders) 
        : base(baseImage, borders, new RedAntMoveStrategy())
    {
    }

    protected override int VerticalVelocity { get; init; } = 6;
    protected override int HorizontalVelocity { get; init; } = 6;
    protected override string Color { get; init; } = "#FF0000";
}
