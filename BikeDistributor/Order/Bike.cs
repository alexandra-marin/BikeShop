namespace BikeDistributor
{
    public class Bike
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int    Price { get; set; }

        public Bike(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }
    }
}
