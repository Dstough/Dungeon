using System.Drawing;

namespace Dungeon.Objects
{
    class Wall : Item
    {
        public Wall()
        {
            Name = "Wall";
            Sprite = '#';
            ForgroundColor = Color.White;
            IsSolid = true;
        }
    }
}