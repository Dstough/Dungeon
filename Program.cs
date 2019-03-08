using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Program
{
    public static bool quit = false;
    public static List<string> history = new List<string>();
    public static Dungeon dungeon = new Dungeon();
    public static Hero hero = new Hero();

    [STAThread]
    static void Main()
    {
        try
        {
            Application.Run(new Screen());
            //dungeon.levels[dungeon.currentLevel].actors.Add(hero);
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
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            //TODO: Dump the dungeon var to a recoverable file.
        }
    }
}
