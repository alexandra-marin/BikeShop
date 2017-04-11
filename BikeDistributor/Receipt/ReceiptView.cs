using System.Collections.Generic;
using System.Text;

namespace BikeDistributor
{
	public sealed partial class ReceiptView
	{
        private const double TaxRate = .0725d;

        private double totalAmount = 0d;
        private double tax;

		private StringBuilder result = new StringBuilder();
		private readonly string company;
		private readonly IList<Line> lines;
		private readonly string headerTemplate;
		private readonly string lineTemplate;
		private readonly string subtotalTemplate;
		private readonly string taxTemplate;
		private readonly string totalTemplate;

		private ReceiptView(ReceiptViewBuilder builder)
		{
			this.totalTemplate = builder.totalTemplate;
			this.taxTemplate = builder.taxTemplate;
			this.subtotalTemplate = builder.subtotalTemplate;
			this.lineTemplate = builder.lineTemplate;
			this.headerTemplate = builder.headerTemplate;
			this.lines = builder.lines;
			this.company = builder.company;

			CalculateResult();
		}

		public void AddHeader()
		{
			result.Append(string.Format(headerTemplate, company));
		}

		public void AddLine(Line line)
		{
            var amount = new LineAmountCalculator(line).CalculateAmount();
			totalAmount += amount;

			result.Append(string.Format(lineTemplate,
						    line.Quantity,
						    line.Bike.Brand,
						    line.Bike.Model,
						    amount.ToString("C")));
		}

		public void AddFooter()
		{
			AddSubtotal();
			AddTax();
			AddTotal();
		}

		private void AddSubtotal()
		{
			result.Append(string.Format(subtotalTemplate, totalAmount.ToString("C")));
		}

		private void AddTax()
		{
			tax = totalAmount * TaxRate;
			result.Append(string.Format(taxTemplate, tax.ToString("C")));
		}

		private void AddTotal()
		{
			result.Append(string.Format(totalTemplate, (totalAmount + tax).ToString("C")));
		}

		public void CalculateResult()
		{
			AddHeader();
			foreach (var line in lines)
			{
				AddLine(line);
			}
			AddFooter();
		}

		public override string ToString()
		{
			return result.ToString();
		}
	}
}
