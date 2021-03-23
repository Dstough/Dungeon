using System.Collections.Generic;

namespace Dungeon.World
{
    class Labyrinth
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Floor> Levels { get; set; }
        public int CurrentLevel { get; set; }
        public Labyrinth()
        {
            CurrentLevel = 0;
            Levels = new List<Floor> { new Floor() };
            Name = "The Dungeon";
            Description = "A long forgotton ruin lost to time.";
        }
    }
}