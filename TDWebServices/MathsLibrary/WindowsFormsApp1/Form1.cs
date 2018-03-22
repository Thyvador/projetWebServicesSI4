using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ServiceReference1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MathOperationsClient serviceReference1;
        MathOperationsClient serviceReference2;
        public Form1()
        {
            serviceReference1 = new MathOperationsClient("math1");
            serviceReference2 = new MathOperationsClient("math2");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "" + serviceReference1.Add(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "" + serviceReference2.Multiply(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text));
        }
    }
}
