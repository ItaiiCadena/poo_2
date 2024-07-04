using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HolaMundo
{
    public class HolaMundo : Form
        {
        private TextBox CajaTexto =new TextBox();
        private Label etiqueta = new Label();
        private Label etiqueta1 = new Label();
        private Button btnSaludo = new Button();
        public HolaMundo()
            {
             //this. parametros que tiene form 
            Text = "Hola mundo";
            Width = 490;
            CajaTexto = new TextBox();
            CajaTexto.Location = new System.Drawing.Point(100, 10);
            CajaTexto.Text = "Pablo Morales";

            CajaTexto.Size = new System.Drawing.Size(250, 30);
            etiqueta.Location = new System.Drawing.Point(0, 10);
            etiqueta.Text = "Nombre: ";

            etiqueta1.Location = new System.Drawing.Point(50, 100);
            btnSaludo.Location = new System.Drawing.Point(100, 200);
            btnSaludo.Text = "&Saludo";
            btnSaludo.Click += new EventHandler(this.procesarSaludo);


            Controls.Add(etiqueta);
            Controls.Add(etiqueta1);
            Controls.Add(CajaTexto);
            Controls.Add(btnSaludo);
        }


        private void procesarSaludo(Object sender, EventArgs e)
        {
            string nombre;
            nombre = CajaTexto.Text;

            etiqueta1.Text = "Hola" + nombre;
            etiqueta.Text = "Hola";
            CajaTexto.Text = " ";
        }


        public static void Main()
        {
            Application.Run(new HolaMundo());
        }


    }

}