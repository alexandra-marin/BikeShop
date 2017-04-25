using System.Collections.Generic;

namespace BikeDistributor
{
    public class DiscountedPrice
    {
        public Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>();
     
        public DiscountedPrice()
        {
            List<DiscountCondition> discounts = new DiscountConfiguration().GetDiscounts();

            foreach (var discount in discounts)
            {
                For[discount.Price] = discount;
            }
        }
    }
}
