using System;
class MoveAction : Action
{
    Position targetLocation { get; set; }
    Actor self { get; set; }

    public MoveAction(Actor _self, Position _targetLocation)
    {
        targetLocation = _targetLocation;
        self = _self;
        speed = _self.movementSpeed;
        redrawScreen = true;
    }
    public override ActionResult perform()
    {
        self.position = new Position(targetLocation.x, targetLocation.y);
        return ActionResult.success;
    }
}