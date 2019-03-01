using System;
using System.Linq;
using System.Text;
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
                var charToDraw = actor?.sprite.ToString().pastelBackGround(actor.backgroundColor).pastel(actor.forgroundColor) ?? item?.sprite.ToString().pastelBackGround(item.backgroundColor).pastel(item.forgroundColor) ?? " ";
                buffer.Append(charToDraw);
            }
        }
        Console.SetCursorPosition(0, 0);
        Console.Write(buffer);
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
        Console.WindowHeight = Config.windowHeight + 5;
        Console.WindowWidth = Config.windowWidth;
        Console.BufferHeight = Config.windowHeight + 5;
        Console.BufferWidth = Config.windowWidth;
        Console.CursorVisible = false;
    }
}