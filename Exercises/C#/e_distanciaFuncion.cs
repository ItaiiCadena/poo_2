using System;

namespace Hola
{
    class Distancia
    {
        public Distancia()
        { }

        public double Distan(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            double xa, xb, ya, yb;
            Distancia operacion = new Distancia();
            xa = 0;
            ya = 0;

            xb = 5;
            yb = 5;

            Console.WriteLine("La distancia entre el punto A({0},{1}) y B({2},{3}) es: {4}", xa, ya, xb, yb, operacion.Distan(xa, ya, xb, yb));
        }
    }
}