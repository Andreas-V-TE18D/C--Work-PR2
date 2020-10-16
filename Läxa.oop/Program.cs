using System;

namespace OOPIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var kund = new Customer();
            while (true)
            {
                Console.WriteLine("Do you want to make a purchase?");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    Console.WriteLine("What do you want to buy?");
                    var product = new Product() { _productName = Console.ReadLine() };
                }
                else
                    break;

                Console.WriteLine("Do you want to view your cart?");
                if (Console.ReadLine().ToLower() == "yes")
                    foreach (var item in kund._cart)
                        Console.WriteLine(item._productName);
                else
                    Console.WriteLine("Suck a duck!");
            }
        }
    }
}