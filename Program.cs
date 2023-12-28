namespace CalculateLottery;

public class Program
{
	public static void Main(string[] args)
	{
		//var filename = @"Data\megamillions.csv";
		var goBackTo = new DateTime(2015, 10, 04);
		foreach (var game in new[] { Game.MegaMillions, Game.PowerBall })
			//foreach (var game in new[] { Game.PowerBall })
		{
			var filename = $@"Data\{game.ToString().ToLower()}.csv";
			var drawnNumbers = ReadPreviousNumbers.Initialize(filename, game);
			var allWhiteBalls = GetAllWhiteBalls(drawnNumbers, goBackTo);
			var allMegaBalls = GetAllMegaBalls(drawnNumbers, goBackTo);
			var top5 = allWhiteBalls.Take(5).OrderBy(x => x.Value);

			Console.WriteLine();
			Console.WriteLine($"For {game.ToString()}");
			Console.Write(string.Join(",", top5.Select(x => x.Value)));
			Console.Write("...");
			Console.Write(allMegaBalls.First().Value);
			Console.WriteLine();
		}
	}

	private static IOrderedEnumerable<dynamic> GetAllMegaBalls(IList<Drawing> drawnNumbers, DateTime goBackTo)
	{
		var allMegaBalls = drawnNumbers
			.Where(x => x.DrawingDate >= goBackTo)
			.Select(x => x.BigNumber)
			.GroupBy(g => g)
			.Select(g => new { Value = g.Key, Count = g.Count() })
			.OrderByDescending(x => x.Count)
			.ThenBy(x => x.Value);
		return allMegaBalls;
	}

	private static IOrderedEnumerable<dynamic> GetAllWhiteBalls(IList<Drawing> drawnNumbers, DateTime goBackTo)
	{
		var allWhiteBalls = drawnNumbers
			.Where(x => x.DrawingDate >= goBackTo)
			.SelectMany(x => x.Numbers!)
			.GroupBy(g => g)
			.Select(g => new { Value = g.Key, Count = g.Count() })
			.OrderByDescending(x => x.Count)
			.ThenBy(x => x.Value);
		return allWhiteBalls;
	}
}