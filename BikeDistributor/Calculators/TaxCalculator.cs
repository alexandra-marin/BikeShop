using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
    public class TaxCalculator
    {
        private const    double taxRate = .0725d;
        private readonly double beforeTax;
        private readonly double tax;
        private readonly double total;
        
        public TaxCalculator(IList<Line> receiptRows)
        {
            beforeTax = receiptRows.Sum(line => line.Amount);
            tax       = beforeTax * taxRate;
            total     = beforeTax + tax;
        }

        public string Subtotal => beforeTax.Display();
        public string Tax      => tax      .Display();
        public string Total    => total    .Display();
    }
}
