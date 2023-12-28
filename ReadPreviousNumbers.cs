using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace CalculateLottery;

public class ReadPreviousNumbers
{
	public static IList<Drawing> Initialize(string filename, GameName gameName)
	{
		IList<Drawing> drawings = new List<Drawing>();
		var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
		{
			HasHeaderRecord = false,
			MissingFieldFound = null
		};

		using (var reader = new StreamReader(filename))
		{
			using (var csv = new CsvReader(reader, configuration))
			{
				while (csv.Read())
				{
					var record = csv.GetRecord<DrawingRaw>();
					if (record == null) continue;
					var drawingDate = new DateTime(record.Year, record.Month, record.Day);
					var drawnNumbers = new int[5]
						{ record.Num1, record.Num2, record.Num3, record.Num4, record.Num5 };
					if (record.Multiplier == null) record.Multiplier = 0;
					var newDrawingData = new Drawing
					{
						BigNumber = record.MegaBall,
						DrawingDate = drawingDate,
						GameName = gameName,
						Jackpot = 0D,
						Multiplier = (int)record.Multiplier,
						Numbers = drawnNumbers
					};
					drawings.Add(newDrawingData);
				}
			}
		}

		return drawings;
	}
}