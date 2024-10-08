using System;
using System.Collections.Generic;

namespace Store
{
    public static class Authentication
    {
        public static void RegisterCustomer(List<Customer> customers)
        {
            Console.Write("Ange ditt namn: ");
            string name = Console.ReadLine();
            Console.Write("Ange ditt lösenord: ");
            string password = Console.ReadLine();

            customers.Add(new Customer(name, password));
            Console.WriteLine($"Kund {name} har registrerats.");
        }

        public static Customer Login(List<Customer> customers)
        {
            Console.Write("Ange namn: ");
            string name = Console.ReadLine();
            Console.Write("Ange lösenord: ");
            string password = Console.ReadLine();

            Customer customer = customers.Find(c => c.Name == name);
            if (customer == null)
            {
                Console.WriteLine("Kund finns inte. Registrera ny kund? (ja/nej)");
                if (Console.ReadLine().ToLower() == "ja")
                {
                    RegisterCustomer(customers);
                }
                return null;
            }

            if (!customer.VerifyPassword(password))
            {
                Console.WriteLine("Fel lösenord");
                return null;
            }

            Console.WriteLine($"Välkommen, {name}!");
            return customer;
        }
    }
}
