using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMEERIMINE
{
    internal class Osa_1
    {
        public static void Esimene_osa()
        {
            Console.WriteLine("1. Osa Andmetüübid");

            string tekst = "Tere tulemast C# maailma!";

            Console.WriteLine("Oli loodud muutuja tekst, mis võrdub: {0}", tekst);

            Console.Write("Mis on sinu nimi?: ");
            string nimi = Console.ReadLine();

            Console.Write("Kui vana sa oled?: ");

            try
            {
                int vanus = int.Parse(Console.ReadLine());
                Console.WriteLine($"Tere {nimi}. Sa oled {vanus} aastat vana");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                Console.Write("Arv 1");
                float a = float.Parse(Console.ReadLine());
                Console.Write("Arv 2");
                float b = float.Parse(Console.ReadLine());
                float vastus = Naidis_funktsioonid.Summa(a, b);
                Console.WriteLine($"Summa {a} ja {b} võrdub {vastus}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
