using System;

namespace BikeDistributor
{
    public class DiscountCondition
    {
        public readonly int    MaxQuantity;
        public readonly double DiscountedBy;

        public DiscountCondition(int maxQuantity, double discount)
        {
            this.MaxQuantity = maxQuantity;
            this.DiscountedBy = discount;
        }
    }
}
