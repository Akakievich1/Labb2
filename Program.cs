using System;

namespace Store
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            InitializeStore();

            while (true)
            {
                Menu.ShowMainMenu();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Authentication.RegisterCustomer(customers);
                }
                else if (choice == "2")
                {
                    Customer loggedInCustomer = Authentication.Login(customers);
                    if (loggedInCustomer != null)
                    {
                        CustomerMenu(loggedInCustomer);
                    }
                }
            }
        }

        static void InitializeStore()
        {
            customers.Add(new Customer("Knatte", "123"));
            customers.Add(new Customer("Fnatte", "321"));
            customers.Add(new Customer("Tjatte", "213"));
        }

        static void CustomerMenu(Customer customer)
        {
            while (true)
            {
                Menu.ShowCustomerMenu();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Shop(customer);
                }
                else if (choice == "2")
                {
                    customer.Cart.ShowCart(); 
                    Console.WriteLine("Tryck på valfri knapp för att återgå till menyn.");
                    Console.ReadKey(); 
                }
                else if (choice == "3")
                {
                    Checkout(customer);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Du har loggats ut.");
                    break;
                }
            }
        }

        static void Shop(Customer customer)
        {
            ProductCatalog.ShowProducts();
            Console.Write("Välj en produkt att lägga till i kundvagnen (0 för att avbryta): ");
            if (int.TryParse(Console.ReadLine(), out int productIndex))
            {
                if (productIndex == 0)
                {
                    Console.WriteLine("Du har avbrutit köpet.");
                    return;
                }

                if (productIndex > 0 && productIndex <= ProductCatalog.GetProducts().Count)
                {
                    Product selectedProduct = ProductCatalog.GetProductByIndex(productIndex - 1);

                    Console.Write("Hur många vill du köpa? ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            customer.Cart.AddProduct(selectedProduct);
                        }
                        Console.WriteLine($"{quantity} {selectedProduct.Name} har lagts till i din kundvagn.");
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt antal.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                }
            }
        }



        static void Checkout(Customer customer)
        {
            if (customer.Cart.GetTotalPrice() == 0)
            {
                Console.WriteLine("Din kundvagn är tom. Köp något innan du går till kassan");
            }
            else
            {
                Console.WriteLine($"Din totala kostnad är {customer.Cart.GetTotalPrice():C}. Tack för köpet!");
                customer.Cart.ClearCart();
            }
            Console.WriteLine("Tryck på valfri knapp för att återgå till menyn.");
            Console.ReadKey();
        }
    }
}
