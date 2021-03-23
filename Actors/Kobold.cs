using System.Drawing;

namespace Dungeon.Actors
{ 
    class Kobold : Actor
    {
        public Kobold() : base()
        {
            Sprite = 'k';
            ForgroundColor = Color.Yellow;
        }
    }
}