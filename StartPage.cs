using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMEERIMINE
{
    internal class StartPage
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Tere tulemast!");
                Console.WriteLine("Milline ülesanne osa kas te tahaksite jooksma panna?");

                Console.WriteLine("1. Osa");
                Console.WriteLine("2. Osa");
                Console.WriteLine("3. Osa");

                Console.Write("Sinu valik: ");
                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1":
                        Osa_1.Esimene_osa();
                        break;
                    case "2":
                        Osa_2.Teine_osa();
                        break;
                    case "3":
                        Osa_3.Kolmas_osa();
                        break;
                }
            }
        }
    }
}
