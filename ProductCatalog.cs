using System;
using System.Collections.Generic;

namespace Store
{
    public static class ProductCatalog
    {
        private static List<Product> _products = new List<Product>();

        static ProductCatalog()
        {
            _products.Add(new Product("Bröd", 25));
            _products.Add(new Product("Smör", 40));
            _products.Add(new Product("Mjölk", 12));
        }

        public static List<Product> GetProducts()
        {
            return _products;
        }

        public static void ShowProducts()
        {
            Console.WriteLine("Tillgängliga produkter:");
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_products[i]}");
            }
        }

        public static Product GetProductByIndex(int index)
        {
            if (index >= 0 && index < _products.Count)
            {
                return _products[index];
            }
            return null;
        }
    }
}
