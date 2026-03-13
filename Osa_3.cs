using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMMEERIMINE
{
    internal class Osa_3
    {
        public static void Kolmas_osa()
        {
            bool jookseb = true;

            while (jookseb)
            {
                Console.Clear();
                Console.WriteLine("=== PROGRAMMEERIMISE ÜLESANDED ===");
                Console.WriteLine("1. Juhuslike arvude ruudud");
                Console.WriteLine("2. Viie arvu analüüs");
                Console.WriteLine("3. Nimed ja vanused");
                Console.WriteLine("4. Osta elevant ära!");
                Console.WriteLine("5. Arvamise mäng");
                Console.WriteLine("6. Suurim neliarvuline arv");
                Console.WriteLine("7. Korrutustabel");
                Console.WriteLine("8. Õpilastega mängimine");
                Console.WriteLine("9. Arvude ruudud (massiiv)");
                Console.WriteLine("10. Positiivsed ja negatiivsed");
                Console.WriteLine("11. Keskmisest suuremad");
                Console.WriteLine("12. Suurima arvu otsing");
                Console.WriteLine("13. Paari- ja paaritud loendused");
                Console.WriteLine("0. Välju (välju)");
                Console.Write("\nVali ülesande number: ");

                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1": JuhuslikeArvudeRuudud(); break;
                    case "2": ViieArvuAnaluus(); break;
                    case "3": NimedJaVanused(); break;
                    case "4": OstaElevant(); break;
                    case "5": ArvamiseMang(); break;
                    case "6": SuurimNeliarvuline(); break;
                    case "7": KorrutustabeliUlesanne(); break;
                    case "8": OpilasteMang(); break;
                    case "9": ArvudeRuududMassiivist(); break;
                    case "10": PosNegNull(); break;
                    case "11": KeskmisestSuuremad(); break;
                    case "12": SuurimOtsing(); break;
                    case "13": PaariPaaritu(); break;
                    case "0":
                    case "välju":
                        jookseb = false;
                        continue;
                    default:
                        Console.WriteLine("Vale valik! Vajuta ENTER, et proovida uuesti.");
                        Console.ReadLine();
                        continue;
                }

                Console.WriteLine("\n");
                Console.WriteLine("Vajuta ENTER, et naasta peamenüüsse...");
                Console.ReadLine();
            }
        }


        public static void JuhuslikeArvudeRuudud()
        {
            Console.Clear();
            Console.WriteLine("1. Juhuslike arvude ruudud\n");
            ArvuTöötlus tootlus = new ArvuTöötlus();
            int n, m;
            int[] ruudud = tootlus.GenereeriRuudud(1, 10, out n, out m);
            int väiksem = Math.Min(n, m);
            for (int i = 0; i < ruudud.Length; i++) Console.WriteLine($"{väiksem + i} -> {ruudud[i]}");
        }

        public static void ViieArvuAnaluus()
        {
            Console.Clear();
            Console.WriteLine("2. Viie arvu analüüs\n");
            double[] arvud = Tekstist_arvud();
            var tuple = AnalüüsiArve(arvud);
            Console.WriteLine("\nTulemused:");
            Console.WriteLine("Summa: " + tuple.Item1);
            Console.WriteLine("Keskmine: " + tuple.Item2);
            Console.WriteLine("Korrutis: " + tuple.Item3);
        }

        public static double[] Tekstist_arvud()
        {
            Console.Write("Sisesta 5 arvu (tühikuga): ");
            string[] osad = Console.ReadLine().Split(' ');
            double[] arvud = new double[5];
            for (int i = 0; i < 5; i++) arvud[i] = double.Parse(osad[i]);
            return arvud;
        }

        public static Tuple<double, double, double> AnalüüsiArve(double[] arvud)
        {
            double summa = 0, korrutis = 1;
            foreach (var a in arvud) { summa += a; korrutis *= a; }
            return new Tuple<double, double, double>(summa, summa / arvud.Length, korrutis);
        }

        public static void NimedJaVanused()
        {
            Console.Clear();
            Console.WriteLine("3. Nimed ja vanused\n");
            List<Inimene> inimesed = new List<Inimene>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Nimi: "); string nimi = Console.ReadLine();
                Console.Write("Vanus: "); int vanus = int.Parse(Console.ReadLine());
                inimesed.Add(new Inimene(nimi, vanus));
            }
            var t = Statistika(inimesed);
            Console.WriteLine($"\nSumma: {t.Item1}, Keskmine: {t.Item2}, Vanim: {t.Item3.Nimi}, Noorim: {t.Item4.Nimi}");
        }

        public static Tuple<int, double, Inimene, Inimene> Statistika(List<Inimene> inimesed)
        {
            int summa = inimesed.Sum(x => x.Vanus);
            return new Tuple<int, double, Inimene, Inimene>(summa, (double)summa / inimesed.Count,
                inimesed.OrderByDescending(x => x.Vanus).First(),
                inimesed.OrderBy(x => x.Vanus).First());
        }

        public static void OstaElevant()
        {
            Console.Clear();
            KuniMärksõnani("elevant", "Osta elevant ära!");
        }

        public static void KuniMärksõnani(string märksõna, string fraas)
        {
            List<string> logs = new List<string>();
            string s = "";
            while (s != märksõna)
            {
                Console.WriteLine(fraas);
                s = Console.ReadLine();
                logs.Add(s);
            }
            Console.WriteLine("\nTeie sisestused:");
            logs.ForEach(Console.WriteLine);
        }

        public static void ArvamiseMang()
        {
            do
            {
                Console.Clear();
                ArvaArv();
                Console.Write("\nUuesti mängida? (jah/ei): ");
            } while (Console.ReadLine().ToLower() == "jah");
        }

        public static void ArvaArv()
        {
            int siht = new Random().Next(1, 101);
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"{i}. katse: ");
                int p = int.Parse(Console.ReadLine());
                if (p == siht) { Console.WriteLine("Õige!"); return; }
                Console.WriteLine(p > siht ? "Liiga suur" : "Liiga väike");
            }
            Console.WriteLine("Läbi! Arv oli " + siht);
        }

        public static void SuurimNeliarvuline()
        {
            Console.Clear();
            int[] numbrid = new int[4];
            for (int i = 0; i < 4; i++) { Console.Write($"Number {i + 1}: "); numbrid[i] = int.Parse(Console.ReadLine()); }
            Array.Sort(numbrid); Array.Reverse(numbrid);
            Console.WriteLine("Suurim arv: " + string.Join("", numbrid));
        }

        public static void KorrutustabeliUlesanne()
        {
            Console.Clear();
            Console.Write("Read: "); int r = int.Parse(Console.ReadLine());
            Console.Write("Veerud: "); int v = int.Parse(Console.ReadLine());
            int[,] tabel = new int[r, v];
            for (int i = 1; i <= r; i++)
            {
                for (int j = 1; j <= v; j++)
                {
                    tabel[i - 1, j - 1] = i * j;
                    Console.Write((i * j).ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }

        public static void OpilasteMang()
        {
            Console.Clear();
            string[] n = { "Andres", "Beata", "Anu", "Dmitri", "Eerik", "Fedor", "Ahti", "Grete", "Hanna", "Igor" };
            n[2] = "Kati"; n[5] = "Mati";
            foreach (var nimi in n) if (nimi.StartsWith("A")) Console.WriteLine("Tere " + nimi);
            for (int i = 0; i < n.Length; i++) Console.WriteLine($"{i}: {n[i]}");
            int k = 0;
            do { Console.WriteLine("Tervitus: " + n[k]); } while (n[k++] != "Mati");
        }

        public static void ArvudeRuududMassiivist()
        {
            int[] arvud = { 2, 4, 6, 8, 10, 12 };
            foreach (var a in arvud) Console.WriteLine($"{a}^2 = {a * a}");
        }

        public static void PosNegNull()
        {
            int[] arvud = { 5, -3, 0, 8, -1, 4, -7, 2, 0, -5, 6, 9 };
            int p = 0, n = 0, z = 0;
            foreach (var a in arvud) if (a > 0) p++; else if (a < 0) n++; else z++;
            Console.WriteLine($"Pos: {p}, Neg: {n}, Null: {z}");
        }

        public static void KeskmisestSuuremad()
        {
            int[] a = Enumerable.Range(0, 15).Select(x => new Random().Next(1, 101)).ToArray();
            double avg = a.Average();
            Console.WriteLine("Keskmine: " + avg);
            foreach (var x in a) if (x > avg) Console.WriteLine("Suurem: " + x);
        }

        public static void SuurimOtsing()
        {
            int[] n = { 12, 56, 78, 2, 90, 43, 88, 67 };
            int max = n[0], idx = 0;
            for (int i = 1; i < n.Length; i++) if (n[i] > max) { max = n[i]; idx = i; }
            Console.WriteLine($"Suurim: {max}, Indeks: {idx}");
        }

        public static void PaariPaaritu()
        {
            List<int> l = Enumerable.Range(0, 20).Select(x => new Random().Next(1, 101)).ToList();
            Console.WriteLine("Paaris summa: " + l.Where(x => x % 2 == 0).Sum());
            Console.WriteLine("Paaritute keskmine: " + l.Where(x => x % 2 != 0).Average());
            Console.WriteLine("Üle 50: " + l.Count(x => x > 50));
        }

      
        public class ArvuTöötlus
        {
            public int[] GenereeriRuudud(int min, int max, out int n, out int m)
            {
                Random r = new Random(); n = r.Next(min, max + 1); m = r.Next(min, max + 1);
                int start = Math.Min(n, m), end = Math.Max(n, m);
                return Enumerable.Range(start, end - start + 1).Select(x => x * x).ToArray();
            }
        }
        public class Inimene
        {
            public string Nimi; public int Vanus;
            public Inimene(string n, int v) { Nimi = n; Vanus = v; }
        }
    }

}

