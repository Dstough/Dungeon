using System;

namespace Dungeon.Base
{
    public static class Extensions
    {
        public static string Trim(this string input, int start = 0, int length = Config.ScreenWidth)
        {
            if (input.Length > length)
                input = input.Substring(0, length);

            return input;
        }

        public static double DistanceTo(this Position startingPosition, Position targetPosition)
        {
            var distance = new Position(Math.Abs(targetPosition.X - startingPosition.X), Math.Abs(targetPosition.Y - startingPosition.Y));
            var steps = 0.0;

            while (distance.X > 0 || distance.Y > 0)
            {
                if (distance.X > 0 && distance.Y > 0)
                {
                    steps += 1.5;
                    distance.X -= 1;
                    distance.Y -= 1;
                }
                else if (distance.X > 0)
                {
                    distance.X -= 1;
                    steps += 1.0;
                }
                else if (distance.Y > 0)
                {
                    distance.Y -= 1;
                    steps += 1.0;
                }
            }

            return steps;
        }
    }
}