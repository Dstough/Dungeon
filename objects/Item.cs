using Dungeon.Base;

namespace Dungeon.Objects
{
    abstract class Item : Entity
    {
        public bool IsSolid { get; set; } = false;
    }
}