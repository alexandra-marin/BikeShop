using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BikeDistributor
{
	public sealed partial class ReceiptView
	{
        private string        company;
        private IList<Line>   lines;
        private string        headerTemplate;
        private string        lineTemplate;
        private string        subtotalTemplate;
        private string        taxTemplate;
        private string        totalTemplate;
        private StringBuilder result = new StringBuilder();

        private ReceiptView()
        {
        }

        public void PrintResult()
        {
            result.Append(string.Format(headerTemplate, company));
            lines.ToList().ForEach(AddLine);
            AddFooter();
        }

		public void AddLine(Line line)
		{
			result.Append(string.Format(lineTemplate, line.Quantity, line.Bike.Brand, line.Bike.Model, line.Amount.Display()));
		}
    
        private void AddFooter()
        {
            var calculator = new TaxCalculator(lines);

            result.Append(string.Format(subtotalTemplate, calculator.Subtotal));
            result.Append(string.Format(taxTemplate     , calculator.Tax     ));
            result.Append(string.Format(totalTemplate   , calculator.Total   ));
        }

		public override string ToString()
		{
			return result.ToString();
		}
	}
}
