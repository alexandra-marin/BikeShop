﻿namespace BikeDistributor
{
    public class BikeTests
    {
        protected readonly static Bike Defy = new Bike("Giant", "Defy 1", 1000);
        protected readonly static Bike Elite = new Bike("Specialized", "Venge Elite", 2000);
        protected readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", 5000);
        protected readonly static Discounts discountedPrice = new Discounts(new DiscountConfiguration());
    }
}
