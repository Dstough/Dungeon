class IdleAction : Action
{
    public IdleAction()
    {
        speed = 1;
    }
    public override ActionResult perform()
    {       
        return ActionResult.success;
    }
}