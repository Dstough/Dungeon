using Dungeon.Base;

namespace Dungeon.Actions
{
    abstract class Action
    {
        public int Speed { get; set; } = Config.DefaultSpeed;
        abstract public ActionResult Perform();
    }
}