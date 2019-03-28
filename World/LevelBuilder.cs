static class LevelBuilder
{
    public static void drawBorder()
    {
        for (int x = 0; x < Config.screenWidth; x++)
        {
            var topWall = new Wall();
            var bottomWall = new Wall();
            topWall.position = new Position(x, 0);
            bottomWall.position = new Position(x, Config.roomHeight - 1);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(topWall);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(bottomWall);
        }
        for (int y = 0; y < Config.roomHeight; y++)
        {
            var leftWall = new Wall();
            var rightWall = new Wall();
            leftWall.position = new Position(0, y);
            rightWall.position = new Position(Config.screenWidth - 1, y);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(leftWall);
            Program.dungeon.levels[Program.dungeon.currentLevel].objects.Add(rightWall);
        }
    }
}