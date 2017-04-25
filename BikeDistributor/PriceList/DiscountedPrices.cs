using System.Collections.Generic;

namespace BikeDistributor
{
    public static class DiscountedPrice
    {
        public static Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>();
     
        static DiscountedPrice()
        {
            List<DiscountCondition> discounts = new DiscountConfiguration().GetDiscounts();

            foreach (var discount in discounts)
            {
                For[discount.Price] = discount;
            }
        }
    }
}
