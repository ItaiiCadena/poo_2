using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuentesForm
{
    class Interface : Form
    {
        ListBox lista;
        Button boton;
        Label etiqueta;

        public Interface()
        {
            lista = new ListBox();
            lista.Location = new System.Drawing.Point(5,5);
            lista.Size = new System.Drawing.Size(150,300);
            boton = new Button();

            etiqueta = new Label();

            Controls.Add(lista);
            Controls.Add(boton);
            Controls.Add(etiqueta);
        }
    }

    class Program
    {
        public static void Main()
        {
            Application.Run();
        }
    }
}
