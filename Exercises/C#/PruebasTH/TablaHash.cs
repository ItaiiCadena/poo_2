using System;
using System.IO;

namespace tablaHash
{
    //Clase para leer el archivo .txt
    class LeerArchivo  
    {
        public string texto; //Guarda las palabras
        public string[] palabra; //Guarda las  palabras en un arreglo
        public LeerArchivo(string archivo) //Constructor
        {
            texto = File.ReadAllText(archivo); 
            palabra = texto.Split('\n'); //Guarda las palabras en el arreglo siempre y cuando esten separadas por enter
        }

        public void MostrarPalabras() //Funcion para mostrar las palabras
        {
            foreach(string word in palabra)
            {
                Console.WriteLine(word); 
            }
        }
    }
    class FuncionHash //Clase para crear la tabla, asignarle una clave a las palabras y mostrar los datos
    {
        string[] tablaPalabras; double clave; int Base; int tamanio;
        LeerArchivo entrada;
        public FuncionHash(int newTamanio, int newBase) //Constructor
        {
            tamanio = newTamanio;
            tablaPalabras = new string[tamanio];
            clave = 0;
            Base = newBase;
            entrada = new LeerArchivo("Palabras.txt");
        }

        public double GeneraClave(string palabra) //Funcion que genera la clave que tendra la palabra
        {
            int i = 1, n = palabra.Length;
            double resultado = 0; 
            foreach(char x in palabra)
            {
                int p = Convert.ToInt32(x)-64;
                resultado += (p * Math.Pow(Base, n - i)); 
                i++;
            }
            return (resultado%tamanio);
        }

        public void asignaPalabras() //Funcion que asigna en la tabla la palabra en la posicion que indica la clave
        {
            int aux = 0;
            foreach(string word in entrada.palabra)
            {
                clave = GeneraClave(word);
                aux = Convert.ToInt32(clave);
                if(tablaPalabras[aux] == null)
                {
                    tablaPalabras[aux] = word;
                }
                else //Si el lugar ya esta ocupado, lo asignara en el espacio siguiente
                {
                    tablaPalabras[aux + 1] = word;
               }
            }
        }

        public void MostrarDatos() //Funcion que muestra las claves y las palabras
        {
            foreach(string word in entrada.palabra)
            {
                Console.WriteLine("Clave: " + "[" + GeneraClave(word) + "]" + " Palabra: " + word);
            }
        }

        public void MostrarTabla() //Funcion que muestra la tabla que contiene las palabras
        {
            for(int i = 0; i < tablaPalabras.Length; i++)
            {
                Console.WriteLine("[" + i + "]" + " " + tablaPalabras[i]);
            }
        }
    }

    class MainClass{
        public static void Main(string[] args) 
        {
            int var, var1;
            //Se piden datos al usuario
            Console.WriteLine("Tabla Hash Version USUARIO");
            Console.WriteLine("Dimension de la tabla: ");
            var = int.Parse(Console.ReadLine());
            Console.WriteLine("Base de la clave: ");
            var1 = int.Parse(Console.ReadLine());
            //Se crea un objeto de la clase funcion hash, con los datos que ha proporcionado el usuario
            FuncionHash tabla = new FuncionHash(var, var1);
            //Invocacion de las funciones
            tabla.asignaPalabras(); 
            Console.WriteLine("Palabras con su clave");
            tabla.MostrarDatos();
            Console.WriteLine("------Datos en tabla------");
            tabla.MostrarTabla();
        }
    }
}
