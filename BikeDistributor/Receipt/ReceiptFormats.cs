using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
	public class ReceiptFormats
	{
		public string PlainText(string company, IList<Line> lines)
		{
			ReceiptView view = new ReceiptView.Options()
                                              .WithCompany(company)
                                              .WithHeader("Order Receipt for {0}" + Environment.NewLine)
                                              .WithLines(lines)
                                              .WithLine("\t{0} x {1} {2} = {3}" + Environment.NewLine)
                                              .WithSubtotal("Sub-Total: {0}" + Environment.NewLine)
                                              .WithTax("Tax: {0}" + Environment.NewLine)
                                              .WithTotal("Total: {0}")
                                              .Build();

			return view.ToString();
		}

		public string Html(string company, IList<Line> lines)
		{
			var header = "<html><body><h1>Order Receipt for {0}</h1>";
			var subTotal = "<h3>Sub-Total: {0}</h3>";

			if (lines.Any())
			{
				header += "<ul>";
				subTotal = "</ul>" + subTotal;
			}

			ReceiptView view = new ReceiptView.Options()
                                              .WithCompany(company)
                                              .WithHeader(header)
                                              .WithLines(lines)
                                              .WithLine("<li>{0} x {1} {2} = {3}</li>")
                                              .WithSubtotal(subTotal)
                                              .WithTax("<h3>Tax: {0}</h3>")
                                              .WithTotal("<h2>Total: {0}</h2></body></html>")
                                              .Build();

			return view.ToString();
		}
	}
}
