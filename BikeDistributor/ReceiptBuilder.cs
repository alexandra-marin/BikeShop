using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
    public class ReceiptBuilder
    {
        private const double TaxRate = .0725d;

        public string Receipt(string Company, IList<Line> lines)
        {
            ReceiptView view = new ReceiptView
									.Builder()
									.WithCompany(Company)
									.WithLines(lines)
									.WithHeader("Order Receipt for {0}" + Environment.NewLine)
									.WithLine("\t{0} x {1} {2} = {3}" + Environment.NewLine)
									.WithSubtotal("Sub-Total: {0}" + Environment.NewLine)
									.WithTax("Tax: {0}" + Environment.NewLine)
									.WithTotal("Total: {0}")
			                        .Build();

            return view.ToString();
        }

        public string HtmlReceipt(string Company, IList<Line> _lines)
        {
            var totalAmount = 0d;
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Company));
            if (_lines.Any())
            {
                result.Append("<ul>");
            }

            foreach (var line in _lines)
            {
                double thisAmount = CalculateAmount(line);
                result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                totalAmount += thisAmount;
            }


            if (_lines.Any())
            {
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", totalAmount.ToString("C")));
            var tax = totalAmount * TaxRate;
            result.Append(string.Format("<h3>Tax: {0}</h3>", tax.ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", (totalAmount + tax).ToString("C")));
            result.Append("</body></html>");
            return result.ToString();
        }

        private double CalculateAmount(Line line)
        {
            var thisAmount = 0d;
            switch (line.Bike.Price)
            {
                case Bike.OneThousand:
                    if (line.Quantity >= 20)
                        thisAmount += line.Quantity * line.Bike.Price * .9d;
                    else
                        thisAmount += line.Quantity * line.Bike.Price;
                    break;
                case Bike.TwoThousand:
                    if (line.Quantity >= 10)
                        thisAmount += line.Quantity * line.Bike.Price * .8d;
                    else
                        thisAmount += line.Quantity * line.Bike.Price;
                    break;
                case Bike.FiveThousand:
                    if (line.Quantity >= 5)
                        thisAmount += line.Quantity * line.Bike.Price * .8d;
                    else
                        thisAmount += line.Quantity * line.Bike.Price;
                    break;
            }

            return thisAmount;
        }
    }
}
