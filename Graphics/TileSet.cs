using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TileSet
{
    public int Height { get; }
    public int Width { get; }
    public Texture2D Source { get; }
    public Rectangle[] Glyphs { get; }

    public TileSet(Texture2D texture)
    {
        Source = texture;
        Height = texture.Height / 16;
        Width = texture.Width / 16;
        Glyphs = new Rectangle[16 * 16];

        for (int i = 0, x = 0, y = 0; i < 16 * 16; i++)
        {
            if (i != 0 && i % 16 == 0)
            {
                x = 0;
                y += Height;
            }

            Glyphs[i] = new Rectangle(x, y, Height, Width);

            x += Width;
        }
    }
}