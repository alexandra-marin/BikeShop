using System.Collections.Generic;

namespace BikeDistributor
{
    public static class Discount
    {
        public static Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>()
        {
            [Bike.OneThousand]  = new DiscountCondition(20, .9d),
            [Bike.TwoThousand]  = new DiscountCondition(10, .8d),
            [Bike.FiveThousand] = new DiscountCondition( 5, .8d),
        };
    }
}
