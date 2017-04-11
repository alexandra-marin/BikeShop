using NUnit.Framework;
using System;

namespace BikeDistributor.Test
{
    [TestFixture]
    public class OrderWithManyBikesTest
    {
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
        private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
        private readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);

        [Test]
        public void ReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 21));
            Assert.AreEqual(ResultStatementOneDefy, order.Receipt());
        }

		private static string ResultStatementOneDefy = "Order Receipt for Anywhere Bike Shop" + Environment.NewLine +
	"\t21 x Giant Defy 1 = $18,900.00" + Environment.NewLine +
"Sub-Total: $18,900.00" + Environment.NewLine +
"Tax: $1,370.25" + Environment.NewLine +
"Total: $20,270.25";

        [Test]
        public void ReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 21));
            Assert.AreEqual(ResultStatementOneElite, order.Receipt());
        }

        private static string ResultStatementOneElite = "Order Receipt for Anywhere Bike Shop" + Environment.NewLine +
	"\t21 x Specialized Venge Elite = $33,600.00" + Environment.NewLine +
"Sub-Total: $33,600.00" + Environment.NewLine +
"Tax: $2,436.00" + Environment.NewLine +
"Total: $36,036.00";

        [Test]
        public void ReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 21));
            Assert.AreEqual(ResultStatementOneDuraAce, order.Receipt());
        }

        private static string ResultStatementOneDuraAce = "Order Receipt for Anywhere Bike Shop" + Environment.NewLine +
	"\t21 x Specialized S-Works Venge Dura-Ace = $84,000.00" + Environment.NewLine +
"Sub-Total: $84,000.00" + Environment.NewLine +
"Tax: $6,090.00" + Environment.NewLine +
"Total: $90,090.00";

        [Test]
        public void HtmlReceiptOneDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 21));
            Assert.AreEqual(HtmlResultStatementOneDefy, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>21 x Giant Defy 1 = $18,900.00</li></ul><h3>Sub-Total: $18,900.00</h3><h3>Tax: $1,370.25</h3><h2>Total: $20,270.25</h2></body></html>";

        [Test]
        public void HtmlReceiptOneElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 21));
            Assert.AreEqual(HtmlResultStatementOneElite, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>21 x Specialized Venge Elite = $33,600.00</li></ul><h3>Sub-Total: $33,600.00</h3><h3>Tax: $2,436.00</h3><h2>Total: $36,036.00</h2></body></html>";

        [Test]
        public void HtmlReceiptOneDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 21));
            Assert.AreEqual(HtmlResultStatementOneDuraAce, order.HtmlReceipt());
        }

        private const string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>21 x Specialized S-Works Venge Dura-Ace = $84,000.00</li></ul><h3>Sub-Total: $84,000.00</h3><h3>Tax: $6,090.00</h3><h2>Total: $90,090.00</h2></body></html>";    
    }
}


