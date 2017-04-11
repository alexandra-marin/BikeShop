using System.Collections.Generic;

namespace BikeDistributor
{
    public sealed partial class ReceiptView
    {
        public class Builder
        {
            public string company;
            public IList<Line> lines;
            public string headerTemplate;
            public string lineTemplate;
            public string subtotalTemplate;
            public string taxTemplate;
            public string totalTemplate;

            public Builder WithCompany(string company)
            {
                this.company = company;
                return this;
            }

            public Builder WithLines(IList<Line> lines)
            {
                this.lines = lines;
                return this;
            }

            public Builder WithHeader(string headerTemplate)
            {
                this.headerTemplate = headerTemplate;
                return this;
            }

            public Builder WithLine(string lineTemplate)
            {
                this.lineTemplate = lineTemplate;
                return this;
            }

            public Builder WithSubtotal(string subtotalTemplate)
            {
                this.subtotalTemplate = subtotalTemplate;
                return this;
            }

            public Builder WithTax(string taxTemplate)
            {
                this.taxTemplate = taxTemplate;
                return this;
            }

            public Builder WithTotal(string totalTemplate)
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
