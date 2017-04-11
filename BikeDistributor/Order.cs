using System.Collections.Generic;

namespace BikeDistributor
{
    public class Order
    {
        public string Company { get; private set; }
       
        private readonly IList<Line> _lines = new List<Line>();
        private readonly ReceiptFormats receiptBuilder = new ReceiptFormats();

        public Order(string company)
        {
            Company = company;
        }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        public string Receipt()
        {
            return receiptBuilder.PlainTextReceipt(Company, _lines);
        }

        public string HtmlReceipt()
        {
            return receiptBuilder.HtmlReceipt(Company, _lines);
        }
    }
}
