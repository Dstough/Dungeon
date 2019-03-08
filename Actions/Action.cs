abstract class Action
{
    public int speed { get; set; } = Config.defaultSpeed;
    abstract public ActionResult perform();
}