using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace BikeDistributor
{
    public static class DiscountedPrice
    {
        public static Dictionary<int, DiscountCondition> For = new Dictionary<int, DiscountCondition>();
     
        static DiscountedPrice()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileLocation = Path.Combine(executableLocation, "Discounts.json");

            var text = File.ReadAllText(fileLocation);

            var li = JsonConvert.DeserializeObject<List<DiscountCondition>>(text);

            foreach(var l in li)
            {
                For[l.Price] = l;
            }
        }
    }
}
