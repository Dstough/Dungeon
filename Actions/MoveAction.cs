using Dungeon.Actors;
using Dungeon.Base;
using System.Linq;

namespace Dungeon.Actions
{
    class MoveAction : Action
    {
        Position TargetLocation { get; set; }
        Actor Self { get; set; }

        public MoveAction(Actor _self, Position _targetLocation)
        {
            TargetLocation = _targetLocation;
            Self = _self;
            Speed = _self.MovementSpeed;
        }
        public override ActionResult Perform()
        {
            if (Self.Ethereal || Program.dungeon.Levels[Program.dungeon.CurrentLevel].Objects.Where(o => o.Position.X == TargetLocation.X && o.Position.Y == TargetLocation.Y && o.IsSolid).Count() == 0)
                Self.Position = new Position(TargetLocation.X, TargetLocation.Y);
            else
                ;
            return ActionResult.success;
        }
    }
}