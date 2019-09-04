class RetryAction : Action
{
    public override ActionResult perform()
    {
        return ActionResult.failure;
    }
}