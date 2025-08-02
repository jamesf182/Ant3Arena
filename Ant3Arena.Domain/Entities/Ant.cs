using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Strategy;
using Ant3Arena.Domain.Utils;
using System.Drawing;

namespace Ant3Arena.Domain.Entities;

public class Ant
{
    public string Color { get; }
    public int HorizontalVelocity { get; }
    public int VerticalVelocity { get; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public DirectionEnum Direction { get; private set; }
    public Bitmap AntImage { get; }

    private readonly IMoveStrategy _moveStrategy;

    public Ant(Bitmap baseImage, Size borders, IMoveStrategy moveStrategy,
               int horizontalVelocity, int verticalVelocity, string colorHex)
    {
        if (horizontalVelocity < 0 || verticalVelocity < 0)
            throw new ArgumentOutOfRangeException("Velocidades devem ser positivas.");

        if (string.IsNullOrWhiteSpace(colorHex))
            throw new ArgumentException("Cor não pode ser vazia.");

        HorizontalVelocity = horizontalVelocity;
        VerticalVelocity = verticalVelocity;
        Color = colorHex;
        _moveStrategy = moveStrategy ?? throw new ArgumentNullException(nameof(moveStrategy));

        Direction = DirectionEnum.LeftDown;
        AntImage = GenerateColoredImage(baseImage, colorHex);
        (X, Y) = GenerateRandomPosition(borders);
    }

    public void Move(Size borders)
    {
        int tempX = X;
        int tempY = Y;

        Direction = _moveStrategy.Move(ref tempX, ref tempY,
            new MovementContext(HorizontalVelocity, VerticalVelocity, borders, Direction));

        X = tempX;
        Y = tempY;
    }

    private static Bitmap GenerateColoredImage(Bitmap baseImage, string colorHex)
    {
        Color newColor = ColorTranslator.FromHtml(colorHex);
        return AntColorizer.ApplyColor(baseImage, newColor);
    }

    private static (int x, int y) GenerateRandomPosition(Size borders)
    {
        Random random = new();
        int x = random.Next(0, borders.Width);
        int y = random.Next(0, borders.Height);
        return (x, y);
    }
}

