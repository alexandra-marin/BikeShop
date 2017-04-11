using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
    public class ReceiptFormats
    {
        private const double TaxRate = .0725d;

        public string PlainTextReceipt(string Company, IList<Line> lines)
        {
            ReceiptView view = new ReceiptView.ReceiptViewBuilder()
                                .WithCompany(Company)
                                .WithHeader("Order Receipt for {0}" + Environment.NewLine)
                                .WithLines(lines)
                                .WithLine("\t{0} x {1} {2} = {3}" + Environment.NewLine)
                                .WithSubtotal("Sub-Total: {0}" + Environment.NewLine)
                                .WithTax("Tax: {0}" + Environment.NewLine)
                                .WithTotal("Total: {0}")
                                .Build();

            return view.ToString();
        }

        public string HtmlReceipt(string Company, IList<Line> lines)
        {
            var header = "<html><body><h1>Order Receipt for {0}</h1>";
            var subTotal = "<h3>Sub-Total: {0}</h3>";

            if (lines.Any())
            {
                header += "<ul>";
                subTotal = "</ul>" + subTotal;
            }

            ReceiptView view = new ReceiptView.ReceiptViewBuilder()
                                .WithCompany(Company)
                                .WithHeader(header)
                                .WithLines(lines)
                                .WithLine("<li>{0} x {1} {2} = {3}</li>")
                                .WithSubtotal(subTotal)
                                .WithTax("<h3>Tax: {0}</h3>")
                                .WithTotal("<h2>Total: {0}</h2></body></html>")
                                .Build();

            return view.ToString();
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
