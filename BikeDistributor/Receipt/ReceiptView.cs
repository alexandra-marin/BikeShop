using System.Collections.Generic;
using System.Text;

namespace BikeDistributor
{
	public sealed partial class ReceiptView
	{
		private const double TaxRate = .0725d;

		StringBuilder result = new StringBuilder();
		readonly string company;
		readonly IList<Line> lines;
		readonly string headerTemplate;
		readonly string lineTemplate;
		readonly string subtotalTemplate;
		readonly string taxTemplate;
		readonly string totalTemplate;

		double totalAmount = 0d;
		double tax;

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
