using System.Collections.Generic;

namespace BikeDistributor
{
    public static class Discount
    {
        public static Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>()
        {
            [Prices.OneThousand]  = new DiscountCondition(20, .9d),
            [Prices.TwoThousand]  = new DiscountCondition(10, .8d),
            [Prices.FiveThousand] = new DiscountCondition( 5, .8d),
        };
    }
}
