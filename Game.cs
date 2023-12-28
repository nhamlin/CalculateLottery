namespace CalculateLottery;

public class Game(GameName gameName, DateTime formatChange)
{
	public GameName Name { get; set; } = gameName;
	public DateTime LastFormatChange { get; set; } = formatChange;
}

public enum GameName
{
	MegaMillions,
	PowerBall
}