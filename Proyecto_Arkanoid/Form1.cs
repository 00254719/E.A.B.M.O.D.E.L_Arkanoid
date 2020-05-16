using System;
using System.Windows.Forms;

namespace Proyecto_Arkanoid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.progressBar1.Increment(1);
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Enabled = false;
                Ventana_Inicio Inicio = new Ventana_Inicio();
                Inicio.Show();
                this.Hide();
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}