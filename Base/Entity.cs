using System.Drawing;

namespace Dungeon.Base
{
    class Entity
    {
        public Position Position { get; set; }
        public char Sprite { get; set; }
        public Color ForgroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Entity()
        {
            Position = new Position(40, 10);
            ForgroundColor = Color.White;
            BackgroundColor = Color.Empty;
            Sprite = ' ';
            Name = "";
            Description = "";
        }
    }
}