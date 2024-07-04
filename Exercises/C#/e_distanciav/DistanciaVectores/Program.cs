using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistanciaVectores //ESpacio de trabajo
{
    public class Formulario : Form //Creacion del formulario
    {
        private Label txt1, txt2, txt3, a, b, _a, _b, resultado; //Etiquetas
        private Button btnSalir, btnCalcular, btnReiniciar; //Botones
        private TextBox x1, x2, y1, y2, _resultado; //Cajas de texto
        public Formulario()
        {
            this.Text = "Distancia entre vectores"; //Nombre del formulario
            
            txt1 = new Label(); //Etiqueta 1 para informar lo que hace el programa
            txt1.Location = new Point(120, 10); //Localizacion
            txt1.Size = new Size(300, 20); //Tamaño
            txt1.Text = "--Calculo de distancia entre dos puntos--"; //Lo que contiene la etiqueta

            txt2 = new Label(); //Etiqueta para pedir los datos del punto A al usuario 
            txt2.Location = new Point(50, 50);
            txt2.Size = new Size(200, 20);
            txt2.Text = "Ingrese coordenadas para A";

            a = new Label(); //Etiqueta con el nombre de la primera caja de texto
            a.Location = new Point(80, 80);
            a.Size = new Size(10, 20);
            a.Text = "X";
            x1 = new TextBox(); //Primera caja de texto, contendra coordenada "x" del punto A
            x1.Location = new Point(90, 80);

            b = new Label(); //Etiqueta con el nombre de la segunda caja de texto
            b.Location = new Point(210, 80);
            b.Size = new Size(10, 20);
            b.Text = "Y";
            y1 = new TextBox(); //Segunda caja de texto, contendra coordenada "y" del punto A
            y1.Location = new Point(220, 80);

            txt3 = new Label(); //Etiqueta para pedir los datos del punto B al usuario
            txt3.Location = new Point(50, 120);
            txt3.Size = new Size(200, 20);
            txt3.Text = "Ingrese coordenadas para B";

            _a = new Label(); //Etiqueta con el nombre de la tercera caja de texto
            _a.Location = new Point(80, 150);
            _a.Size = new Size(10, 20);
            _a.Text = "X";
            x2 = new TextBox(); //Tercera caja de texto, contendra la coordenada "x" del punto B
            x2.Location = new Point(90, 150);

            _b = new Label(); //Etiqueta con el nombre de la cuarta caja de texto
            _b.Location = new Point(210, 150);
            _b.Size = new Size(10, 20);
            _b.Text = "Y";
            y2 = new TextBox(); //Cuarta caja de texto, contendra la coordenada "y" del punto B
            y2.Location = new Point(220, 150);

            resultado = new Label(); //Etiqueta resultado, para el nombre de la quinta caja de texto
            resultado.Location = new Point(230, 200);
            resultado.Size = new Size(65, 20);
            resultado.Text = "Resultado:"; 
            _resultado = new TextBox(); //Quinta caja de texto, contendra el valor de la operacion que se ejecuta en el programa
            _resultado.Location = new Point(295, 200);

            btnSalir = new Button(); //Boton para salir del programa
            btnSalir.Location = new Point(350, 250);
            btnSalir.Text = "Salir";
            btnSalir.Click += clickSalir;

            btnCalcular = new Button(); //Boton para calcular la distancia entre los punto
            btnCalcular.Location = new Point(250, 250);
            btnCalcular.Text = "Calcular";
            btnCalcular.Click += clickCalcular;

            btnReiniciar = new Button();
            btnReiniciar.Location = new Point(50, 250);
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.Click += clickReiniciar;

            ///Se agregan al formulario las etiquetas, botones y cajas que texto para que puedan visualizarse en pantalla
            Controls.Add(txt1);
            Controls.Add(txt2);
            Controls.Add(txt3);
            Controls.Add(a);
            Controls.Add(x1);
            Controls.Add(b);
            Controls.Add(y1);
            Controls.Add(_a);
            Controls.Add(x2);
            Controls.Add(_b);
            Controls.Add(y2);
            Controls.Add(btnSalir);
            Controls.Add(btnCalcular);
            Controls.Add(resultado);
            Controls.Add(_resultado);
            Controls.Add(btnReiniciar);
        } //Fin del formulario

        void clickSalir(Object Sender, EventArgs e)
        {
            this.Close();
        }

        void clickCalcular(Object Sender, EventArgs a)
        {
            CalcularDistancia Distan = new CalcularDistancia();
            Punto A = new Punto(Convert.ToDouble(x1.Text), Convert.ToDouble(y1.Text));
            Punto B = new Punto(Convert.ToDouble(x2.Text), Convert.ToDouble(y2.Text));
            double C =  Distan.calculaDistancia(A, B);
            _resultado.Text = Convert.ToString(C);
        }
        void clickReiniciar(Object Sender, EventArgs a)
        {
            x1.Text = "";
            x2.Text = "";
            y1.Text = "";
            y2.Text = "";
            _resultado.Text = "";
        }
    }

    class Punto //Clase punto
    {

        double x, y; //Atributos
        public Punto(double x1, double y1) //Constructor
        {
            //Inicializacion
            x = x1;
            y = y1;
        }

        public double getX() //Obtener valor o atributo X
        {
            return x;
        }
        public double getY() //Obtener valor o atributo Y
        {
            return y;
        }
    } //Fin clase punto

    class CalcularDistancia //Clase distancia, para calcular distancia entre puntos
    {
        public double calculaDistancia(Punto A, Punto B) //Funcion para  calcular la distancia entre los puntos
        {
            double resul = Math.Sqrt(Math.Pow(B.getX() - A.getX(), 2) + Math.Pow(B.getY() - A.getY(), 2));
            return resul;
        }
    }//Fin clase

    class MainClass
    {
         public static void Main(String[] args)
         {
              Formulario Distancia = new Formulario();
              Application.Run(Distancia);
         }
    }

}
