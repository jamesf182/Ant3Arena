using Ant3Arena.Domain.Entities;
using Ant3Arena.Domain.Enums;
using System.Drawing;

namespace Ant3Arena.Domain.Factory;

public static class AntFactory
{
    public static Ant CreateAnt(AntColorEnum color, Bitmap bitmap, Size size)
    {
        return color switch
        {
            AntColorEnum.Red => new AntRed(bitmap, size),
            AntColorEnum.Yellow => new AntYellow(bitmap, size),
            AntColorEnum.Black => new AntBlack(bitmap, size),
            AntColorEnum.White => new AntWhite(bitmap, size),
            _ => throw new ArgumentException("Unknown ant color")
        };
    }
}

