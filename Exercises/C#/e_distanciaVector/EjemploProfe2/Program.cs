using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EjemploProfe2
{
    class Punto
    {
        private double x, y;
        public Punto()
        {
            x = 0;
            y = 0;
        }

        public double X
        {
            set { x = value; }
            get { return x; }
        }

        public double Y
        {
            set { y = value; }
            get { return y; }
        }

        public void Coordenada(double X, double Y)
        {
            x = X;
            y = Y;
        }
    }

    //--------------------------------------------------------------------------
    class Vector
    {
        Punto Resultado;

        public Vector()
        { }
        public double CalcularDistancia(Punto A, Punto B)
        {
            Resultado = new Punto();
            Resultado.X = B.X - A.X;
            Resultado.Y = B.Y - A.Y;

            return Math.Sqrt(Resultado.X * Resultado.X + Resultado.Y * Resultado.Y);
        }
    }

    /// -------------------------------------------------------------------------------
   
    class Interface : Form
    {
        Button btnCalcular;
        Label Etiqueta1, Etiqueta2;
        TextBox EntradaAx, EntradaAy;
        public Interface()
        {
            this.Text = "Calculadora de vectores";
            this.Width = 600;
            this.Height = 400;
            this.BackColor = Color.FromArgb(200, 200, 250);

            btnCalcular = new Button();
            btnCalcular.Text = "Calcular";
            btnCalcular.Location = new Point(500, 350);
            btnCalcular.Click += CalcularVector;

            Etiqueta1 = new Label();
            Etiqueta1.Location = new Point(50, 50);
            Etiqueta1.Text = "Vector A: ";

            Etiqueta2 = new Label();
            Etiqueta2.Location = new Point(50, 250);
            Etiqueta2.Text = "Vector B: ";

            EntradaAy = new TextBox();
            EntradaAy.Location = new Point(200, 50);
            EntradaAy.TabIndex = 2;
            EntradaAy.Size = new Size(50, 100);

            EntradaAx = new TextBox();
            EntradaAx.Location = new Point(100, 50);
            EntradaAx.TabIndex = 1;
            EntradaAx.Size = new Size(100, 100);

            Controls.Add(btnCalcular);
            Controls.Add(Etiqueta1);
            Controls.Add(EntradaAx);
            Controls.Add(EntradaAy);
        }

        void CalcularVector(object Sender, EventArgs e)
        {

        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Interface Formulario = new Interface();
            Application.Run(Formulario);
        }
    }
}
