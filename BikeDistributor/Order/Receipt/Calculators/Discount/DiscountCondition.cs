namespace BikeDistributor
{
    public class DiscountCondition
    {
        public readonly int    MinEligibleQuantity;
        public readonly double DiscountedBy;

        public DiscountCondition(int minQuantity, double discount)
        {
            this.MinEligibleQuantity = minQuantity;
            this.DiscountedBy = discount;
        }
    }
}
