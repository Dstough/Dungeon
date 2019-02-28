using System.Collections.Generic;
class Actor : Entity
{
    public int initiative { get; set; }
    public int speed { get; set; }
    public int movementSpeed { get; set; }
    public List<GameObject> inventory { get; set; }

    public Actor() : base()
    {
        inventory = new List<GameObject>();
        speed = Config.defaultSpeed;
        movementSpeed = Config.defaultCreatureMovementSpeed;
        initiative = 0;
    }

    public virtual Action takeTurn()
    {
        return new IdleAction();
    }
}