using System.Linq;
class MoveAction : Action
{
    Position targetLocation { get; set; }
    Actor self { get; set; }

    public MoveAction(Actor _self, Position _targetLocation)
    {
        targetLocation = _targetLocation;
        self = _self;
        speed = _self.movementSpeed;
    }
    public override ActionResult perform()
    {
        if (Program.dungeon.levels[Program.dungeon.currentLevel].objects.Where(o => o.position.x == targetLocation.x && o.position.y == targetLocation.y && o.name == "Wall").Count() == 0)
            self.position = new Position(targetLocation.x, targetLocation.y);
        else
            ;
        return ActionResult.success;
    }
}