using Dungeon.Base;

namespace Dungeon.Actions
{
    class RetryAction : Action
    {
        public override ActionResult Perform()
        {
            return ActionResult.failure;
        }
    }
}