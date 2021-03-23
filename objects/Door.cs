using System.Drawing;

namespace Dungeon.Objects
{
    internal class Door : Item
    {
        public Door()
        {
            Sprite = '+';
            ForgroundColor = Color.DarkGray;
        }
    }
}