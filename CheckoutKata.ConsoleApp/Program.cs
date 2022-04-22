using System;
using System.Collections.Generic;

namespace CheckoutKata.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Product> products = new[]
            {
                new Product() { SKU = 'A', UnitPrice = 10 },
                new Product() { SKU = 'B', UnitPrice = 15 },
                new Product() { SKU = 'C', UnitPrice = 40 },
                new Product() { SKU = 'D', UnitPrice = 55 }
            };

            while(1 == 1)
            {
                Console.WriteLine("Welcome to CheckoutKata Stores");
                var checkout = new Checkout(products);

                Console.WriteLine("Enter contents of basket (ie: AAB) - or enter to exit");
                var basket = Console.ReadLine();

                if (string.IsNullOrEmpty(basket))
                    break;

                checkout.Add(basket.ToUpper());

                foreach (var item in checkout.Basket)
                    Console.WriteLine($"{item.SKU}\t\t{item.UnitPrice.ToString("c")}");

                Console.WriteLine("Total amount:\t" + checkout.TotalAmount.ToString("c"));

                Console.WriteLine(new string('*', 22));
                Console.WriteLine(string.Empty);
            }

            Console.WriteLine("Thank you for shopping with CheckoutKata Stores");
        }
    }
}
