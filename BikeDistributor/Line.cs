namespace BikeDistributor
{
    public class Line
    {
        public Bike   Bike     { get; private set; }
        public int    Quantity { get; private set; }
        public double Amount   { get; private set; }

        public Line(Bike bike, int quantity)
        {
            Bike = bike;
            Quantity = quantity;

            var calculator = new LineAmountCalculator(this);
            Amount = calculator.CalculateAmount();
        }
    }
}
