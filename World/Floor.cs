using Dungeon.Actors;
using Dungeon.Base;
using Dungeon.Objects;
using System.Collections.Generic;

namespace Dungeon.World
{
    class Floor
    {
        public int Level { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Item> Objects { get; set; }
        public List<Actor> Actors { get; set; }
        
        public Floor(int _level) : this()
        {
            Level = _level;
        }
        
        public Floor()
        {
            Height = Config.RoomHeight;
            Width = Config.ScreenWidth;
            Objects = new List<Item>();
            Actors = new List<Actor>();
        }
    }
}