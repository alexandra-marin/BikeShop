namespace BikeDistributor
{
    public static class Formatting
    {
        public static string Display(this double number)
        {
            return number.ToString("C");
        }
    }
}
