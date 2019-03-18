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
                    foreach (var actor in level.actors)
                    {
                        while (actor.initiative >= 12)
                        {
                            Action action = new IdleAction();
                            do 
                            {
                                if (quit) break;
                                action = actor.takeTurn();
                            }
                            while (action.perform() == ActionResult.failure);
                            if (quit) break;
                            actor.initiative -= 12;
                        }
                        if (quit) break;
                        actor.initiative += actor.speed;
                    }
                    if (quit) break;
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
