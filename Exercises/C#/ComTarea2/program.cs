using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImagesInCommonControls
{

    class Formulario : Form
    {
        //Atributos que se ocuparan en las clases y formulario
        Button btn1, btn2;
        PictureBox picture1;
        Graphics graficos;
        Label Label1, Label2;
        RadioButton Rbtn1;
        CheckBox checkBox1;
        public Formulario()
        {
            this.Width = 300; //Ancho del formulario
            this.Height = 260; //Largo del formulario
            this.Text = "Images in Common Controls"; //Titulo
            BackColor = Color.LightSteelBlue; //Color de Fondo

            //Primera etiqueta 
            Label1 = new Label();
            Label1.Location = new Point(20, 20); 
            Label1.Size = new Size(150, 25); 
            Label1.Text = "Label1";
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            Label1.BackColor = Color.LightCoral;
            Label1.ForeColor = Color.DarkRed;
            Label1.Image = new Bitmap(@"smileyicon.png"); //Se agrega el icono
            Label1.ImageAlign = ContentAlignment.MiddleCenter;

            //primer boton
            btn1 = new Button();
            btn1.Location = new Point(20, 55);
            btn1.Size = new Size(150, 30);
            btn1.Text = "Button1";
            btn1.BackColor = Color.Aquamarine;
            btn1.ForeColor = Color.DarkOliveGreen;
            btn1.Image = new Bitmap(@"smileyicon.png"); //se agrega icono
            btn1.ImageAlign = ContentAlignment.MiddleLeft;

            //CheckBox
            checkBox1 = new CheckBox();
            checkBox1.Location = new Point(20, 100);
            checkBox1.Text = "CheckBox1";
            checkBox1.Image = new Bitmap(@"smileyicon.png"); //se agrega icono
            checkBox1.ImageAlign = ContentAlignment.MiddleRight;
            checkBox1.ForeColor = Color.DarkBlue;

            //Boton radial
            Rbtn1 = new RadioButton();
            Rbtn1.Location = new Point(20, 130);
            Rbtn1.Size = new Size(115, 30);
            Rbtn1.Text = "RadioButton1";
            Rbtn1.Image = new Bitmap(@"smileyicon.png"); //se agrega icono
            Rbtn1.ImageAlign = ContentAlignment.MiddleRight;
            Rbtn1.ForeColor = Color.DarkBlue;

            //Cuadro de pintura
            picture1 = new PictureBox();
            picture1.Size = new Size(300, 260);
            picture1.Paint += new PaintEventHandler(Pintar_en_PictureBox); //Funcion para pintar

            //Segunda etiqueta
            Label2 = new Label();
            Label2.Location = new Point(25, 180);
            Label2.Size = new Size(120, 30);
            Label2.Text = "Overwritten imagen:";
            Label2.ForeColor = Color.DarkBlue;

            //Segundo boton
            btn2 = new Button();
            btn2.Location = new Point(150, 180);
            btn2.Text = "Button2";
            btn2.BackColor = Color.Aquamarine;
            btn2.ForeColor = Color.DarkOliveGreen;
            btn2.Image = new Bitmap(@"smileyicon.png"); //Se agrega icono
            btn2.ImageAlign = ContentAlignment.MiddleCenter;
            btn2.Click += new EventHandler(Click_Btn2); //Funcion para salir del formulario
           
            //Agregacion de controles
            Controls.Add(Label1);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(Label2);
            Controls.Add(Rbtn1);
            Controls.Add(checkBox1);
            Controls.Add(picture1);
        }
        private void Pintar_en_PictureBox(Object sender, PaintEventArgs e) //Implememtacion de funcion
        {
            graficos = e.Graphics;
            // Creacion del pincel.
            Pen DrawPen = new Pen(Color.Black, 1);
            // Creacion de puntos para conectar la linea.
            PointF point1 = new PointF(0.0F, 165.0F);
            PointF point2 = new PointF(300.0F, 165.0F);
            //Dibuja la linea en la pantalla.
            graficos.DrawLine(DrawPen, point1, point2);
        }

        private void Click_Btn2(Object sender, EventArgs e) //Implementacion de la funcion
        {
            this.Close(); //Cerrar el programa
        }
    } 
    class MainClass
    {
        static void Main()
        {
            Formulario ImagesControls = new Formulario(); //Creacion de formulario
            Application.Run(ImagesControls);
        }
    }
}
