namespace BikeDistributor
{
    public class LineAmount
    {
        private readonly int price;
        private readonly int quantity;
        private readonly DiscountedPrice discountedPrice;

        public LineAmount(int price, int quantity, DiscountedPrice discountedPrice)
        {
            this.price = price;
            this.quantity = quantity;
            this.discountedPrice = discountedPrice;
        }

        public double Calculate() => IsDiscounted ? DiscountedPrice : NormalPrice;

        private DiscountCondition Condition => discountedPrice.For[price];

        private bool IsDiscounted => quantity >= Condition.MinEligibleQuantity;

        private double DiscountedPrice => NormalPrice * Condition.DiscountedFraction;

        private double NormalPrice => quantity * price;
    }
}
