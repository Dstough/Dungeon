using Dungeon.Base;

namespace Dungeon.Actions
{
    class QuitGameAction : Action
    {
        public override ActionResult Perform()
        {
            //TODO: save game here.
            Program.quit = true;
            return ActionResult.failure;
        }
    }
}