//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////quick sort////////////////////////////////////////////////////////////////////////////
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
    public partial class Form9 : Form
    {
        int[] arr;
        int size = -1;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)//generate
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
        /////////////////////////////////////////////////////////quick sort operation
        private void quicksort(int le, int ri, int[] ar)
        {
            int i = le, j = ri, temp;
            int pivot = arr[ri];
            while (i < j)
            {
                while (arr[i] < pivot)
                    i++;
                while (arr[j] > pivot)
                    j--;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            if (le < j)
            {
                quicksort(le, j, arr);
            }
            if (i < ri)
            {
                quicksort(i, ri, arr);
            }
        }
        /////////////////////////////////////////////////////////quick sort operation
        private void button4_Click(object sender, EventArgs e)//run button
        {
            if (size > 0)
            {
                int left = 0, right = arr.Length - 1;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                quicksort(left, right, arr);
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
            MessageBox.Show("ALGORITHM QuickSort (A[0..n], left, right)\r\ni ← left\r\nj ← right\r\npivot ← A[left]\r\nwhile i < j\r\nwhile A[i] < pivot\r\ni ← i + 1\r\nwhile A[j] > pivot\r\nj ← j -1\r\nif i <= j\r\nswap(A[i], A[j]\r\ni ← i + 1\r\nj ← j -1\r\nif left < j\r\nQuickSort(A, left, j)\r\nif right > i\r\nQuickSort(A, i, right)", "pesudocode");
        }

        private void button3_Click(object sender, EventArgs e)//clear
        {
            arr = new int[0];
            size = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox6.Clear();
        }
    }
}
