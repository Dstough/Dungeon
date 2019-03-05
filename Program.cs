using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static bool quit = false;
    public static List<string> history = new List<string>();
    public static Dungeon dungeon = new Dungeon();
    public static Hero hero = new Hero();

    static void Main(string[] args)
    {
        try
        {
            //TODO: Load configuration file.
            //TODO: Generate first level.
            dungeon.levels[dungeon.currentLevel].actors.Add(hero);

            Screen.drawScreen();

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
                        }
                    }
                }
                Screen.drawScreen();
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            //TODO: Dump the dungeon var to a recoverable file.
        }
        Console.Write("\n Press any key to exit...");
        Console.ReadKey();
    }
}