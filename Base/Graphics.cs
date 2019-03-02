using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
class Graphics
{
    public static void drawScreen()
    {
        drawRoom();
        drawHud();
    }

    public static void drawMenu()
    {
    }

    public static void drawRoom()
    {
        var buffer = new StringBuilder();
        for (var y = 0; y < Config.windowHeight; y++)
        {
            for (var x = 0; x < Config.windowWidth; x++)
            {
                var item = Program.dungeon.levels[Program.dungeon.currentLevel].objects.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                var actor = Program.dungeon.levels[Program.dungeon.currentLevel].actors.Where(obj => obj.position.x == x && obj.position.y == y).FirstOrDefault();
                var charToDraw = " ";
                if (actor != null)
                {
                    charToDraw = actor.sprite.ToString();
                    charToDraw = actor.forgroundColor != Color.Empty ? charToDraw.pastel(actor.forgroundColor) : charToDraw;
                    charToDraw = actor.backgroundColor != Color.Empty ? charToDraw.pastelBackGround(actor.backgroundColor) : charToDraw;
                }
                else if (item != null)
                {
                    charToDraw = item.sprite.ToString();
                    charToDraw = item.forgroundColor != Color.Empty ? charToDraw.pastel(actor.forgroundColor) : charToDraw;
                    charToDraw = item.backgroundColor != Color.Empty ? charToDraw.pastelBackGround(actor.backgroundColor) : charToDraw;
                }
                buffer.Append(charToDraw);
            }
        }
        Console.SetCursorPosition(0, 0);
        Console.Write(buffer);
        resizeWindowBuffer();
    }

    public static void drawHud()
    {
        var buffer = new StringBuilder();
        for (int i = 0; i < Config.windowWidth; i++)
        {
            buffer.Append('_');
        }
        buffer.Append("\n");
        buffer.Append(" Player Position: (X:" + (Program.hero.position.x + 1) + ", Y:" + (Program.hero.position.y + 1) + ")\n");
        Console.SetCursorPosition(0, Config.windowHeight);
        Console.Write(buffer);
    }

    public static void resizeWindowBuffer()
    {
        Console.BufferHeight = Config.windowHeight + 5;
        Console.BufferWidth = Config.windowWidth;

        Console.WindowHeight = Config.windowHeight + 5;
        Console.WindowWidth = Config.windowWidth;

        Console.CursorVisible = false;
        Console.Title = "Dungeon";
    }
}