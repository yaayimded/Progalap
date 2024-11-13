using System;
using System.Collections.Generic;

namespace bor5
{
    class Program
    {
        static int n;
        static Adat[] bor;

        struct Adat
        {
            public int db;
            public int ar;
        }
        
        static void beolvas()
        {
            string be = Console.ReadLine();
            n = int.Parse(be);
            
            bor = new Adat[n];

            for (int i = 0; i < n; i++)
            {
                be = Console.ReadLine();
                string[] darabok = be.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                bor[i].db = int.Parse(darabok[0]);
                bor[i].ar = int.Parse(darabok[1]);
            }
        }

        static bool nemVoltMeg(int i)
        {
            for (int j = 0; j < i; j++)
            {
                if (bor[j].ar == bor[i].ar) return false;
            }

            return true;
        }

        static bool yap(int i)
        {
            for (int j = 0; j < i; j++)
            {
                if(bor[i].db <= bor[j].db) return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            beolvas();

            int mini = bor[0].db;
            int kisTermelEv = 0;

            for (int i = 0; i < n; i++)
            {
                if (bor[i].db < mini)
                {
                    mini = bor[i].db;
                    kisTermelEv = i + 1;
                }
            }

            Console.WriteLine(kisTermelEv);

            int nagyAr = -1;
            int maxi = -1;

            for (int i = 0; i < n; i++)
            {
                if (1000 < bor[i].db && maxi < bor[i].db)
                {
                    maxi = bor[i].db;
                    nagyAr = bor[i].ar;
                }
            }

            Console.WriteLine(nagyAr);

            int arSzam = 0;

            for (int i = 0; i < n; i++)
            {
                if (nemVoltMeg(i)) arSzam++;
            }

            Console.WriteLine(arSzam);

            int db = 0;
            List<int> nagyobb = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (yap(i))
                {
                    db++;
                    nagyobb.Add(i + 1);
                }
            }

            Console.WriteLine(db + " " + string.Join(" ", nagyobb));
        }
    }
        
}