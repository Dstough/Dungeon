using System.Collections.Generic;
class Floor
{
    public int level { get; set; }
    public int height { get; set; }
    public int width { get; set; }
    public List<Item> objects { get; set; }
    public List<Actor> actors { get; set; }
    public Floor(int _level) : this()
    {
        level = _level;
    }
    public Floor()
    {
        height = Config.windowHeight;
        width = Config.windowWidth;
        objects = new List<Item>();
        actors = new List<Actor>();
    }
}