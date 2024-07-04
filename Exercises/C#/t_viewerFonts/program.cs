using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChooseFonts
{
    public class Formulario : Form
    {
        private Label Label1, Label2;
        private ComboBox ComboBox1, ComboBox2;
        private PictureBox picture1;
        private Graphics graficos;
        private Button btnSalir, btnColor;
        private ColorDialog NewColor = new ColorDialog();
        private RadioButton Rbtn1, Rbtn2, Rbtn3, Rbtn4;
        public Formulario()
        {
            this.Width = 550; //Ancho del formulario
            this.Height = 180; //Largo del formulario
            this.Text = "Font viewer"; //Nombre
            this.BackColor = System.Drawing.Color.LavenderBlush; //Color de fondo

            Label1 = new Label();
            Label1.Location = new Point(15, 17);
            Label1.Size = new Size(80, 20);
            Label1.Text = "Choose Font: ";
            Label1.ForeColor = Color.MediumVioletRed;

            ComboBox1 = new ComboBox();
            ComboBox1.Location = new Point(100, 14);
            ComboBox1.Size = new Size(300, 60);
            ComboBox1.DropDownHeight = 90;
            ComboBox1.DropDownWidth = 90;
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox1.DrawItem += ComboBox1_DrawItem;
            ComboBox1.Click += new EventHandler(ComboBox1_Click);

            ComboBox2 = new ComboBox();
            ComboBox2.Location = new Point(410, 14);
            ComboBox2.Size = new Size(90, 70);
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            ComboBox2.Items.Add("10");
            ComboBox2.Items.Add("12");
            ComboBox2.Items.Add("14");
            ComboBox2.Items.Add("16");
            ComboBox2.Items.Add("20");
            ComboBox2.Items.Add("24");
            ComboBox2.Items.Add("28");
            ComboBox2.Items.Add("30");
            ComboBox2.Items.Add("32");
            ComboBox2.Items.Add("34");
            ComboBox2.Items.Add("36");
            ComboBox2.Items.Add("40");
            ComboBox2.Items.Add("42");
            ComboBox2.Items.Add("46");
            ComboBox2.Items.Add("50");

            btnColor = new Button();
            btnColor.Location = new Point(10, 115);
            btnColor.Text = "Color";
            btnColor.ForeColor = Color.MediumVioletRed;
            btnColor.Click += new EventHandler(Choose_Color);

            btnSalir = new Button(); 
            btnSalir.Location = new Point(450, 115);
            btnSalir.Text = "Close";
            btnSalir.ForeColor = Color.MediumVioletRed;
            btnSalir.Click += new EventHandler(clickSalir);

            picture1 = new PictureBox();
            picture1.Size = new Size(550, 180);
            picture1.Paint += new PaintEventHandler(Pintar_en_PictureBox);

            Label2 = new Label(); 
            Label2.Font = new Font("Comic Sans MS", 30);
            Label2.ForeColor = Color.MediumVioletRed;
            Label2.TextAlign = ContentAlignment.MiddleCenter;
            Label2.Location = new Point(10, 50);
            Label2.Size = new Size(500, 55);

            Rbtn1 = new RadioButton();
            Rbtn1.Location = new Point(125, 115);
            Rbtn1.AutoSize = true;
            Rbtn1.Text = "Regular";
            Rbtn1.ForeColor = Color.MediumVioletRed;
            Rbtn1.Checked = true;
            Rbtn1.CheckedChanged +=  new EventHandler(Switch_to_regular);

            Rbtn2 = new RadioButton();
            Rbtn2.Location = new Point(205, 115);
            Rbtn2.AutoSize = true;
            Rbtn2.Text = "Underline";
            Rbtn2.ForeColor = Color.MediumVioletRed;
            Rbtn2.Checked = false;
            Rbtn2.CheckedChanged += new EventHandler(Switch_to_underline);

            Rbtn3 = new RadioButton();
            Rbtn3.Location = new Point(295, 115);
            Rbtn3.AutoSize = true;
            Rbtn3.Text = "Strikeout";
            Rbtn3.ForeColor = Color.MediumVioletRed;
            Rbtn3.Checked = false;
            Rbtn3.CheckedChanged += new EventHandler(Switch_to_strikeout);

            Rbtn4 = new RadioButton();
            Rbtn4.Location = new Point(375, 115);
            Rbtn4.AutoSize = true;
            Rbtn4.Text = "Bold";
            Rbtn4.ForeColor = Color.MediumVioletRed;
            Rbtn4.Checked = false;
            Rbtn4.CheckedChanged += new EventHandler(Switch_to_bold);
           
            Controls.Add(Label1);
            Controls.Add(Label2);
            Controls.Add(ComboBox1);
            Controls.Add(ComboBox2);
            this.Controls.Add(Rbtn1);
            this.Controls.Add(Rbtn2);
            this.Controls.Add(Rbtn3);
            this.Controls.Add(Rbtn4);
            Controls.Add(btnColor);
            Controls.Add(btnSalir);
            Controls.Add(picture1);
        }

        private void ComboBox1_Click(Object sender, EventArgs e) //Funcion para cargar las fuentes
        {
            ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBox1.ItemHeight = 20;
            ComboBox1.MaxDropDownItems = 20;
            ComboBox1.IntegralHeight = false;

            foreach (FontFamily item in FontFamily.Families)
            {
                if (item.IsStyleAvailable(FontStyle.Regular))
                {
                    ComboBox1.Items.Add(item.Name.ToString());   

                }
            } 
        }

        private void ComboBox1_DrawItem(Object sender, DrawItemEventArgs e) //Funcion que dibuja las fuentes en su tipo
        {
            if (e.Index == -1) return;

            e.Graphics.DrawString(ComboBox1.Items[e.Index].ToString(), new Font(ComboBox1.Items[e.Index].ToString(), 12), Brushes.MediumVioletRed, e.Bounds.X,e.Bounds.Y);
            
            try 
            {
                Label2.Font = new Font(ComboBox1.Text, Label2.Font.Size);
                Label2.Text = ComboBox1.Text;
            }
            catch { } 
        }

        private void ComboBox2_SelectedIndexChanged(Object sender, EventArgs e) //Funcion para seleccionar el tamanio de la fuente
        {
            try
            {
               Label2.Font = new Font( Label2.Font.FontFamily,float.Parse(ComboBox2.SelectedItem.ToString()));
            }
            catch { }
        }

        private void Pintar_en_PictureBox(Object sender, PaintEventArgs e) //Funcion para pintar en la caja de pintura
        {
            graficos = e.Graphics;

            // Create pen.
            Pen DarkMagentaPen = new Pen(Color.MediumVioletRed, 1);
            // Create rectangle.
            Rectangle rect = new Rectangle(5, 5, 521, 40);
            // Draw rectangle to screen.
            graficos.DrawRectangle(DarkMagentaPen, rect);

            // Create points that define line.
            PointF point1 = new PointF(0.0F, 110.0F);
            PointF point2 = new PointF(550.0F, 110.0F);
            //Draw line to screen.
            graficos.DrawLine(DarkMagentaPen, point1, point2);

        }

        private void Choose_Color(object sender, EventArgs e) //Funcion que muestra una tabla de colores para elegir
        { 
            DialogResult ChooseColor = NewColor.ShowDialog();
            if (ChooseColor == DialogResult.OK)
            {
                Label2.ForeColor = NewColor.Color;
            } 
        }

        //Funciones para distintos estilos de la letra (Normal, Negrita, Subrayada, Tachada)
        private void Switch_to_regular(Object sender, EventArgs e)
        {
            Label2.Font = new Font(Label2.Font.FontFamily,Label2.Font.Size, FontStyle.Regular);
        }
         private void Switch_to_underline(Object sender, EventArgs e)
        {
            Label2.Font = new Font(Label2.Font.FontFamily, Label2.Font.Size, FontStyle.Underline);
        }
         private void Switch_to_strikeout(Object sender, EventArgs e)
        {
            Label2.Font = new Font(Label2.Font.FontFamily, Label2.Font.Size, FontStyle.Strikeout);
        }
         private void Switch_to_bold(Object sender, EventArgs e)
        {
            Label2.Font = new Font(Label2.Font.FontFamily, Label2.Font.Size, FontStyle.Bold);
        }
        //Funcion para cerrar el programa
        private void clickSalir(Object Sender, EventArgs e)
        {
            this.Close();
        }
    }
    static class MainClass
    {
        static void Main()
        {
            Formulario ViewerFonts = new Formulario(); //Creacion del formulario
            Application.Run(ViewerFonts);
        }
    }
}
