﻿namespace BikeDistributor
{
    public class LineAmount
    {
        private readonly int price;
        private readonly int quantity;
        private readonly Discounts discount;

        public LineAmount(int price, int quantity, Discounts discount)
        {
            this.price = price;
            this.quantity = quantity;
            this.discount = discount;
        }

        public double Calculate() => IsDiscounted ? DiscountedPrice : NormalPrice;

        private DiscountCondition Condition => discount.For[price];

        private bool IsDiscounted => quantity >= Condition.MinEligibleQuantity;

        private double DiscountedPrice => NormalPrice * Condition.DiscountedFraction;

        private double NormalPrice => quantity * price;
    }
}
