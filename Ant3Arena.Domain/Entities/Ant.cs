using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Strategy;
using Ant3Arena.Domain.Utils;
using System.Drawing;

namespace Ant3Arena.Domain.Entities;

public abstract class Ant
{
    public int X { get; set; }
    public int Y { get; set; }
    protected DirectionEnum Direction { get; set; }
    protected abstract int VerticalVelocity { get; init; }
    protected abstract int HorizontalVelocity { get; init; }
    protected abstract string Color { get; init; }

    protected Bitmap? antImage;
    public Bitmap AntImage { get { return antImage; } }

    private readonly IMoveStrategy _moveStrategy;

    protected Ant(Bitmap baseImage, Size borders, IMoveStrategy moveStrategy)
    {
        Direction = DirectionEnum.LeftDown;
        Color newColor = ColorTranslator.FromHtml(Color);

        antImage = AntColorizer.ApplyColor(baseImage, newColor);

        Random random = new();
        X = random.Next(0, borders.Width);
        Y = random.Next(0, borders.Height);

        _moveStrategy = moveStrategy;
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

}
