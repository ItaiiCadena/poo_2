using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace SumVecEsc
{
    class Vectores
    {
        public int x, y;
        public Vectores()
        {
            x = 0;
            y = 0;
        }

        public void LeerDatos()
        {
            string point1, point2;
            Console.WriteLine("Ingrese x:"); point1 = Console.ReadLine();
            x = int.Parse(point1);
            Console.WriteLine("Ingrese y:"); point2 = Console.ReadLine();
            y = int.Parse(point2);
        }

        public void MostrarDatos(char nom)
        {
            Console.WriteLine("{0}({1},{2})", nom, x, y);
        }

        public Vectores SumaVectores(Vectores A, Vectores B)
        {
            Vectores C = new Vectores();
            C.x = A.x + B.x; C.y = A.y + B.y;
            return C;
        }

        public Vectores SumaEscalar(Vectores C, int escalar)
        {
            Vectores D = new Vectores();
            D.x = C.x + escalar; D.y = C.y + escalar;
            return D;
        }

        class MainClass
        {
            public static void Main(string[] args)
            {
                Vectores Punto1 = new Vectores();
                Vectores Punto2 = new Vectores();
                Vectores PuntoRes = new Vectores();
                int escalar;
                Console.WriteLine("Ingrese las coordenadas de los puntos.");
                Console.WriteLine("Coordenadas para A."); Punto1.LeerDatos(); Punto1.MostrarDatos('A');
                Console.WriteLine("Coordenadas para B."); Punto2.LeerDatos(); Punto2.MostrarDatos('B');
                Console.WriteLine("La suma de los vectores es:"); 
                PuntoRes = PuntoRes.SumaVectores(Punto1, Punto2); PuntoRes.MostrarDatos('C');
                Console.WriteLine("Ingrese un escalar para sumarlo al vector");
                string esc = Console.ReadLine();
                escalar = int.Parse(esc);
                Console.WriteLine("La suma del vector C y el escalar {0} es:", escalar);
                PuntoRes = PuntoRes.SumaEscalar(PuntoRes, escalar); PuntoRes.MostrarDatos('D');
            }
        }
    }
}