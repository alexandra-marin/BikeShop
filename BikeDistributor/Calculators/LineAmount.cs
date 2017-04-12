namespace BikeDistributor
{
    public class LineAmount
    {
        private readonly Line line;

        public LineAmount(Line line)
        {
            this.line = line;
        }

        public double Calculate() => IsDiscounted ? DiscountedPrice : NormalPrice;

        private DiscountCondition Condition => Discount.For[line.Bike.Price];

        private bool IsDiscounted => line.Quantity >= Condition.MinEligibleQuantity;

        private double DiscountedPrice => NormalPrice * Condition.DiscountedBy;

        private double NormalPrice => line.Quantity * line.Bike.Price;
    }
}
