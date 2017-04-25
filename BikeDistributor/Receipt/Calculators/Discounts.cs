using System.Collections.Generic;

namespace BikeDistributor
{
    public class Discounts
    {
        public Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>();
     
        public Discounts(BikeDistributorConfiguration discountsConfig)
        {
            List<DiscountCondition> discounts = discountsConfig.Discounts;

            foreach (var discount in discounts)
            {
                For[discount.Price] = discount;
            }
        }
    }
}
