using System;
public static class Extensions
{
    public static string trim(this string input, int start = 0, int length = Config.screenWidth)
    {
        if (input.Length > length)
            input = input.Substring(0, length);

        return input;
    }

    public static double DistanceTo(this Position startingPosition, Position targetPosition)
    {
        var distance = new Position(Math.Abs(targetPosition.x - startingPosition.x), Math.Abs(targetPosition.y - startingPosition.y));
        var steps = 0.0;

        while (distance.x > 0 || distance.y > 0)
        {
            if (distance.x > 0 && distance.y > 0)
            {
                steps += 1.5;
                distance.x -= 1;
                distance.y -= 1;
            }
            else if (distance.x > 0)
            {
                distance.x -= 1;
                steps += 1.0;
            }
            else if (distance.y > 0)
            {
                distance.y -= 1;
                steps += 1.0;
            }
        }

        return steps;
    }
}