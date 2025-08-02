﻿using Ant3Arena.Domain.Strategy;
using System.Drawing;

namespace Ant3Arena.Domain.Entities;

public sealed class AntWhite : Ant
{
    public AntWhite(Bitmap baseImage, Size borders)
        : base(baseImage, borders, new WhiteAntMoveStrategy())
    {
    }

    protected override int VerticalVelocity { get; init; } = 2;
    protected override int HorizontalVelocity { get; init; } = 2;
    protected override string Color { get; init; } = "#FFFFFF";

}
