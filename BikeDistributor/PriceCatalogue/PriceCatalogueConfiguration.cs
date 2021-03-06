﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace BikeDistributor
{
    public class PriceCatalogueConfiguration
    {
        private const string discountFile = "PriceCatalogue.json";

        public List<DiscountCondition> GetDiscounts()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileLocation = Path.Combine(executableLocation, discountFile);

            var discountsJson = File.ReadAllText(fileLocation);

            var discounts = JsonConvert.DeserializeObject<List<DiscountCondition>>(discountsJson);
            return discounts;
        }
    }
}
