using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

static class Program
{
    static Thread graphicsThread = new Thread(buildScreen);
    public static bool quit = false;
    public static List<string> history = new List<string>();
    public static Dungeon dungeon = new Dungeon();
    public static Hero hero = new Hero();
    public static TileSet tileSet = new TileSet("Runeset_24x24.png");

    [STAThread]
    static void Main()
    {
        try
        {
            LevelBuilder.drawBorder();

            graphicsThread.IsBackground = true;
            graphicsThread.Start();

            while (!quit)
                foreach (var level in dungeon.levels)
                    foreach (var actor in level.actors)
                    {
                        while (actor.initiative >= 12)
                        {
                            Action action;
                            do
                            {
                                action = actor.takeTurn();
                                if (quit)
                                    return;
                            }
                            while (action.perform() == ActionResult.failure);
                            actor.initiative -= 12;
                        }
                        actor.initiative += actor.speed;
                    }

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            //TODO: Try to save the game here.
        }
    }

    private static void buildScreen()
    {
        Application.Run(new Screen());
    }
}
