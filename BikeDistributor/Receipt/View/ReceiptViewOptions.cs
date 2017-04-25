using System.Collections.Generic;

namespace BikeDistributor
{
    public sealed partial class ReceiptView
    {
        public class Options
        {
            public string      company;
	        public IList<Line> lines;
	        public string      headerTemplate;
	        public string      lineTemplate;
	        public string      subtotalTemplate;
	        public string      taxTemplate;
	        public string      totalTemplate;

            public Options WithCompany(string company)
            {
                this.company = company;
                return this;
            }

            public Options WithLines(IList<Line> lines)
            {
                this.lines = lines;
                return this;
            }

            public Options WithHeader(string headerTemplate)
            {
                this.headerTemplate = headerTemplate;
                return this;
            }

            public Options WithLine(string lineTemplate)
            {
                this.lineTemplate = lineTemplate;
                return this;
            }

            public Options WithSubtotal(string subtotalTemplate)
            {
                this.subtotalTemplate = subtotalTemplate;
                return this;
            }

            public Options WithTax(string taxTemplate)
            {
                this.taxTemplate = taxTemplate;
                return this;
            }

            public Options WithTotal(string totalTemplate)
            {
                this.totalTemplate = totalTemplate;
                return this;
            }

            public ReceiptView Build()
            {
                var receipt = new ReceiptView(this);

                return receipt;
            }
        }
    }
}
