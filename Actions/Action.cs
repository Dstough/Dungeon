abstract class Action
{
    public int speed { get; set; } = Config.defaultSpeed;
    public bool redrawScreen {get;set; } = Config.defaultRedrawScreen;
    abstract public ActionResult perform();
}