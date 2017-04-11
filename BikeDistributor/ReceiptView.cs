using System.Collections.Generic;
using System.Text;

namespace BikeDistributor
{
    public sealed class ReceiptView
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

        private const double TaxRate = .0725d;
       
        StringBuilder result = new StringBuilder();
        readonly string company;
        readonly IList<Line> lines;
        readonly string headerTemplate;
        readonly string lineTemplate;
        readonly string subtotalTemplate;
        readonly string taxTemplate;
        readonly string totalTemplate;

        double totalAmount = 0d;
        double tax;

        private ReceiptView(Builder builder)
        {
            this.totalTemplate = builder.totalTemplate;
            this.taxTemplate = builder.taxTemplate;
            this.subtotalTemplate = builder.subtotalTemplate;
            this.lineTemplate = builder.lineTemplate;
            this.headerTemplate = builder.headerTemplate;
            this.lines = builder.lines;
            this.company = builder.company;

            CalculateResult();
        }

        public void AddHeader()
        {
            result.Append(string.Format(headerTemplate, company));
        }
        
        public void AddLine(Line line)
        {
            var amount = CalculateAmount(line);
            totalAmount += amount;

            result.Append(string.Format(lineTemplate, 
                                        line.Quantity, 
                                        line.Bike.Brand, 
                                        line.Bike.Model, 
                                        amount.ToString("C")));
        }

        public void AddFooter()
        {
            AddSubtotal();
            AddTax();
            AddTotal();
        }

        private void AddSubtotal()
        {
            result.AppendLine(string.Format("Sub-Total: {0}", totalAmount.ToString("C")));
        }

        private void AddTax()
        {
            tax = totalAmount * TaxRate;
            result.AppendLine(string.Format("Tax: {0}", tax.ToString("C")));
        }

        private void AddTotal()
        {
            result.Append(string.Format("Total: {0}", (totalAmount + tax).ToString("C")));
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
    
        public void CalculateResult()
        {
            AddHeader();
            foreach(var line in lines)
            {
                AddLine(line);
            }
            AddFooter();
        }

        public override string ToString()
        {
            return result.ToString();
        }
    }
}
