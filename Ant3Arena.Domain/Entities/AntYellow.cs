using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Domain.Entities;

public sealed class AntYellow : Ant
{
    public AntYellow(Bitmap baseImage, Size borders)
        : base(baseImage, borders, new YellowAntMoveStrategy())
    {
    }

    protected override int VerticalVelocity { get; init; } = 4;
    protected override int HorizontalVelocity { get; init; } = 4;
    protected override string Color { get; init; } = "#FFFF00";
}
