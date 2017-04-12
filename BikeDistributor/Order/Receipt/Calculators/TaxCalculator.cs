using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
    public class TaxCalculator
    {
        private const    double      taxRate = .0725d;
        private readonly IList<Line> products;

        public TaxCalculator(IList<Line> products)
        {
            this.products = products;
        }

        public double Subtotal => products.Sum(line => line.Amount);

        public double Tax => Subtotal * taxRate;

        public double Total => Subtotal + Tax;
    }
}
