using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace Pintura
{
    class Pintura : Form
    {
       PictureBox picture1 = new PictureBox();
       Graphics graficos;
       String fuente = "Arial";
       int TamanioFuente = 24;

       public Pintura()
       {
           this.Width = 800;
           this.Height = 600;

            picture1 = new PictureBox();
            picture1.BackgroundImage = Image.FromFile("fondo.jpg");
            //picture1.BackColor = ConsoleColor.DarkRed;
            picture1.Size = new Size(800, 600);
            picture1.Paint += new PaintEventHandler(Pintar_en_PictureBox);
           Controls.Add(picture1);
       }

        public void Pintar_en_PictureBox(Object sender, PaintEventArgs e)
        {
            graficos = e.Graphics;
            graficos.DrawString("Facultad de Computacion", new Font(fuente, TamanioFuente), Brushes.DarkGreen, new Point(100, 150));
            graficos.DrawArc(Pens.White, new Rectangle(new Point(0, 0), new Size(50,50)), 0, 360);
        }
    }

       

    class MainClass
    {
        public static void Main()
        {
            Pintura ventana = new Pintura();
            Application.Run(ventana);
        }
    }
}
