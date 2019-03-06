using System;
class Config
{
    #region system

    public static int screenWidth { get; } = 80;
    public static int roomHeight { get; } = 20;
    public static int messageHeight {get;} = 2;
    public static int hudHeight {get;} = 3;
    public static int defaultSpeed { get; } = 10;
    public static bool defaultRedrawScreen { get; } = false;
    public static int defaultCreatureMovementSpeed { get; } = 5;

    #endregion

    #region user

    #endregion
}