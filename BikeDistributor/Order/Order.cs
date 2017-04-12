using System.Collections.Generic;

namespace BikeDistributor
{
    public class Order
    {
		private readonly string         company;
		private readonly IList<Line>    lines   = new List<Line>();
		private readonly Receipt receipt = new Receipt();

        public Order(string company)
        {
            this.company = company;
        }

        public void AddLine(Line line)
        {
            lines.Add(line);
        }

        public string Receipt()
        {
            return receipt.PlainText(company, lines);
        }

        public string HtmlReceipt()
        {
            return receipt.Html(company, lines);
        }
    }
}
