//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////fibonanci normal way//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main_page
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        int num = -1;
        static int normalFIB(int x)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            return normalFIB(x - 1) + normalFIB(x - 2);
        }
        private void button4_Click(object sender, EventArgs e)//running button
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (int.TryParse(textBox1.Text, out num))
                {
                    num = int.Parse(textBox1.Text);
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    int fib = normalFIB(num);
                    stopwatch.Stop();
                    string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                    textBox2.Text = fib.ToString();
                    textBox6.Text = result;
                }
                else
                {
                    MessageBox.Show("enter only numbers");
                }
            }
            else
            {
                MessageBox.Show("no inputs are taken");
            }
        }
        private void button2_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show(" ALGORITHM FIB_Recursion (x)\r\n if x = 0\r\n return 0\r\n if x = 1\r\n return 1\r\nf ← FIB_Recursion(x-1) + FIB_Recursion(x-2) \r\nreturn f\r\n", "pesudocode");
        }
        private void button3_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            num = -1;
        }
    }
}
