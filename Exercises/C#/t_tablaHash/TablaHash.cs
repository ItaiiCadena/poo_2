using System;
using System.IO;

namespace tablaHash
{
    class LeerArchivo ///Esta clase es para leer el archivo que contiene las palabras
    {
        string texto;
        string[] palabra;
        public LeerArchivo(string archivo) ///Aqui lee el archivo, tambien es su constructor
        {
            texto = File.ReadAllText(archivo); //Te saca las palabras de manera vertical
            palabra = texto.Split('\n'); //Te acomoda las palabras en lista
        }

        //Esta funcion yo la cree para que de la lista me regrese la palabra de la posicion que le estoy indicando
        public string GetPalabra(int x)  //x es la posicion de la palabra que quiero que me regrese
        {
            string word = palabra[0]; //Aqui solo incialize mi string con la primera palabra del array
            for(int i = 0; i<palabra.Length; i++)
            {
                if(x == i) //Hago la comparacion
                {
                     word =  palabra[i]; //Guardo en el string el valor que quiero que me regrese
                }
            }
                return word; //Lo regreso xd
        }
        public void MostrarPalabras() //Esta no la ocupo en la clase, solo era para verificar que si leyera bien el documento
        {
            foreach(string word in palabra)
            {
                Console.WriteLine(word); //Escribe en pantalla las palabras
            }
        }
    }
    class FuncionHash //Esta es la clase de la tablas HASH
    {
        double[] tablaHash = new double[8]; //Este array almacena las claves de las palabras
        string[] tablaPalabras = new string[8]; //Este array almacena las palabras
        public FuncionHash() //Constructor
        {}
        //Esta funcion sirve para generar la clave, sus parametros son una palabra y el tamanio de nuestra tabla yo le puse 13
        //No confundas con el tamanio de tablaHash, el array de arriba xd
        public double GeneraClave(string palabra, int tamanioTabla) 
        {
            int i = 1, n = palabra.Length; //n contiene el tamanio de la palabra
            double resultado = 0; //resultado almacena el resultado xd
            foreach(char x in palabra)
            {
                int p = Convert.ToInt32(x)-64; //p guarda el valor de la letra p/e A en ASCII es 65 - 64 = 1, y asi
                resultado += (p * Math.Pow(10, n - i)); //Esto ahorita te lo explico
                i++;
            }
            return (resultado%tamanioTabla); //aqui el valor lo convierto a int para que se pueda guardar en mi array de int
        }

        //Esta funcion guarda en los arreglos los valores generados por clave (en tablaHash) y las palabras en (tablaPalabras)
        public void asignaPalabras(LeerArchivo entrada, int tamanioTabla) //Tiene como parametros el archivo y el tanio de la tabla, yo puse 13
        {
            string mipalabra; // guarda la palabra
            double pos = 0; //guarda la posicion
            int aux = 0;
            for(int i = 0; i < tablaHash.Length; i++)
            {
                mipalabra = entrada.GetPalabra(i); //se extrae la palabra en i y se guarda en "mipalabra"
                pos = GeneraClave(mipalabra,tamanioTabla);//se genera la clave de la palabra y se guarda en pos
                aux = Convert.ToInt32(pos);
                tablaHash[aux] = pos; //pos se guarda en tablaHash en pos. p/e si nos dio 7, entonces tablaHash[7] = 7
                Console.WriteLine(tablaHash[i]);
                tablaPalabras[aux] = mipalabra; //mipalabra se guarda en tablaPalabras en pos. p/e si la palabra es CUBO y su clave es 7
                Console.WriteLine(tablaPalabras[i]);                                //tablaPalabras[7] = CUBO y asi sucesivamente.
            }
            //MostrarTabla(); //Aqui se supone deberia mostrar la tabla :(
        }

        //Funcion para mostrar ambos arrays
        public void MostrarTabla()
        {
            for(int i = 0; i < tablaHash.Length; i++)
            {
                Console.WriteLine("{0}  {1}", tablaHash[i], tablaPalabras[i]);
            }
        }
    }

    class MainClass{
        public static void Main(string[] args) 
        {
            Console.WriteLine("Tabla Hash");
            LeerArchivo arch = new LeerArchivo("Palabras.txt"); //Este es mi archivo txt que contiene la palabras
            FuncionHash tabla = new FuncionHash();
            tabla.asignaPalabras(arch, 13); //se invoca a la funcion que asigna las palabras en los arrays
        }
    }
}