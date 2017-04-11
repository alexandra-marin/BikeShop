namespace BikeDistributor
{
    public class TaxCalculator
    {
        private const    double taxRate = .0725d;
        private readonly double beforeTax;
        private readonly double tax;
        private readonly double total;
        
        public TaxCalculator(double totalAmount)
        {
            beforeTax = totalAmount;
            tax       = beforeTax * taxRate;
            total     = beforeTax + tax;
        }

        public string Subtotal => beforeTax.ToString("C");
        public string Tax      => tax      .ToString("C");
        public string Total    => total    .ToString("C");
    }
}
