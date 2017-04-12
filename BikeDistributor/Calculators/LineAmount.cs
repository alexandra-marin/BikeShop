namespace BikeDistributor
{
    public class LineAmount
    {
        private readonly Line line;

        public LineAmount(Line line)
        {
            this.line = line;
        }

        public double Calculate()
        {
            var amount = 0d;
            var discount = Discount.For[line.Bike.Price];

            if (line.Quantity >= discount.MinEligibleQuantity)
                amount += line.Quantity * line.Bike.Price * discount.DiscountedBy;
            else
                amount += line.Quantity * line.Bike.Price;
            
            return amount;
        }
    }
}
