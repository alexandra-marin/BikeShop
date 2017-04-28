using System.Collections.Generic;

namespace BikeDistributor
{
    public class PriceCatalogue
    {
        public List<DiscountCondition> Discounts = new List<DiscountCondition>();
     
        public PriceCatalogue(PriceCatalogueConfiguration discountsConfig)
        {
            Discounts = discountsConfig.GetDiscounts();
        }
    }
}
