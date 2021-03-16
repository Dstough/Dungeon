using System.Drawing;
using System;
using System.IO;

public class TileSet
{
    public string Name { get; }
    public int Height { get; }
    public int Width { get; }
    public Bitmap Source { get; }
    public Image[] Glyphs { get; }

    public TileSet(string fileName)
    {
        var data = Path.GetFileNameWithoutExtension(fileName).Split("_");

        Name = data[0];
        Source = new Bitmap(fileName);
        Height = Source.Size.Height / 16;
        Width = Source.Size.Width / 16;
        Glyphs = new Image[16 * 16];

        for (int i = 0, x = 0, y = 0; i < 16 * 16; i++)
        {
            if (i != 0 && i % 16 == 0)
            {
                x = 0;
                y += Height;
            }

            Glyphs[i] = Source.Clone(new Rectangle(x, y, Height, Width), Source.PixelFormat);

            x += Width;
        }
    }
}