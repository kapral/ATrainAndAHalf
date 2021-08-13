public class GameSettings
{
    public static GameSettings Instance { get; } = new GameSettings();

    public long MapWidth { get; } = 16;

    public long MapHeight { get; } = 10;
}
