//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////fibonanci top down way////////////////////////////////////////////////////////////////////////
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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        static int fib_T_D(int x, int[] A)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            if (A[x] != 0) return A[x];
            A[x] = fib_T_D(x - 1, A) + fib_T_D(x - 2, A);
            return A[x];
        }
        private int num;
        private int[] arr1;
        private void button4_Click(object sender, EventArgs e)//running button
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (int.TryParse(textBox1.Text, out num))
                {
                    num = int.Parse(textBox1.Text);
                    if(num > -1)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        int[] arr1 = new int[num + 1];
                        arr1[0] = 0;
                        arr1[1] = 1;
                        int fib = fib_T_D(num, arr1);
                        stopwatch.Stop();
                        string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                        textBox2.Text = fib.ToString();
                        textBox6.Text = result;
                    }
                    else
                    {
                        MessageBox.Show("enter a valid number");
                    }
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
            MessageBox.Show("ALGORITHM FIB_TopDown (n, fib[])\r\n if n = 0\r\n return 0\r\n if  n = 1\r\n return 1\r\n if fib[n] != 0\r\n return fib[n]\r\n fib[n] ← FIB_TopDown(n-1, fib[]) + FIB_TopDown(n-2, fib[])\r\n return fib[n]\r\n", "pesudocode");
        }

        private void button3_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            num = -1;
            arr1 = new int[0];
        }
    }
}
