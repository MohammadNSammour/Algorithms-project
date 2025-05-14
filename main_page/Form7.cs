//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////insertion sort////////////////////////////////////////////////////////////////////////
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
    public partial class Form7 : Form
    {
        int[] arr;
        int size = -1;
        public Form7()
        {
            InitializeComponent();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
        }
        private void button6_Click(object sender, EventArgs e)//generate
        {
            if (int.TryParse(textBox1.Text, out size))
            {
                size = int.Parse(textBox1.Text);
                if (size> 0)
                {
                    arr = new int[size];
                    if (int.TryParse(textBox2.Text, out int seed))
                    {
                        Random random = new Random(seed);
                        if(int.TryParse(textBox4.Text,out int min)&&int.TryParse(textBox7.Text,out int max))
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
        private void button5_Click(object sender, EventArgs e)//show the current list
        {
            if (size> 0)
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
        private void button4_Click(object sender, EventArgs e)//run
        {
            if (size> 0)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int i, j, temp;
                for (i = 1; i < arr.Length; i++)
                {
                    j = i - 1;
                    temp = arr[i];
                    while (j >= 0 && arr[j] > temp)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = temp;
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
            MessageBox.Show("ALGORITHM InsertionSearch (A[0..n])\r\nfor j ← 1 to A.size do\r\nmin ← A[j]\r\ni ← j - 1\r\nwhile i >= 0 and A[i] > min do\r\nA[i + 1] ← A[i]\r\ni = i – 1\r\nA[i + 1] = min", "pesudocode");
        }
        private void button3_Click(object sender, EventArgs e)//clear
        {
            arr = new int[0];
            size = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
