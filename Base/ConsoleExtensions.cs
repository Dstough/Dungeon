/*
    All credit and thanks due to Github user silkfire: https://github.com/silkfire/Pastel
    I would not have been way harder to add colors to the game without this
    Thank you so much for posting this code.

    Copyright (c) 2018 Gabriel Bider

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

public static class ConsoleExtensions
{

    static ConsoleExtensions()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            var enable = GetConsoleMode(iStdOut, out var outConsoleMode) && SetConsoleMode(iStdOut, outConsoleMode | ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN);
        }
    }

    private const int STD_OUTPUT_HANDLE = -11;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
    private const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;

    [DllImport("kernel32.dll")]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll")]
    public static extern uint GetLastError();

    /// <summary>
    /// Returns a string wrapped in an ANSI foreground color code using the specified color.
    /// </summary>
    /// <param name="input">The string to color.</param>
    /// <param name="color">The color to use on the specified string.</param>
    public static string pastel(this string input, Color color)
    {
        return $"\u001b[38;2;{color.R};{color.G};{color.B}m{input}\u001b[0m";
    }

    /// <summary>
    /// Returns a string wrapped in an ANSI foreground color code using the specified color.
    /// </summary>
    /// <param name="input">The string to color.</param>
    /// <param name="hexColor">The color to use on the specified string.<para>Supported format: [#]RRGGBB.</para></param>
    public static string pastel(this string input, string hexColor)
    {
        var color = Color.FromArgb(int.Parse(hexColor.Replace("#", ""), NumberStyles.HexNumber));

        return pastel(input, color);
    }
    /// <summary>
    /// Returns a string wrapped in an ANSI background color code using the specified color.
    /// </summary>
    /// <param name="input">The string to color.</param>
    /// <param name="color">The color to use on the specified string.</param>
    public static string pastelBackGround(this string input, Color color)
    {
        return $"\u001b[48;2;{color.R};{color.G};{color.B}m{input}\u001b[0m";
    }
    /// <summary>
    /// Returns a string wrapped in an ANSI background color code using the specified color.
    /// </summary>
    /// <param name="input">The string to color.</param>
    /// <param name="hexColor">The color to use on the specified string.<para>Supported format: [#]RRGGBB.</para></param>
    public static string pastelBackGround(this string input, string hexColor)
    {
        var color = Color.FromArgb(int.Parse(hexColor.Replace("#", ""), NumberStyles.HexNumber));
        return pastelBackGround(input, color);
    }
}