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
            var discount = DiscountList.DiscountFor[line.Bike.Price];

            if (line.Quantity >= discount.MinEligibleQuantity)
                thisAmount += line.Quantity * line.Bike.Price * discount.DiscountedBy;
            else
                thisAmount += line.Quantity * line.Bike.Price;
            
			return thisAmount;
        }
    }
}
