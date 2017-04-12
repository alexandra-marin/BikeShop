using System.Collections.Generic;

namespace BikeDistributor
{
    public sealed partial class ReceiptView
    {
        public class Options
        {
            private readonly ReceiptView view = new ReceiptView();

            public Options WithCompany(string company)
            {
                view.company = company;
                return this;
            }

            public Options WithLines(IList<Line> lines)
            {
                view.lines = lines;
                return this;
            }

            public Options WithHeader(string headerTemplate)
            {
                view.headerTemplate = headerTemplate;
                return this;
            }

            public Options WithLine(string lineTemplate)
            {
                view.lineTemplate = lineTemplate;
                return this;
            }

            public Options WithSubtotal(string subtotalTemplate)
            {
                view.subtotalTemplate = subtotalTemplate;
                return this;
            }

            public Options WithTax(string taxTemplate)
            {
                view.taxTemplate = taxTemplate;
                return this;
            }

            public Options WithTotal(string totalTemplate)
            {
                view.totalTemplate = totalTemplate;
                return this;
            }

            public ReceiptView Build()
            {
                view.PrintResult();
                return view;
            }
        }
    }
}
