//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////bubble sort//////////////////////////////////////////////////////////////////////////
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
    public partial class Form12 : Form
    {
        int[] arr;
        int size = -1;
        public Form12()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)//generate the list
        {
            if (int.TryParse(textBox1.Text, out size))
            {
                size = int.Parse(textBox1.Text);
                if (size > 0)
                {
                    arr = new int[size];
                    if (int.TryParse(textBox2.Text, out int seed))
                    {
                        Random random = new Random(seed);
                        if (int.TryParse(textBox4.Text, out int min) && int.TryParse(textBox7.Text, out int max))
                        {
                            for (int i = 0; i < size; i++)
                            {
                                arr[i] = random.Next(min, max);
                            }
                            MessageBox.Show("Generate is complete,click ok to continue");
                        }
                        else
                        {
                            MessageBox.Show("enter a valid numbers for both min and max values");
                        }
                    }
                    else
                    {
                        MessageBox.Show("enter a valid number for the seed");
                    }
                }
                else
                {
                    MessageBox.Show("enter a valid numbers");
                }
            }
            else
            {
                MessageBox.Show("only enter numbers");
            }
        }

        private void button5_Click(object sender, EventArgs e)//show the list
        {
            if (size > 0)
            {
                string result = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    result += arr[i] + " ";
                }
                MessageBox.Show($"the current list is {result}");
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }

        private void button4_Click(object sender, EventArgs e)//running button
        {
            if (size > 0)
            {
                int temp;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = arr.Length; i >= 0; i--)
                {
                    for (int j = 1; j < arr.Length; j++)
                    {
                        if (arr[j - 1] > arr[j])
                        {
                            temp = arr[j - 1];
                            arr[j - 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                stopwatch.Stop();
                string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                textBox6.Text = result;
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }

        private void button2_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show("ALGORITHM BubbleSort (A[0..n])\r\n i, j, temp\r\n for i ← A.size - 1 to 0 do\r\n for j ← 1 to i do\r\n if A[j-1] > A[j] \r\ntemp ← A[j-1]\r\n A[j-1] ← A[j]\r\n A[j] ← temp\r\n i ← i +1\r\n j ← j - 1", "pesudocode");
        }

        private void button3_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox6.Clear();
            arr = new int[0];
            size = -1;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
