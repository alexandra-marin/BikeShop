using NUnit.Framework;
using System;

namespace BikeDistributor
{
    [TestFixture]
    public class OrderWithManyBikesTest : BikeTests
    {
        [Test]
        public void ReceiptManyDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 21, priceCatalogue));
            Assert.AreEqual(ResultStatementManyDefy, order.Receipt());
        }

		private static string ResultStatementManyDefy = "Order Receipt for Anywhere Bike Shop" + Environment.NewLine +
	"\t21 x Giant Defy 1 = $18,900.00" + Environment.NewLine +
"Sub-Total: $18,900.00" + Environment.NewLine +
"Tax: $1,370.25" + Environment.NewLine +
"Total: $20,270.25";

        [Test]
        public void ReceiptManyElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 21, priceCatalogue));
            Assert.AreEqual(ResultStatementManyElite, order.Receipt());
        }

        private static string ResultStatementManyElite = "Order Receipt for Anywhere Bike Shop" + Environment.NewLine +
	"\t21 x Specialized Venge Elite = $33,600.00" + Environment.NewLine +
"Sub-Total: $33,600.00" + Environment.NewLine +
"Tax: $2,436.00" + Environment.NewLine +
"Total: $36,036.00";

        [Test]
        public void ReceiptManyDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 21, priceCatalogue));
            Assert.AreEqual(ResultStatementManyDuraAce, order.Receipt());
        }

        private static string ResultStatementManyDuraAce = "Order Receipt for Anywhere Bike Shop" + Environment.NewLine +
	"\t21 x Specialized S-Works Venge Dura-Ace = $84,000.00" + Environment.NewLine +
"Sub-Total: $84,000.00" + Environment.NewLine +
"Tax: $6,090.00" + Environment.NewLine +
"Total: $90,090.00";

        [Test]
        public void HtmlReceiptManyDefy()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Defy, 21, priceCatalogue));
            Assert.AreEqual(HtmlResultStatementManyDefy, order.HtmlReceipt());
        }

        private const string HtmlResultStatementManyDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>21 x Giant Defy 1 = $18,900.00</li></ul><h3>Sub-Total: $18,900.00</h3><h3>Tax: $1,370.25</h3><h2>Total: $20,270.25</h2></body></html>";

        [Test]
        public void HtmlReceiptManyElite()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(Elite, 21, priceCatalogue));
            Assert.AreEqual(HtmlResultStatementManyElite, order.HtmlReceipt());
        }

        private const string HtmlResultStatementManyElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>21 x Specialized Venge Elite = $33,600.00</li></ul><h3>Sub-Total: $33,600.00</h3><h3>Tax: $2,436.00</h3><h2>Total: $36,036.00</h2></body></html>";

        [Test]
        public void HtmlReceiptManyDuraAce()
        {
            var order = new Order("Anywhere Bike Shop");
            order.AddLine(new Line(DuraAce, 21, priceCatalogue));
            Assert.AreEqual(HtmlResultStatementManyDuraAce, order.HtmlReceipt());
        }

        private const string HtmlResultStatementManyDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>21 x Specialized S-Works Venge Dura-Ace = $84,000.00</li></ul><h3>Sub-Total: $84,000.00</h3><h3>Tax: $6,090.00</h3><h2>Total: $90,090.00</h2></body></html>";    
    }
}


