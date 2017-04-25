namespace BikeDistributor
{
    public class Line
    {
        public Bike   Bike     { get; private set; }
        public int    Quantity { get; private set; }
        public double Amount   { get; private set; }

        public Line(Bike bike, int quantity) : this(bike, quantity, new DiscountedPrice())
        {
        }

        public Line(Bike bike, int quantity, DiscountedPrice discountedPrice)
        {
            Bike = bike;
            Quantity = quantity;

            var calculator = new LineAmount(bike.Price, quantity, discountedPrice);

            Amount = calculator.Calculate();
        }
    }
}
