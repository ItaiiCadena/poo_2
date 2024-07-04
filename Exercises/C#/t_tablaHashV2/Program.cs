using System;
using System.IO;

namespace tablaHash
{
    class LeerArchivo 
    {
        string texto;
        string[] palabra;
        public LeerArchivo(string archivo) 
        {
            texto = File.ReadAllText(archivo); 
            palabra = texto.Split('\n'); 
        }

        public string GetPalabra(int x)
        {
            string word = palabra[0];
            for(int i = 0; i<palabra.Length; i++)
            {
                if(x == i) 
                {
                     word =  palabra[i]; 
                }
            }
                return word; 
        }
        public void MostrarPalabras() 
        {
            foreach(string word in palabra)
            {
                Console.WriteLine(word); 
            }
        }
    }
    class FuncionHash 
    {
        double[] tablaHash = new double[13];
        string[] tablaPalabras = new string[13]; 
        public FuncionHash(int tamanio) 
        {
            double[] tablaHash = new double[tamanio];
            string[] tablaPalabras = new string[tamanio];
        }
        
        public double GeneraClave(string palabra, int tamanioTabla) 
        {
            int i = 1, n = palabra.Length;
            double resultado = 0; 
            foreach(char x in palabra)
            {
                int p = Convert.ToInt32(x)-64;
                resultado += (p * Math.Pow(10, n - i)); 
                i++;
            }
            return (resultado%tamanioTabla);
        }

        public void asignaPalabras(LeerArchivo entrada, int tamanioTabla)
        {
            string mipalabra; 
            double pos = 0; 
            int aux = 0;
            for(int i = 0; i < tablaHash.Length; i++)
            {
                mipalabra = entrada.GetPalabra(i); 
                pos = GeneraClave(mipalabra,tamanioTabla);
                aux = Convert.ToInt32(pos);
                tablaHash[aux] = pos; 
                tablaPalabras[aux] = mipalabra;
                                               
            }
        }

        public void MostrarTablaPalabras()
        {
            Console.WriteLine("HASH PALABRAS");
            for(int i = 0; i < tablaPalabras.Length; i++)
            {
                Console.WriteLine("{0}       {1}", i, tablaPalabras[i]);
            }
        }

        public void MostrarTablaHash()
        {
            Console.WriteLine("Tabla Hash");
            for(int i = 0; i < tablaHash.Length; i++)
            {
                Console.WriteLine(tablaHash[i]);
            }
        }
    }

    class MainClass{
        public static void Main(string[] args) 
        {
            int var;
            Console.WriteLine("Tabla Hash");
            LeerArchivo arch = new LeerArchivo("Palabras.txt");
            LeerArchivo entrada = new LeerArchivo("EntradaPalabras.txt");
            Console.WriteLine("Dimension de la tabla: ");
            var = Int32.Parse(Console.ReadLine());
            FuncionHash tabla = new FuncionHash(var);
            tabla.asignaPalabras(arch, var);
            tabla.MostrarTablaPalabras();
        }
    }
}
