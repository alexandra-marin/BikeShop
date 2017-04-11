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
            var discount = new DiscountCondition(0, 1d);

            switch (line.Bike.Price)
            {
                case Bike.OneThousand:
                    discount = new DiscountCondition(20, .9d);
                    break;
                case Bike.TwoThousand:
                    discount = new DiscountCondition(10, .8d);
                    break;
                case Bike.FiveThousand:
                    discount = new DiscountCondition(5, .8d);
                    break;
            }

            if (line.Quantity >= discount.MaxQuantity)
                thisAmount += line.Quantity * line.Bike.Price * discount.DiscountedBy;
            else
                thisAmount += line.Quantity * line.Bike.Price;
            
			return thisAmount;
        }
    }
}
