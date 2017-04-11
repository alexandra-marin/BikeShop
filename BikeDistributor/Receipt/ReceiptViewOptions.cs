using System.Collections.Generic;

namespace BikeDistributor
{
    public sealed partial class ReceiptView
    {
        public class Options
        {
            public string      Company;
            public IList<Line> Lines;
            public string      HeaderTemplate;
            public string      LineTemplate;
            public string      SubtotalTemplate;
            public string      TaxTemplate;
            public string      TotalTemplate;

            public Options WithCompany(string company)
            {
                this.Company = company;
                return this;
            }

            public Options WithLines(IList<Line> lines)
            {
                this.Lines = lines;
                return this;
            }

            public Options WithHeader(string headerTemplate)
            {
                this.HeaderTemplate = headerTemplate;
                return this;
            }

            public Options WithLine(string lineTemplate)
            {
                this.LineTemplate = lineTemplate;
                return this;
            }

            public Options WithSubtotal(string subtotalTemplate)
            {
                this.SubtotalTemplate = subtotalTemplate;
                return this;
            }

            public Options WithTax(string taxTemplate)
            {
                this.TaxTemplate = taxTemplate;
                return this;
            }

            public Options WithTotal(string totalTemplate)
            {
                this.TotalTemplate = totalTemplate;
                return this;
            }

            public ReceiptView Build()
            {
                return new ReceiptView(this);
            }
        }
    }
}
