using System;
using System.Collections.Generic;

namespace legtobb_kiesett31
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

        static int kiesett(int i)
        {
            int db = 0;
            
            for (int j = 0; j < m; j++)
            {
                if (p[i, j] < minp[j]) db++;
            }

            return db;
        }
        
        static void Main(string[] args)
        {
            beolvas();
            
            int[] kidb = new int[n];

            for (int i = 0; i < n; i++)
            {
                kidb[i] = kiesett(i);
            }

            int maxi = -1, hely;
            for (int i = 0; i < n; i++)
            {
                if (maxi < kidb[i])
                {
                    maxi = kidb[i];
                    hely = i;
                }
            }
            
            Console.WriteLine(hely);
        }
    }
}