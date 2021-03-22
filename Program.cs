using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Dungeon.Graphics;

static class Program
{
    public static Application WinApp { get; private set; }
    public static Window MainWindow { get; private set; }

    static Thread graphicsThread = new Thread(buildScreen);
    public static bool quit = false;
    public static List<string> history = new List<string>();
    public static Labyrinth dungeon = new Labyrinth();
    public static Hero hero = new Hero();

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

    [STAThread]
    private static void buildScreen()
    {
        using(var screen = new Screen())
            screen.Run();
    }
}
