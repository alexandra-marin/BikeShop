using System.Collections.Generic;

namespace BikeDistributor
{
    public class DiscountedPrice
    {
        public Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>();
     
        public DiscountedPrice(DiscountConfiguration discountsConfig)
        {
            List<DiscountCondition> discounts = discountsConfig.GetDiscounts();

            foreach (var discount in discounts)
            {
                For[discount.Price] = discount;
            }
        }
    }
}
