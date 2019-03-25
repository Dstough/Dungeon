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
            for (int x = 0; x < Config.screenWidth; x++)
            {
                var topWall = new Wall();
                var bottomWall = new Wall();
                topWall.position = new Position(x, 0);
                bottomWall.position = new Position(x, Config.roomHeight-1);
                dungeon.levels[dungeon.currentLevel].objects.Add(topWall);
                dungeon.levels[dungeon.currentLevel].objects.Add(bottomWall);
            }

            for(int y = 0; y < Config.roomHeight; y++)
            {
                var leftWall = new Wall();
                var rightWall = new Wall();
                leftWall.position = new Position(0, y);
                rightWall.position = new Position(Config.screenWidth-1, y);
                dungeon.levels[dungeon.currentLevel].objects.Add(leftWall);
                dungeon.levels[dungeon.currentLevel].objects.Add(rightWall);
            }


            dungeon.levels[dungeon.currentLevel].actors.Add(hero);

            graphicsThread.IsBackground = true;
            graphicsThread.Start();

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
                                action = actor.takeTurn();
                                if (quit) return;
                            }
                            while (action.perform() == ActionResult.failure);
                            actor.initiative -= 12;
                        }
                        actor.initiative += actor.speed;
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
