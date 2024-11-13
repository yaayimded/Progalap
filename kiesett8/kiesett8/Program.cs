using System;
using System.Collections.Generic;

namespace kiesett8
{
    internal class Program
    {
        private static int n, m;
        private static int[] maxp, minp;
        private static int[,] p;

        static void beolvas()
        {
            string bemenet = Console.ReadLine();
            string[] darabok = bemenet.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            n = int.Parse(darabok[0]);
            m = int.Parse(darabok[1]);
            maxp = new int[m];
            minp = new int[m];
            p = new int[n, m];
            
            bemenet = Console.ReadLine();
            darabok = bemenet.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < m; i++)
            {
                maxp[i] = int.Parse(darabok[i]);
            }
            
            bemenet = Console.ReadLine();
            darabok = bemenet.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < m; i++)
            {
                minp[i] = int.Parse(darabok[i]);
            }

            for (int i = 0; i < n; i++)
            {
                bemenet = Console.ReadLine();
                darabok = bemenet.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    p[i, j] = int.Parse(darabok[j]);
                }
            }
        }

        static bool kiesett(int i)
        {
            int j = 0;

            while (j < m && p[i, j] >= minp[j])
            {
                j++;
            }

            return j < m;
        }

        static int osszpont(int i)
        {
            int s = 0;

            for (int j = 0; j < m; j++)
            {
                s += p[i, j];
            }

            return s;
        }
        
        static void Main(string[] args)
        {
            beolvas();

            int db = 0;
            List<int> pontsz = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (kiesett(i))
                {
                    db++;
                    pontsz.Add(osszpont(i));
                }
            }
            
            Console.WriteLine(db + " " + string.Join(" ", pontsz));
        }
    }
}