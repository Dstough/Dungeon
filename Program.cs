using System;
using System.Text;
using System.Linq;

class Program
{
    public static bool quit = false;
    public static Dungeon dungeon = new Dungeon();
    public static Hero hero = new Hero();
    static void Main(string[] args)
    {
        try
        {
            //TODO: Figure out how to size the window and text buffer.
            Console.CursorVisible = false;

            //TODO: Load configuration file.
            //TODO: Generate first level.
            dungeon.levels[dungeon.currentLevel].actors.Add(hero);
            drawFloor();

            while (!quit)
            {
                foreach (var level in dungeon.levels)
                {
                    foreach (var actor in level.actors)
                    {
                        actor.initiative++;
                        if (actor.initiative >= actor.speed)
                        {
                            Action action;
                            do action = actor.takeTurn();
                            while (action.perform() == ActionResult.retry);
                            actor.initiative -= action.speed;
                            drawFloor();
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            //TODO: Dump the dungeon var to a recoverable file.
        }
    }

    public static void drawFloor()
    {
        var screenBuffer = new StringBuilder();
        for (var row = 0; row < Config.windowHeight; row++)
        {
            for (var col = 0; col < Config.windowWidth; col++)
            {
                var item = dungeon.levels[dungeon.currentLevel].objects.Where(obj => obj.position.x == row && obj.position.y == col).FirstOrDefault();
                var actor = dungeon.levels[dungeon.currentLevel].actors.Where(obj => obj.position.x == row && obj.position.y == col).FirstOrDefault();
                var charToDraw = actor?.sprite ?? item?.sprite ?? ' ';
                screenBuffer.Append(charToDraw);
            }
            screenBuffer.Append(Environment.NewLine);
        }
        Console.Clear();
        Console.Write(screenBuffer.ToString());
    }
}