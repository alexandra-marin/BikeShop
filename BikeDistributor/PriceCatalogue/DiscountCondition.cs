namespace BikeDistributor
{
    public class DiscountCondition
    {
        public int    ItemPrice { get; set; }
        public int    MinEligibleQuantity { get; set; }
        public double DiscountedFraction { get; set; }
    }
}
