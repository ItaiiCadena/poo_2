using System;

namespace Hash{
class FuncionHash
{
  public FuncionHash()
  {}
  public void MostrarDatos(char[] clave)
  {
        int p=0;
        int n = clave.Length;
        int i = 1;
        double resultado = 0;
        foreach(char x in clave)
        {
            p = Convert.ToInt32(x)-64;
            resultado += (p * Math.Pow(32, n - i));
            i++;
        }
        Console.WriteLine(resultado%101);
    }
}

    class MainClass {
        public static void Main (string[] args) {
        char[] clave = {'A', 'K', 'E', 'Y'};
        FuncionHash tabla = new FuncionHash();
        tabla.MostrarDatos(clave);
        }
    }
}