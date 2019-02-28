using System;
class Hero : Actor
{
    public Hero() : base()
    {
        sprite = '@'; 
    }
    public override Action takeTurn()
    {
        var input = Console.ReadKey(true);
        Action action = new RetryAction();

        if(input.Modifiers.HasFlag(ConsoleModifiers.Shift) && input.Key == ConsoleKey.Q)
            action = new QuitGameAction();
        
        else if(input.Key == ConsoleKey.Spacebar)
            action = new IdleAction();
        
        return action; 
    }
}