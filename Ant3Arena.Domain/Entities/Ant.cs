using Ant3Arena.Domain.Enums;
using Ant3Arena.Domain.Strategy;
using Ant3Arena.Domain.Utils;
using System.Drawing;

namespace Ant3Arena.Domain.Entities;

public class Ant
{
    public string Color { get; private init; }
    public int HorizontalVelocity { get; private init; }
    public int VerticalVelocity { get; private init; }    
    public int Quantity { get; private init; }
    public string Strategy { get; private init; }

    public int X { get; set; }
    public int Y { get; set; }
    protected DirectionEnum Direction { get; set; }    
    

    protected Bitmap? antImage;
    public Bitmap AntImage => antImage;

    private readonly IMoveStrategy _moveStrategy;

    public Ant(Bitmap baseImage, Size borders, IMoveStrategy moveStrategy,
               int horizontalVelocity, int verticalVelocity, string colorHex)
    {
        Direction = DirectionEnum.LeftDown;
        HorizontalVelocity = horizontalVelocity;
        VerticalVelocity = verticalVelocity;
        Color = colorHex;

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

