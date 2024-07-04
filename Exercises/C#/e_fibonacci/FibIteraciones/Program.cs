using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FibIteraciones
{
    class Formulario : Form
    {
        Button btnCalcular;
        Button btnSalir;
        ListBox lstBox;
        Fibo calculo = new Fibo();
        public Formulario()
        {
            this.Text = "Fibonacci";
            this.Width = 400;
            this.Height = 300;

            btnCalcular = new Button();
            btnCalcular.Location = new Point(200, 250);
            btnCalcular.Text = "Calcular";
            btnCalcular.Click += clickCalcular;

            btnSalir = new Button();
            btnSalir.Location = new Point(300, 250);
            btnSalir.Text = "Salir";
            btnSalir.Click += clickSalir;

            lstBox = new ListBox();
            lstBox.Location = new Point(50, 50);
            lstBox.Size = new Size(200, 100);


            Controls.Add(btnCalcular);
            Controls.Add(btnSalir);
            Controls.Add(lstBox);
        }

        void clickSalir(object Sender, EventArgs e)
        {
            this.Close();
        }
        void clickCalcular(Object Sender, EventArgs a)
        {
            lstBox.Items.Add("Calculando en consola");
            calculo.Calcular(lstBox);
        }

    }
    class Fibo
    {
        private int a, b;

        public void Datos(int inicio, int final)
        {
            a = inicio;
            b = final;

        }

        public void Calcular(ListBox Lista)
        {
            ///Console.WriteLine("Datos {0} {1}", a, b);
            a = 0;
            b = 1;
            int c;
            for (int i = 0; i < 6; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.WriteLine(c);
                Lista.Items.Add(c);
            }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Formulario ventana = new Formulario();
            Application.Run(ventana);
        }
    }
}
