using System;

namespace Hola
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double xa, xb, ya, yb;

            xa = 0;
            ya = 0;

            xb = 5;
            yb = 5;

            Console.WriteLine("La distancia entre el punto A({0},{1}) y B({2},{3}) es: {4}", xa, ya, xb, yb, Math.Sqrt(Math.Pow(xb - xa, 2) + Math.Sqrt(Math.Pow(yb - ya, 2))));
        }
    }
}