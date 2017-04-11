namespace BikeDistributor
{
    public class LineAmountCalculator
    {
        private readonly Line line;

        public LineAmountCalculator(Line line)
        {
            this.line = line;
        }

        public double CalculateAmount()
        {
            var amount = 0d;
            var discount = DiscountList.DiscountFor[line.Bike.Price];

            if (line.Quantity >= discount.MinEligibleQuantity)
                amount += line.Quantity * line.Bike.Price * discount.DiscountedBy;
            else
                amount += line.Quantity * line.Bike.Price;
            
            return amount;
        }
    }
}
