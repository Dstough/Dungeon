using System.Collections.Generic;
using Dungeon.Actions;
using Dungeon.Base;
using Dungeon.Objects;

namespace Dungeon.Actors
{
    class Actor : Entity
    {
        public bool Ethereal { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int MovementSpeed { get; set; }
        public List<Item> Inventory { get; set; }

        public Actor() : base()
        {
            Inventory = new List<Item>();
            Speed = Config.DefaultSpeed;
            MovementSpeed = Config.DefaultCreatureMovementSpeed;
            Initiative = 0;
            Ethereal = false;
        }

        public virtual Action TakeTurn()
        {
            return new IdleAction();
        }
    }
}