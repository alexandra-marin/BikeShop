﻿namespace BikeDistributor
{
    public class Line
    {
        public Bike   Bike     { get; private set; }
        public int    Quantity { get; private set; }
        public double Amount   { get; private set; }

        public Line(Bike bike, int quantity, Discounts discount)
        {
            Bike = bike;
            Quantity = quantity;

            var calculator = new LineAmount(bike.Price, quantity, discount);
            Amount = calculator.Calculate();
        }
    }
}
