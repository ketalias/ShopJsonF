using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShopJSON
{
    public class Product
    {
        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "pricePerUnit")]
        public decimal PricePerUnit { get; set; }

        [JsonProperty(PropertyName = "storageDays")]
        public int StorageDays { get; set; }

        public bool IsExpired()
        {
            return StorageDays <= 0;
        }
    }

    public class ProductList
    {
        [JsonProperty(PropertyName = "products")]
        public List<Product> Products { get; set; }
    }
}

