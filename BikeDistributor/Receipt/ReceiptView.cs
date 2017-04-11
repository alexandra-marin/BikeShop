using System.Text;

namespace BikeDistributor
{
	public sealed partial class ReceiptView
	{
        private const    double        TaxRate = .0725d;
        private          double        tax;
        private          double        totalAmount;
        private readonly Options       options;
        private          StringBuilder result = new StringBuilder();

		private ReceiptView(Options builder)
		{
			this.options = builder;
			
            CalculateResult();
		}
 
        public void CalculateResult()
        {
            AddHeader();
            foreach (var line in options.Lines)
            {
                AddLine(line);
            }
            AddSubtotal();
            AddTax();
            AddTotal();
        }

		public void AddHeader()
		{
			result.Append(string.Format(options.HeaderTemplate, options.Company));
		}

		public void AddLine(Line line)
		{
            var amount = new LineAmountCalculator(line).CalculateAmount();
			totalAmount += amount;

			result.Append(string.Format(options.LineTemplate,
						    line.Quantity,
						    line.Bike.Brand,
						    line.Bike.Model,
						    amount.ToString("C")));
		}

		private void AddSubtotal()
		{
			result.Append(string.Format(options.SubtotalTemplate, 
                                        totalAmount.ToString("C")));
		}

		private void AddTax()
		{
			tax = totalAmount * TaxRate;
			result.Append(string.Format(options.TaxTemplate, 
                                        tax.ToString("C")));
		}

		private void AddTotal()
		{
			result.Append(string.Format(options.TotalTemplate, 
                                        (totalAmount + tax).ToString("C")));
		}

		public override string ToString()
		{
			return result.ToString();
		}
	}
}
