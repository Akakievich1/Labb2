using System;

namespace Store
{
    public static class Menu
    {
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till butiken!");
            Console.WriteLine("1. Registrera ny kund");
            Console.WriteLine("2. Logga in");
            Console.Write("Välj ett alternativ: ");
        }

        public static void ShowCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Handla");
            Console.WriteLine("2. Se kundvagn");
            Console.WriteLine("3. Gå till kassan");
            Console.WriteLine("4. Logga ut");
            Console.Write("Välj ett alternativ: ");
        }

        public static void ShowProducts(List<Product> products)
        {
            Console.WriteLine("Tillgängliga produkter:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }
    }
}
