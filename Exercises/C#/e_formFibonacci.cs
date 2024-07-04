    class Formulario : Form
    {
        Button btnCalcular;
        Button btnSalir;
        ListBox lstBox;
        public Formulario()
        {
            this.Text = "Fibonacci";
            this.Width = 400;
            this.Height = 300;

            btnCalcular = new Button();
            btnCalcular.Location = new Point(200, 250);
            btnSalir = new Button();
            btnSalir.Location = new Point(300, 250);
            lstBox = new ListBox();
            lstBox.Location = new Point(50, 50);
            lstBox.Size = new Size(200, 100);

            Controls.Add(btnCalcular);
            Constrols.Add(btnSalir);
            Controls.Add(lstBox);
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

        public void Calcular()
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
            }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Fibo calculo = new Fibo();
            calculo.Datos(0, 1);
            calculo.Calcular();

            Formulario ventana = new Formulario();
            Application.Run(ventana);
        }
    }