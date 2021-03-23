using Dungeon.Base;

namespace Dungeon.Actions
{
    class IdleAction : Action
    {
        public IdleAction()
        {
            Speed = 1;
        }
        public override ActionResult Perform()
        {
            return ActionResult.success;
        }
    }
}