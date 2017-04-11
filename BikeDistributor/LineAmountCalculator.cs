using System;
namespace BikeDistributor
{
	public class LineAmountCalculator
	{
		readonly Line line;

		public LineAmountCalculator(Line line)
		{
			this.line = line;
		}

		public double CalculateAmount()
		{
			var thisAmount = 0d;
			switch (line.Bike.Price)
			{
				case Bike.OneThousand:
					if (line.Quantity >= 20)
						thisAmount += line.Quantity * line.Bike.Price * .9d;
					else
						thisAmount += line.Quantity * line.Bike.Price;
					break;
				case Bike.TwoThousand:
					if (line.Quantity >= 10)
						thisAmount += line.Quantity * line.Bike.Price * .8d;
					else
						thisAmount += line.Quantity * line.Bike.Price;
					break;
				case Bike.FiveThousand:
					if (line.Quantity >= 5)
						thisAmount += line.Quantity * line.Bike.Price * .8d;
					else
						thisAmount += line.Quantity * line.Bike.Price;
					break;
			}

			return thisAmount;
		}
	}
}
