using System.Drawing;

namespace Ant3Arena.Domain.Utils;

public static class AntColorizer
{
    public static Bitmap ApplyColor(Bitmap original, Color targetColor)
    {
        Bitmap bmp = new(original.Width, original.Height);

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                Color pixelColor = original.GetPixel(x, y);

                if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                {
                    bmp.SetPixel(x, y, targetColor);
                }
                else
                {
                    bmp.SetPixel(x, y, pixelColor);
                }
            }
        }

        return bmp;
    }
}
