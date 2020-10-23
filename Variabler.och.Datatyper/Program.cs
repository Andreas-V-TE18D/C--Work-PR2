using System;

namespace Variabler.och.Datatyper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Niklas");

            //Frågar om namn ålder och om du är vid liv 
            Console.WriteLine("Skriv Din Ålder");
            Console.WriteLine("Skriv Ditt Namn");
            Console.WriteLine("Skriv om Du är död eller levande"); 
            Console.WriteLine("")
            //tar input från användaren 
            int age = Convert.ToInt32(Console.ReadLine());
            string namn = (Console.ReadLine());
            string liv = (Console.ReadLine());

            // Enkel if sats som skriver ut om du är död eller vid liv 
            if (liv == "död")
            {
                Console.WriteLine("Du är död");
            }
            else if (liv == "levande")
            {
                Console.WriteLine("Du är Vid liv");
            }


            // skriver ut input från användaren 
            Console.WriteLine("Din ålder är  " + age );
            Console.WriteLine("Ditt namn är " + namn);
            


        }
    }
}
