public static class Extensions
{
    public static string trim(this string input, int start = 0, int length = Config.screenWidth)
    {
        if (input.Length > length)
            input = input.Substring(0, length);
        return input;
    }
}