using System;

namespace TIK
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод P(X)
            double[] px = new double[3];

            for (int x = 0; x < px.Length; x++)
            {
                Console.Write("P(X{0})=", x+1);
                px[x] = Convert.ToDouble(Console.ReadLine());
            }

            //Ввод Q
            Console.Write("Q=");
            double q = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            //Вывод P(Z/X)
            double[,] pzx = new double[3, 3] { { 1 - q * 2, q, q },
                                               { q, 1 - q * 2, q },
                                               { q, q, 1 - q * 2 } };
            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    Console.Write(pzx[x,z] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Вывод H(X)
            double hx = 0;

            for (int x = 0; x < px.Length; x++)
            {
                hx = hx + (-px[x] * Math.Log(px[x], 2));
            }

            Console.WriteLine("H(X)= " + hx + "\n");

            //Вывод P(Z)
            double[] pz = new double[3];

            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    pz[x] = pz[x] + px[z] * pzx[x, z];
                }
                Console.WriteLine("P(Z)=" + pz[x]);
            }
            Console.WriteLine();

            //Вывод P(X/Z)
            double[,] pxz = new double[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    pxz[x, z] = (px[x] * pzx[x, z]) / pz[z];
                    Console.WriteLine("P(X/Z){0},{1} = {2}", x+1, z+1, pxz[x,z]);
                }
            }
            Console.WriteLine();

            //Вывод H(X/Z)
            double hxz = 0;

            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    hxz = hxz + (- pz[z] * (pxz[x, z] * Math.Log(pxz[x, z], 2)));
                }
            }
            Console.WriteLine("H(X/Z)= " + hxz + "\n");

            //Вывод I(Z/X)
            double izx = hx - hxz;
            Console.WriteLine("I(Z/X)= " + izx);

            Console.ReadLine();
        }
    }
}
