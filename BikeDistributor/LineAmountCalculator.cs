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
            var maxQuantity = 0;
            var discount = 1d;

            switch (line.Bike.Price)
            {
                case Bike.OneThousand:
                    maxQuantity = 20;
                    discount = .9d;
                    break;
                case Bike.TwoThousand:
                    maxQuantity = 10;
                    discount = .8d;
                    break;
                case Bike.FiveThousand:
                    maxQuantity = 5;
                    discount = .8d;
                    break;
                default:
                    break;
            }

            if (line.Quantity >= maxQuantity)
                thisAmount += line.Quantity * line.Bike.Price * discount;
            else
                thisAmount += line.Quantity * line.Bike.Price;
            
			return thisAmount;
        }
    }
}
