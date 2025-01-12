// Készítette: Kathi Balázs
// Neptun-kód: KQD09G
// E-mail: kathibalazs2005@gmail.com
// Feladat: A települések legalább felében felmelegedő napok

using System;
using System.Collections.Generic;

namespace kqd09g_ck
{
    class Program
    {
        static int[,] beolvas()
        {
            if (Console.IsOutputRedirected) return beolvas_biro();
            else return beolvas_kezi();
        }

        static int[,] beolvas_biro()
        {
            string[] darabok = Console.ReadLine().Split(" ");
            
            int n = int.Parse(darabok[0]);
            int m = int.Parse(darabok[1]);
            int[,] hom = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                darabok = Console.ReadLine().Split(" ");
                for (int j = 0; j < m; j++)
                {
                    hom[i, j] = int.Parse(darabok[j]);
                }
            }

            return hom;
        }

        static int[,] beolvas_kezi()
        {
            // n beolvasasa hibaellenorzessel
            Console.Write("Telepulesek szama(n): ");
            string be = Console.ReadLine();
            int n;

            while (!int.TryParse(be, out n) || n < 1 || n > 1000)
            {
                Console.WriteLine("Helytelen adat");
                Console.WriteLine("1 <= n <= 1000");
                Console.Write("Telepulesek szama(n): ");
                be  = Console.ReadLine();
            }

            // m beolvasasa hibaellenorzessel
            int m;
            Console.Write("Napok szama(m): ");
            be = Console.ReadLine();

            while (!int.TryParse(be, out m) || m < 1 || m > 1000)
            {
                Console.WriteLine("Helytelen adat");
                Console.WriteLine("1 <= m <= 1000");
                Console.Write("Napok szama(m): ");
                be  = Console.ReadLine();
            }
            
            // matrix beolvasasa hibaellenorzessel
            int[,] hom = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write((i + 1) + ". telepules " + (j + 1) + ". nap: ");
                    be = Console.ReadLine();

                    while (!int.TryParse(be, out hom[i, j]) || hom[i, j] < -50 || hom[i, j] > 50)
                    {
                        Console.WriteLine("Helytelen adat");
                        Console.WriteLine("-50 <= hom[i, j] <= 50");
                        Console.Write((i + 1) + ". telepules " + (j + 1) + ". nap: ");
                        be = Console.ReadLine();
                    }
                }
            }

            return hom;
        }
            
        static int meleged(int i, int[,] hom) 
        {
            int db = 0;
            int n = hom.GetLength(0);
            //Console.WriteLine("Erre vagyok kivancsi: " + n);
            
            for (int j = 0; j < n; j++)
            {
                if (hom[j, i] > hom[j, i - 1]) db++;
            } 
            return db;
        }

        static (int db, List<int> ki) kivalogat(int[,] hom)
        {
            int db = 0;
            List<int> ki = new List<int>();
            int n = hom.GetLength(0);
            int m = hom.GetLength(1);
            
            for (int i = 1; i < m; i++)
            {
                if (2 * meleged(i, hom) >= n)
                {
                    db++;
                    ki.Add(i + 1);
                }
            }
            
            return (db, ki);
        }

        static void vege()
        {
            Console.WriteLine("Kerem nyomjon ENTER-t a folyatatashoz");
            Console.ReadLine();
        }

        static void kiir(int db, List<int> ki)
        {
            if (Console.IsOutputRedirected)
            {
                Console.Write(db + " " + string.Join(" ", ki));
            }
            else
            {
                if (db == 0)
                {
                    Console.WriteLine("Nincs a feltételnek megfelelo nap.");
                    vege();
                    return;
                }
                Console.WriteLine(db + " darab nap felel meg a feltetelnek, sorszamaik:");
                Console.WriteLine(string.Join(", ", ki));
                vege();
                return;
            }
        }
        
        static void Main(string[] args)
        {
            int[,] hom = beolvas();
            int db;
            List<int> ki = new List<int>();
            
            (db, ki) = kivalogat(hom);
            
            kiir(db, ki);
        }
    }
}
