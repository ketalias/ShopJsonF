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

    class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductList
            {
                Products = new List<Product>
                {
                    new Product { ProductName = "Молоко", Quantity = 10, PricePerUnit = 1.2m, StorageDays = 5 },
                    new Product { ProductName = "Хліб", Quantity = 20, PricePerUnit = 0.8m, StorageDays = -2 },
                    new Product { ProductName = "Сир", Quantity = 5, PricePerUnit = 3.5m, StorageDays = -1 },
                    new Product { ProductName = "Масло", Quantity = 7, PricePerUnit = 2.0m, StorageDays = 1 }
                }
            };

            string jsonData = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("Shop.json", jsonData);

            Console.WriteLine("Прочитаний файл:");
            Console.WriteLine(jsonData);

            var productsFromFile = JsonConvert.DeserializeObject<ProductList>(File.ReadAllText("Shop.json"));

            decimal totalValue = productsFromFile.Products.Sum(p => p.PricePerUnit * p.Quantity);
            Console.WriteLine($"\nЗагальна вартість всього товару: {totalValue} грн.");

            int expiredProductsCount = productsFromFile.Products.Count(p => p.IsExpired());
            Console.WriteLine($"\nКількість прострочених товарів: {expiredProductsCount}");
        }
    }
}
