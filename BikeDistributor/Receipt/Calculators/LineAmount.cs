using System.Linq;

﻿namespace BikeDistributor
{
    public class LineAmount
    {
        private readonly int            price;
        private readonly int            quantity;
        private readonly PriceCatalogue priceCatalogue;

        public LineAmount(int price, int quantity, PriceCatalogue priceCatalogue)
        {
            this.price = price;
            this.quantity = quantity;
            this.priceCatalogue = priceCatalogue;
        }

        public double Calculate() => IsDiscounted ? DiscountedPrice : NormalPrice;

        private DiscountCondition Condition => priceCatalogue.Discounts
                                                             .FirstOrDefault(x => x.ItemPrice == price);

        private bool IsDiscounted => quantity >= Condition.MinEligibleQuantity;

        private double DiscountedPrice => NormalPrice * Condition.DiscountedFraction;

        private double NormalPrice => quantity * price;
    }
}
