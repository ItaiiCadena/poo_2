using System;

namespace HashABC
{
    class FuncionHash
    {
        public FuncionHash(){}
        public int GeneraClave(char a, int TamanioTabla)
        {
            int n = Convert.ToInt32(a) - 64;
            return ((n-1)%TamanioTabla);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tabla Hash ABC");
            FuncionHash funcion = new FuncionHash();
            string[] palabra = {"Ave", "Cubeta", "Castillo", "Oso", "Zapato"};
            char[] caracter = {'A','B','C','D','E'};
            char[] tabla = new char[5];
            int indice;
            //indice = funcion.GeneraClave(caracter[0], tabla.Length);
            //tabla[indice] = caracter[indice];
            char leerChar = Convert.ToChar(Console.Read());
            indice = funcion.GeneraClave(leerChar, tabla.Length);
            tabla[indice] = leerChar;
            for(int i=1; i<tabla.Length; i++)
            {
                Console.WriteLine(tabla[i]);
            }
        }
    }
}
