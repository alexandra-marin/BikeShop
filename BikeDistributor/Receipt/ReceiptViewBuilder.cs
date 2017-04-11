using System.Collections.Generic;

namespace BikeDistributor
{
    public sealed partial class ReceiptView
    {
        public class ReceiptViewBuilder
        {
            public string      company;
            public IList<Line> lines;
            public string      headerTemplate;
            public string      lineTemplate;
            public string      subtotalTemplate;
            public string      taxTemplate;
            public string      totalTemplate;

            public ReceiptViewBuilder WithCompany(string company)
            {
                this.company = company;
                return this;
            }

            public ReceiptViewBuilder WithLines(IList<Line> lines)
            {
                this.lines = lines;
                return this;
            }

            public ReceiptViewBuilder WithHeader(string headerTemplate)
            {
                this.headerTemplate = headerTemplate;
                return this;
            }

            public ReceiptViewBuilder WithLine(string lineTemplate)
            {
                this.lineTemplate = lineTemplate;
                return this;
            }

            public ReceiptViewBuilder WithSubtotal(string subtotalTemplate)
            {
                this.subtotalTemplate = subtotalTemplate;
                return this;
            }

            public ReceiptViewBuilder WithTax(string taxTemplate)
            {
                this.taxTemplate = taxTemplate;
                return this;
            }

            public ReceiptViewBuilder WithTotal(string totalTemplate)
            {
                this.totalTemplate = totalTemplate;
                return this;
            }

            public ReceiptView Build()
            {
                return new ReceiptView(this);
            }
        }
    }
}
