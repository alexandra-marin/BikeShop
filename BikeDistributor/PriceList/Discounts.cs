using System.Collections.Generic;

namespace BikeDistributor
{
    public static class Discount
    {
        public static Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>()
        {
            [1000]  = new DiscountCondition(20, .9d),
            [2000]  = new DiscountCondition(10, .8d),
            [5000] = new DiscountCondition( 5, .8d),
        };
    }
}
