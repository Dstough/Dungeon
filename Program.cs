using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Dungeon.Actors;
using Dungeon.Base;
using Dungeon.Graphics;
using Dungeon.World;

static class Program
{
    public static Application WinApp { get; private set; }
    public static Window MainWindow { get; private set; }

    static Thread graphicsThread = new Thread(BuildScreen);
    public static bool quit = false;
    public static List<string> history = new List<string>();
    public static Labyrinth dungeon = new Labyrinth();
    public static Hero hero = new Hero();

    [STAThread]
    static void Main()
    {
        try
        {
            LevelBuilder.DrawBorder();

            graphicsThread.IsBackground = true;
            graphicsThread.Start();

            while (!quit)
                foreach (var level in dungeon.Levels)
                    foreach (var actor in level.Actors)
                    {
                        while (actor.Initiative >= 12)
                        {
                            Dungeon.Actions.Action action;
                            do
                            {
                                action = actor.TakeTurn();
                                if (quit)
                                    return;
                            }
                            while (action.Perform() == ActionResult.failure);
                            actor.Initiative -= 12;
                        }
                        actor.Initiative += actor.Speed;
                    }

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            //TODO: Try to save the game here.
        }
    }

    [STAThread]
    private static void BuildScreen()
    {
        using (var screen = new Screen())
            screen.Run();
    }
}