using System;
class MoveAction : Action
{
    Position targetLocation { get; set; }
    Entity self { get; set; }

    public MoveAction(Entity _self, Position _targetLocation)
    {
        targetLocation = _targetLocation;
        self = _self;
    }
    public override ActionResult perform()
    {
        self.position = new Position(targetLocation.x, targetLocation.y);
        return ActionResult.success;
    }
}