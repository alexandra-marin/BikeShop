using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace BikeDistributor
{
    public class BikeDistributorConfiguration
    {
        private const string discountFile = "BikeDistributor.json";

        public List<DiscountCondition> Discounts { get; set; }
        public double TaxRate { get; set; }

        public static BikeDistributorConfiguration Build()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileLocation = Path.Combine(executableLocation, discountFile);

            var discountsJson = File.ReadAllText(fileLocation);

            return JsonConvert.DeserializeObject<BikeDistributorConfiguration>(discountsJson);
        }
    }

}
