//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////jump search///////////////////////////////////////////////////////////////////////////////////
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace main_page
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
            label2.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox2.Visible = false;
            textBox4.Visible = false;
            textBox7.Visible = false;
        }
        int size = -1;
        int[] array;
        private void button1_Click_1(object sender, EventArgs e)//generate the list
        {
            label2.Visible = true;
            label8.Visible = true;
            textBox1.Visible = true;
            button6.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            textBox2.Visible = true;
            textBox4.Visible = true;
            textBox7.Visible = true;
            //
            button1.Visible = false;
            button5.Visible = false;
            label1.Visible = false;
            textBox3.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)//create the array
        {
            if (size> 0)
            {
                string result = "";
                for (int i = 0; i < array.Length; i++)
                {
                    result += array[i] + " ";
                }
                MessageBox.Show($"the current list is {result}");
            }
            else
            {
                MessageBox.Show("first generate a list");
            }

        }

        private void button4_Click(object sender, EventArgs e)//running opearation
        {
            if (int.TryParse(textBox3.Text, out int n))
            {
                n = int.Parse(textBox3.Text);
                if (size > 0)
                {
                    int i, j, temp;
                    for (i = 1; i < array.Length; ++i)
                    {
                        temp = array[i];
                        j = i - 1;
                        while (j >= 0 && array[j] > temp)
                        {
                            array[j + 1] = array[j];
                            j--;
                        }
                        array[j + 1] = temp;
                    }
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    int m = 0, k = Convert.ToInt32(Math.Sqrt(array.Length)), index = -1;
                    bool scan = false;
                    while (m < array.Length && array[m] < n)
                    {
                        i = m;
                        m += k;
                    }
                    if (m < array.Length && array[m] == n)
                    {
                        index = m;
                    }
                    if (m > array.Length - 1)
                    {
                        m=array.Length - 1;
                    }
                    for (j = i; j < m; j++)
                    {
                        if (n == array[j])
                        {
                            scan = true;
                            textBox5.Text = $"found in {j} index";
                            break;
                        }
                        if (scan == false)
                        {
                            textBox5.Text = "not found";
                        }
                        stopwatch.Stop();
                        textBox6.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                        textBox5.ReadOnly = false;
                        textBox6.ReadOnly = false;
                    }
                }
                else
                {
                    MessageBox.Show("enter a valid numbers");
                }
            }
            else
            {
                MessageBox.Show("only enter a valid inputs");
            }
        }

        private void button2_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show("ALGORITHM jump_search (A[0..n], key)\r\n i ← 0 \r\nm ← 0\r\n k ← sqrt(n)\r\n while A[m] < key and m < n\r\n i ← m\r\n m ←m + k\r\n // linear search on the block\r\n if m < n and A[m] = key\r\n return m\r\n if m > n -1\r\n m ← n-1\r\n for j ← i to m \r\nif key = A[j]\r\n return j\r\n j ← j + 1\r\n return  -1", "pesudocode");
        }

        private void button3_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox2.Clear();
            size = -1;
            array = new int[0];
        }
        //forbidden
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button6_Click(object sender, EventArgs e)//to generate the elements for the array
        {
            if (int.TryParse(textBox1.Text, out size))
            {
                size = int.Parse(textBox1.Text);
                if (size > 0)
                {
                    array = new int[size];
                    if (int.TryParse(textBox2.Text, out int seed))
                    {
                        Random random = new Random(seed);
                        if (int.TryParse(textBox4.Text, out int min) && int.TryParse(textBox7.Text, out int max))
                        {
                            for (int i = 0; i < size; i++)
                            {
                                array[i] = random.Next(min, max);
                            }
                            MessageBox.Show("Generate is complete,click ok to continue");
                            label2.Visible = false;
                            label8.Visible = false;
                            textBox1.Visible = false;
                            button6.Visible = false;
                            label9.Visible = false;
                            label10.Visible = false;
                            label11.Visible = false;
                            textBox2.Visible = false;
                            textBox4.Visible = false;
                            textBox7.Visible = false;
                            //
                            button1.Visible = true;
                            button5.Visible = true;
                            label1.Visible = true;
                            textBox3.Visible = true;
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
    }
}
