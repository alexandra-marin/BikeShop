﻿using System.Text;
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
	    private StringBuilder view = new StringBuilder();

        private ReceiptView()
        {
        }

        public string Print()
        {
            AddHeader();
            AddProducts();
            AddFooter();

            return view.ToString();
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
            var calculator = new TaxCalculator(lines);

            view.Append(string.Format(subtotalTemplate, calculator.Subtotal.Display()));
            view.Append(string.Format(taxTemplate     , calculator.Tax     .Display()));
            view.Append(string.Format(totalTemplate   , calculator.Total   .Display()));
        }
	}
}