using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
class Screen
{
    public static void drawScreen()
    {
        resizeWindowBuffer();
        drawMessage();
        drawRoom();
        drawHud();
    }

    public static void drawMessage()
    {
        var buffer = new StringBuilder();
        buffer.Append("".fillLine());
        for (var line = 1; line < Config.messageHeight; line++)
            buffer.Append("".fillLine('╧'));

        Console.SetCursorPosition(0, 0);
        Console.Write(buffer);
    }

    public static void drawRoom()
    {
        var buffer = new StringBuilder();
        for (var y = 0; y < Config.roomHeight; y++)
        {
            for (var x = 0; x < Config.screenWidth; x++)
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
        Console.SetCursorPosition(0, Config.messageHeight);
        Console.Write(buffer);
    }

    public static void drawHud()
    {
        var buffer = new StringBuilder();
        buffer.Append("".fillLine(' '));
        for (var line = 1; line < Config.hudHeight; line++)
            buffer.Append("".fillLine());

        Console.SetCursorPosition(0, Config.messageHeight + Config.roomHeight);
        Console.Write(buffer);
    }

    public static void resizeWindowBuffer()
    {
        Console.CursorVisible = false;
        Console.Title = "Dungeon";

        Console.BufferHeight = Config.messageHeight + Config.roomHeight + Config.hudHeight;
        Console.BufferWidth = Config.screenWidth;
    }
}