using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMEERIMINE
{
    internal class Osa_2
    {
        public static void Teine_osa()
        {

            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Juku ja kinno");
            Console.WriteLine("2. Pinginaabrid");
            Console.WriteLine("3. Remont ja pindala");
            Console.WriteLine("4. Alghinna leidmine (-30%)");
            Console.WriteLine("5. Temperatuuri kontroll");
            Console.WriteLine("6. Pikkus ja sugu");
            Console.WriteLine("7. Pood (ostukorv)");
            Console.Write("\nSinu valik: ");

            string valik = Console.ReadLine();
            switch (valik)
            {
                case "1":
                    JukuJaKino();
                    break;

                case "2":
                    Pinginaabrid();
                    break;

                case "3":
                    RemontJaPindala();
                    break;

                case "4":
                    AlghinnaLeidmine();
                    break;

                case "5":
                    TemperatuuriKontroll();
                    break;

                case "6":
                    PikkusJaSugu();
                    break;

                case "7":
                    Pood();
                    break;

                default:
                    Console.WriteLine("Vale valik!");
                    break;
            }

        }
        public static void JukuJaKino()
        {
            Console.WriteLine("Sisesta eesnimi:");
            string eesnimi = Console.ReadLine() ?? "";
            if (eesnimi.ToLower() == "juku")
            {
                Console.WriteLine($"{eesnimi}, lahme kinno!");
                Console.Write($"{eesnimi}, sisesta vanus:");
                int vanus = Convert.ToInt32(Console.ReadLine());

                if (vanus < 0 || vanus > 100)
                {
                    Console.WriteLine("Viga andmetega!");
                }
                else if (vanus < 6)
                {
                    Console.WriteLine("Tasuta");
                }
                else if (vanus <= 14)
                {
                    Console.WriteLine("Lastepilet");
                }
                else if (vanus <= 65)
                {
                    Console.WriteLine("Täispilet");
                }
                else Console.WriteLine("Sooduspilet");
            }
            else Console.WriteLine($"Vabandust {eesnimi}, ma tahan Jukuga kinno minna.");
        }
        public static void Pinginaabrid()
        {
            Console.WriteLine("Tere, sisesta sinu nimi:");
            string nimi1 = Console.ReadLine() ?? "";
            Console.WriteLine($"Tere, {nimi1}");
            Console.WriteLine("Tere, sisesta sinu nimi:");
            string nimi2 = Console.ReadLine() ?? "";
            Console.WriteLine($"Tere, {nimi2}. Nuud olete teie ja {nimi1} pinginaabrid)");

        }

        public static void RemontJaPindala()
        {
            Console.Write("Sein A (m): "); double a = double.Parse(Console.ReadLine());
            Console.Write("Sein B (m): "); double b = double.Parse(Console.ReadLine());
            double s = a * b;
            Console.WriteLine($"Pindala: {s} m2.");
            Console.Write("Kas teeme remondi? (jah/ei): ");
            if (Console.ReadLine().ToLower() == "jah")
            {
                Console.Write("Ruutmeetri hind: ");
                double hind = double.Parse(Console.ReadLine());
                Console.WriteLine($"Hind kokku: {s * hind} eurot.");
            }
            else Console.WriteLine("Head aega.");
        }
        public static void AlghinnaLeidmine()
        {
            Console.Write("Hind pärast -30%: ");
            double soodus = double.Parse(Console.ReadLine() ?? "");
            Console.WriteLine($"Alghind oli: {Math.Round(soodus / 0.7, 2)}");
        }
        public static void TemperatuuriKontroll()
        {
            Console.Write("Temperatuur: ");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine(t > 18 ? "See on soe (üle 18 kraadi)." : "See on jahe.");
        }
        public static void PikkusJaSugu()
        {
            Console.Write("Sugu (m/n): "); string sugu = Console.ReadLine().ToLower();
            Console.Write("Pikkus (cm): "); int p = int.Parse(Console.ReadLine());
            if (sugu == "m")
            {
                if (p < 170) Console.WriteLine("Lühike mees.");
                else if (p <= 185) Console.WriteLine("Keskmine mees.");
                else Console.WriteLine("Pikk mees.");
            }
            else
            {
                if (p < 160) Console.WriteLine("Lühike naine.");
                else if (p <= 175) Console.WriteLine("Keskmine naine.");
                else Console.WriteLine("Pikk naine.");
            }
        }
        public static void Pood()
        {
            double summa = 0;
            string[] tooted = { "piima", "saia", "leiba" };
            double[] hinnad = { 1.2, 0.8, 0.95 };
            for (int i = 0; i < tooted.Length; i++)
            {
                Console.Write($"Kas soovid osta {tooted[i]}? (jah/ei): ");
                if (Console.ReadLine().ToLower() == "jah") summa += hinnad[i];
            }
            Console.WriteLine($"Ostukorvi hind: {summa} eurot.");

        }

    }
}
