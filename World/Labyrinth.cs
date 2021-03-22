using System.Collections.Generic;
class Labyrinth
{
    public string name { get; set; }
    public string description { get; set; }
    public List<Floor> levels { get; set; }
    public int currentLevel { get; set; }
    public Labyrinth()
    {
        currentLevel = 0;
        levels = new List<Floor>
        {
            new Floor()
        };
        name = "The Dungeon";
        description = "A long forgotton ruin lost to time.";
    }
}