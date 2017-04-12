using System.Text;
using System.Linq;

namespace BikeDistributor
{
	public sealed partial class ReceiptView
	{
        private readonly    Options       options;
        private             StringBuilder result = new StringBuilder();

		private ReceiptView(Options builder)
		{
			options = builder;
            PrintResult();
		}
 
        public void PrintResult()
        {
            result.Append(string.Format(options.HeaderTemplate, options.Company));
            options.Lines
                   .ToList()
                   .ForEach(AddLine);
            AddFooter();
        }

		public void AddLine(Line line)
		{
			result.Append(string.Format(options.LineTemplate, line.Quantity, line.Bike.Brand, line.Bike.Model, line.Amount.Display()));
		}
    
        private void AddFooter()
        {
            var calculator = new TaxCalculator(options.Lines);

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
