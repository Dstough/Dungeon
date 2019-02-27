using System.Collections.Generic;
class Actor : Entity
{
    public int initiative { get; set; }
    public int speed { get; set; }
    public List<GameObject> inventory { get; set; }

    public Actor() : base()
    {
        inventory = new List<GameObject>();
        speed = 10;
        initiative = 0;
    }

    public Action takeTurn()
    {
        return new IdleAction();
    }
}