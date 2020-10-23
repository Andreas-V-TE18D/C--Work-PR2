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
                    Console.WriteLine("Villken Avdelning vill du gå til?");
                    Console.WriteLine("(1) Husdjurs Avdelningen ");
                    Console.WriteLine("(2) Vapen avdelningen");
                    Console.WriteLine("(3) Mjölkprodukters avdelning");

                    
                }
                int avdelning = Convert.ToInt32(Console.ReadLine());
                if (avdelning == 1)
                {
                    Console.WriteLine("Husdjurs Avdelningen ");
                    Console.WriteLine("");

                }
                else if (avdelning == 2) 
                {
                    Console.WriteLine("Vapen avdelningen");

                }
                else if (avdelning == 3)
                {
                    Console.WriteLine("Mjölkprodukters avdelning");
                }






            }
        }
    }
}