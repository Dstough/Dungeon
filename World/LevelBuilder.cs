using Dungeon.Base;
using Dungeon.Objects;

namespace Dungeon.World
{
    static class LevelBuilder
    {
        public static void DrawBorder()
        {
            for (int x = 0; x < Config.ScreenWidth; x++)
            {
                var topWall = new Wall()
                {
                    Sprite = '─'
                };
                var bottomWall = new Wall()
                {
                    Sprite = '─'
                };

                if (x == 0)
                {
                    topWall.Sprite = '┌';
                    bottomWall.Sprite = '└';
                }

                if (x == Config.ScreenWidth - 1)
                {
                    topWall.Sprite = '┐';
                    bottomWall.Sprite = '┘';
                }

                topWall.Position = new Position(x, 0);
                bottomWall.Position = new Position(x, Config.RoomHeight - 1);
                Program.dungeon.Levels[Program.dungeon.CurrentLevel].Objects.Add(topWall);
                Program.dungeon.Levels[Program.dungeon.CurrentLevel].Objects.Add(bottomWall);
            }
            for (int y = 0; y < Config.RoomHeight; y++)
            {
                var leftWall = new Wall() { Sprite = '│' };
                var rightWall = new Wall() { Sprite = '│' };
                leftWall.Position = new Position(0, y);
                rightWall.Position = new Position(Config.ScreenWidth - 1, y);
                Program.dungeon.Levels[Program.dungeon.CurrentLevel].Objects.Add(leftWall);
                Program.dungeon.Levels[Program.dungeon.CurrentLevel].Objects.Add(rightWall);
            }
        }
    }
}