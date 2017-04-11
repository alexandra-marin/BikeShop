using System.Text;

namespace BikeDistributor
{
	public sealed partial class ReceiptView
	{
        private             double        totalAmount;
        private readonly    Options       options;
        private             StringBuilder result = new StringBuilder();

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
            AddFooter();
        }

        public void AddHeader()
		{
			result.Append(string.Format(options.HeaderTemplate, options.Company));
		}

		public void AddLine(Line line)
		{
            var amount = new LineAmountCalculator(line).CalculateAmount();
			totalAmount += amount;

			result.Append(string.Format(options.LineTemplate, line.Quantity, line.Bike.Brand, line.Bike.Model, amount.ToString("C")));
		}
    
        private void AddFooter()
        {
            var calculator = new TaxCalculator(totalAmount);

            result.Append(string.Format(options.SubtotalTemplate, calculator.Subtotal));
            result.Append(string.Format(options.TaxTemplate     , calculator.Tax     ));
            result.Append(string.Format(options.TotalTemplate   , calculator.Total   ));
        }

		public override string ToString()
		{
			return result.ToString();
		}
	}
}
