class QuitGameAction : Action
{
    public override ActionResult perform()
    {       
        //TODO: save game here.
        Program.quit = true;
        return ActionResult.retry;
    }
}