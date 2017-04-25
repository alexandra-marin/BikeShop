using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
    public class TaxCalculator
    {
        private const    double              taxRate = .0725d;
        private readonly IEnumerable<double> amounts;

        public TaxCalculator(IEnumerable<double> amounts)
        {
            this.amounts = amounts;
        }

        public double Subtotal => amounts.Sum();

        public double Tax => Subtotal * taxRate;

        public double Total => Subtotal + Tax;
    }
}
