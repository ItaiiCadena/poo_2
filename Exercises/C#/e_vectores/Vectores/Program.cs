using System;

namespace SumaPuntos
{
    class coordenadas
    {
        public double x, y;
        public coordenadas()
        {
            x = 0; y = 0;
        }

        public void valores()
        {
            string x1, y1;
            Console.WriteLine("Ingresa X1 de la coordenada:");
            x1 = Console.ReadLine();
            x = double.Parse(x1);
            Console.WriteLine("Ingresa Y2 de la coordenada:");
            y1 = Console.ReadLine();
            y = double.Parse(y1);
        }

        public coordenadas sumar(coordenadas A, coordenadas B)
        {
            coordenadas C = new coordenadas();
            C.x = B.x - A.x;
            C.y = B.y - A.y;
            return C;
        }

        public coordenadas sumarP(coordenadas C, coordenadas p)
        {
            coordenadas D = new coordenadas();
            D.x = C.x + p.x;
            D.y = C.y + p.y;
            return D;
        }

        public void MostrarCoordenadas(char nom)
        {
            Console.WriteLine("{0}({1},{2})", nom, x, y);
        }

        class MainClass
        {
            public static void Main(string[] args)
            {
                coordenadas A = new coordenadas();
                coordenadas B = new coordenadas();
                coordenadas aux = new coordenadas(); //poner lo que salga de la suma 
                coordenadas P = new coordenadas(); //coordenada a sumar 
                Console.WriteLine("Coordenadas A");
                A.valores();
                Console.WriteLine("Coordenadas B");
                B.valores();
                Console.WriteLine("La suma de los vectores es:");
                aux = aux.sumar(A, B); aux.MostrarCoordenadas('C');
                Console.WriteLine("Ingresa nueva coordenada P");
                P.valores();
                Console.WriteLine("La suma del vector  AB=C y P :");
                aux = aux.sumarP(aux, P); aux.MostrarCoordenadas('D');
            }
        }
    }
}

