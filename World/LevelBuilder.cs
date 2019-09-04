static class LevelBuilder
{
    public static void drawBorder()
    {
        for (int x = 0; x < Config.screenWidth; x++)
        {
            var topWall = new Wall()
            {
                sprite = '─'
            };
            var bottomWall = new Wall()
            {
                sprite = '─'
            };

            if (x == 0)
            {
                topWall.sprite = '┌';
                bottomWall.sprite = '└';
            }

            if(x == Config.screenWidth-1)
            {
                topWall.sprite = '┐';
                bottomWall.sprite = '┘';
            }

            topWall.position = new Position(x, 0);
            bottomWall.position = new Position(x, Config.roomHeight - 1);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(topWall);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(bottomWall);
        }
        for (int y = 0; y < Config.roomHeight; y++)
        {
            var leftWall = new Wall()
            {
                sprite = '│'
            };
            var rightWall = new Wall()
            {
                sprite = '│'
            };
            leftWall.position = new Position(0, y);
            rightWall.position = new Position(Config.screenWidth - 1, y);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(leftWall);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(rightWall);
        }
    }
}