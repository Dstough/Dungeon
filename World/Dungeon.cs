using System.Collections.Generic;
class Dungeon
{
    public string name { get; set; }
    public string description { get; set; }
    public List<Floor> levels { get; set; }
    public Floor currentLevel {get;set;}
    public Dungeon()
    {
        levels = new List<Floor>();
        name = "test";
        description = "my first dungeon";
    }
}