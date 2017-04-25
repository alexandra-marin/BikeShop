using System.Text;
using System.Collections.Generic;
using System.Linq;

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
	    private StringBuilder view = new StringBuilder();

        private ReceiptView(Options options)
        {
            company = options.company;
            lines = options.lines;
            headerTemplate = options.headerTemplate;
            lineTemplate = options.lineTemplate;
            subtotalTemplate = options.subtotalTemplate;
            taxTemplate = options.taxTemplate;
            totalTemplate = options.totalTemplate;

            BuildReceipt();
        }

        public string Print() => view.ToString();

        private void BuildReceipt()
        {
            AddHeader();
            AddProducts();
            AddFooter();
        }

        private void AddHeader()
        {
            view.Append(string.Format(headerTemplate, company));
        }

        private void AddProducts()
        {
            foreach (var line in lines)
            {
                view.Append(string.Format(lineTemplate, line.Quantity, line.Bike.Brand, line.Bike.Model, line.Amount.Display()));
            }
        }

        private void AddFooter()
        {
            var calculator = new TaxCalculator(lines.Select(x => x.Amount));

            view.Append(string.Format(subtotalTemplate, calculator.Subtotal.Display()));
            view.Append(string.Format(taxTemplate     , calculator.Tax     .Display()));
            view.Append(string.Format(totalTemplate   , calculator.Total   .Display()));
        }
	}
}
