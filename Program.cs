using System;

class Program
{
    public static bool quit = false;

    static void Main(string[] args)
    {
        var dungeon = new Dungeon();

        while (!quit)
        {
            foreach (var actor in dungeon.currentLevel.actors)
            {
                actor.initiative++;
                if (actor.initiative == actor.speed)
                {
                    actor.takeTurn().perform();
                }
            }
        }
    }
}