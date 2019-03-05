using System;
class Hero : Actor
{
    public int lightRadius { get; set; }
    public Hero() : base()
    {
        sprite = '╧';
        lightRadius = 5;
    }
    public override Action takeTurn()
    {
        while(Console.KeyAvailable)
            Console.ReadKey(true);
        var input = Console.ReadKey(true);
        Action action = new RetryAction();

        if (input.Modifiers.HasFlag(ConsoleModifiers.Shift) && input.Key == ConsoleKey.Q)
        {
            action = new QuitGameAction();
        }
        else if (input.Key == ConsoleKey.Spacebar)
        {
            action = new IdleAction();
        }
        else if (input.Key == ConsoleKey.NumPad1 || input.Key == ConsoleKey.End)
        {
            var targetPosition = new Position(this.position.x - 1, this.position.y + 1);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        else if (input.Key == ConsoleKey.NumPad2 || input.Key == ConsoleKey.DownArrow)
        {
            var targetPosition = new Position(this.position.x, this.position.y + 1);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        else if (input.Key == ConsoleKey.NumPad3 || input.Key == ConsoleKey.PageDown)
        {
            var targetPosition = new Position(this.position.x + 1, this.position.y + 1);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        else if (input.Key == ConsoleKey.NumPad4 || input.Key == ConsoleKey.LeftArrow)
        {
            var targetPosition = new Position(this.position.x - 1, this.position.y);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        else if (input.Key == ConsoleKey.NumPad6 || input.Key == ConsoleKey.RightArrow)
        {
            var targetPosition = new Position(this.position.x + 1, this.position.y);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        else if (input.Key == ConsoleKey.NumPad7 || input.Key == ConsoleKey.Home)
        {
            var targetPosition = new Position(this.position.x - 1, this.position.y - 1);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        else if (input.Key == ConsoleKey.NumPad8 || input.Key == ConsoleKey.UpArrow)
        {
            var targetPosition = new Position(this.position.x, this.position.y - 1);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        else if (input.Key == ConsoleKey.NumPad9 || input.Key == ConsoleKey.PageUp)
        {
            var targetPosition = new Position(this.position.x + 1, this.position.y - 1);
            //TODO: check for interposing things here.
            action = new MoveAction(this, targetPosition);
        }
        return action;
    }
}