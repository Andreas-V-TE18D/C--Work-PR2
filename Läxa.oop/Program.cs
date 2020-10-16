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
                Console.WriteLine("Vill du gå in i butiken?");
                if (Console.ReadLine().ToLower() == "ja") 
                {
                    Console.WriteLine("Villken Hylla vill du gå til?");
                    Console.WriteLine("(1) Husdjurs hyllan");
                    Console.WriteLine("(2) Vapen Hyllan");
                    Console.WriteLine("(3) Mjölkprodukters hylla");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    var product = new Product() { _productName = Console.ReadLine() };

                }


                else
                    break;

                Console.WriteLine("Do you want to view your cart?");
                if (Console.ReadLine().ToLower() == "ja")
                    foreach (var item in kund._cart)
                        Console.WriteLine(item._productName);
                else
                    Console.WriteLine("Suck a duck!");






            }
        }
    }
}