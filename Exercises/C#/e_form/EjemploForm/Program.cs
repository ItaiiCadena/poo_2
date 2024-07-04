using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.Pkcs;

public class MainForm : Form
{
    private System.Windows.Forms.TextBox txtUserName;
    private Button btnSalir;
    private Label Etiqueta;
    int a;
    public MainForm()
    {
        txtUserName = new System.Windows.Forms.TextBox();
        txtUserName.Name = "Formulario Windows Forms";
        txtUserName.Location = new System.Drawing.Point(64, 88);
        txtUserName.Size = new System.Drawing.Size(200, 20);
        txtUserName.TabIndex = 0;
        txtUserName.Text = "Enter text here!";

        btnSalir = new Button();
        btnSalir.Name = "Salir";
        btnSalir.Location = new Point(200, 200);
        btnSalir.TabIndex = 1;
        btnSalir.Text = "&Salir";
        btnSalir.Click += new EventHandler(ClickSalir);

        Etiqueta = new Label();
        Etiqueta.Location = new Point(200, 150);
        Etiqueta.Text = "Resultado";


        this.Controls.Add(Etiqueta);
        this.Controls.Add(btnSalir);
        this.Controls.Add(txtUserName);
    }

    void ClickSalir(Object sender, EventArgs e)
    {
        //this.Close();
        a = 5 + Convert.ToByte(txtUserName.Text);
        Etiqueta.Text = Convert.ToString(a);
    }

    public static void Main(String[] args)
    {
        MainForm frmCostumForm = new MainForm();
        //frmCostumForm.Show();
        //frmCostumForm.txtUserName.Text = "Hola";
        Application.Run(frmCostumForm);
    }
}
