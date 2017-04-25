using System;
using NUnit.Framework;

namespace BikeDistributor
{
	[TestFixture]
	public class OrderWithManyLinesTest
	{
        private readonly static Bike Defy = new Bike("Giant", "Defy 1", 1000);
		private readonly static Bike Elite = new Bike("Specialized", "Venge Elite", 2000);

		[Test]
		public void ReceiptManyLines()
		{
			var order = new Order("Anywhere Bike Shop");
			order.AddLine(new Line(Defy, 1));
			order.AddLine(new Line(Elite, 1));
			Assert.AreEqual(ResultStatementManyLines, order.Receipt());
		}

		private static string ResultStatementManyLines = "Order Receipt for Anywhere Bike Shop" + Environment.NewLine +
	"\t1 x Giant Defy 1 = $1,000.00" + Environment.NewLine +
	"\t1 x Specialized Venge Elite = $2,000.00" + Environment.NewLine +
"Sub-Total: $3,000.00" + Environment.NewLine +
"Tax: $217.50" + Environment.NewLine +
"Total: $3,217.50";
		
		[Test]
		public void HtmlReceiptManyLines()
		{
			var order = new Order("Anywhere Bike Shop");
			order.AddLine(new Line(Defy, 1));
			order.AddLine(new Line(Elite, 1));
			Assert.AreEqual(HtmlResultStatementManyLines, order.HtmlReceipt());
		}
		private const string HtmlResultStatementManyLines = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $3,000.00</h3><h3>Tax: $217.50</h3><h2>Total: $3,217.50</h2></body></html>";
	}
}

