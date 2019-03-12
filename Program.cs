using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

static class Program
{
    static Thread graphicsThread = new Thread(buildScreen);
    public static bool quit = false;
    public static List<string> history = new List<string>();
    public static Dungeon dungeon = new Dungeon();
    public static Hero hero = new Hero();

    [STAThread]
    static void Main()
    {
        try
        {
            graphicsThread.IsBackground = true;
            graphicsThread.Start();

            dungeon.levels[dungeon.currentLevel].actors.Add(hero);

            while (!quit)
            {
                foreach (var level in dungeon.levels)
                {
                    if (quit)
                    {
                        break;
                    }
                    foreach (var actor in level.actors)
                    {
                        if (quit)
                        {
                            break;
                        }
                        actor.initiative++;
                        if (actor.initiative >= actor.speed)
                        {
                            Action action;
                            do
                            {
                                if (quit)
                                {
                                    break;
                                }
                                action = actor.takeTurn();
                            }
                            while (action.perform() == ActionResult.retry);
                            actor.initiative -= action.speed;
                        }
                    }
                }
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
