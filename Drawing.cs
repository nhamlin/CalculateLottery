using CsvHelper.Configuration.Attributes;

namespace CalculateLottery;

public class Drawing
{
	public DateTime DrawingDate { get; set; }
	public int[]? Numbers { get; set; }
	public int BigNumber { get; set; }
	public Game GameName { get; set; }
	public int Multiplier { get; set; }
	public double Jackpot { get; set; }
}

public class DrawingRaw
{
	[Index(0)] public string Game { get; set; } = string.Empty;

	[Index(1)] public int Month { get; set; }

	[Index(2)] public int Day { get; set; }

	[Index(3)] public int Year { get; set; }

	[Index(4)] public int Num1 { get; set; }

	[Index(5)] public int Num2 { get; set; }

	[Index(6)] public int Num3 { get; set; }

	[Index(7)] public int Num4 { get; set; }

	[Index(8)] public int Num5 { get; set; }

	[Index(9)] public int MegaBall { get; set; }

	[Index(10)] public int? Multiplier { get; set; }
}