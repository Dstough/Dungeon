using System.Collections.Generic;
class Dungeon
{
    public string name { get; set; }
    public string description { get; set; }
    public List<Floor> levels { get; set; }
    public int currentLevel { get; set; }
    public Dungeon()
    {
        currentLevel = 0;
        levels = new List<Floor>();
        levels.Add(new Floor());
        name = "The Dungeon";
        description = "A long forgotton ruin lost to time.";
    }
}