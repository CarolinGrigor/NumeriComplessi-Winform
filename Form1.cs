using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumeriComplessi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Complex.TryParse(textBox1.Text, textBox2.Text, out Complex nC))
            {
                label3.Text = $"z = {nC}";
                label4.Text = $"m = {nC.Modulo()}";
                label5.Text = $"a = {nC.Angolo()}";
            } else
            {
                MessageBox.Show("Formato invalido");
            }
        }
    }
}
