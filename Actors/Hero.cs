using Dungeon.Actions;

namespace Dungeon.Actors
{
    class Hero : Actor
    {
        public int LightRadius { get; set; }

        public Hero() : base()
        {
            Sprite = '@';
            LightRadius = 5;
        }
        public override Action TakeTurn()
        {
            Action action = new IdleAction();

            //while (input == null && !Program.quit)
            //{
            //}

            //if (Program.quit || (input.Shift && input.KeyCode == Keys.Q))
            //    action = new QuitGameAction();
            //else if (input.KeyCode == Keys.Space)
            //    action = new IdleAction();
            //else if (input.KeyCode == Keys.NumPad1 || input.KeyCode == Keys.End)
            //{
            //    var targetPosition = new Position(this.position.x - 1, this.position.y + 1);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}
            //else if (input.KeyCode == Keys.NumPad2 || input.KeyCode == Keys.Down)
            //{
            //    var targetPosition = new Position(this.position.x, this.position.y + 1);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}
            //else if (input.KeyCode == Keys.NumPad3 || input.KeyCode == Keys.PageDown)
            //{
            //    var targetPosition = new Position(this.position.x + 1, this.position.y + 1);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}
            //else if (input.KeyCode == Keys.NumPad4 || input.KeyCode == Keys.Left)
            //{
            //    var targetPosition = new Position(this.position.x - 1, this.position.y);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}
            //else if (input.KeyCode == Keys.NumPad6 || input.KeyCode == Keys.Right)
            //{
            //    var targetPosition = new Position(this.position.x + 1, this.position.y);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}
            //else if (input.KeyCode == Keys.NumPad7 || input.KeyCode == Keys.Home)
            //{
            //    var targetPosition = new Position(this.position.x - 1, this.position.y - 1);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}
            //else if (input.KeyCode == Keys.NumPad8 || input.KeyCode == Keys.Up)
            //{
            //    var targetPosition = new Position(this.position.x, this.position.y - 1);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}
            //else if (input.KeyCode == Keys.NumPad9 || input.KeyCode == Keys.PageUp)
            //{
            //    var targetPosition = new Position(this.position.x + 1, this.position.y - 1);
            //    //TODO: check for interposing things here.
            //    action = new MoveAction(this, targetPosition);
            //}

            //input = null;
            return action;
        }
    }
}