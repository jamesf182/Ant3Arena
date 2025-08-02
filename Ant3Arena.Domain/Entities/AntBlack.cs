using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Domain.Entities;

public sealed class AntBlack : Ant
{
    public AntBlack(Bitmap baseImage, Size borders)
        : base(baseImage, borders, new BlackAntMoveStrategy())
    {
    }

    protected override int VerticalVelocity { get; init; } = 6;
    protected override int HorizontalVelocity { get; init; } = 2;
    protected override string Color { get; init; } = "#000000";
}
