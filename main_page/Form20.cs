//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////exponential search////////////////////////////////////////////////////////////////////////////
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace main_page
{
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }
        int[] arr;
        int size = -1;
        private void button1_Click(object sender, EventArgs e)//generate the list
        {
            if (int.TryParse(textBox1.Text, out size))
            {
                size = int.Parse(textBox1.Text);
                if (size > 0)
                {
                    arr = new int[size];
                    if (int.TryParse(textBox3.Text, out int seed))
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

        private void button5_Click(object sender, EventArgs e)//show the lesta
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
            if (int.TryParse(textBox2.Text, out int key))
            {
                if (size > 0)
                {
                    key = int.Parse(textBox2.Text);
                    //sorting
                    int i = 0;
                    int j, temp;
                    for (i = 1; i < size; ++i)
                    {
                        temp = arr[i];
                        j = i - 1;
                        while (j >= 0 && arr[j] > temp)
                        {
                            arr[j + 1] = arr[j];
                            j--;
                        }
                        arr[j + 1] = temp;
                    }
                    //search
                    i = 0;
                    int m = 0,k = 0;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (m < key && arr[m] < key)
                    {
                        i = m;
                        k++;
                        m = (int)Math.Pow(2, k);
                        if (m >= size)
                        {
                            m = size - 1;
                            break;
                        }
                    }
                    int l = 0, h = arr.Length - 1, mid, index = -1;
                    while (l <= h)
                    {
                        mid = (l + h) / 2;
                        if (arr[mid] == key)
                        {
                            index = mid;
                            break;
                        }
                        else if (arr[mid] < key)
                        {
                            l = mid + 1;
                        }
                        else
                        {
                            h = mid - 1;
                        }
                    }
                    if (index == -1)
                    {
                        textBox5.Text = "Not found";
                    }
                    else
                    {
                        textBox5.Text = $"found in index {index}";
                    }
                    stopwatch.Stop();
                    textBox6.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                }
                else
                {
                    MessageBox.Show("no list are found");
                }
            }
            else
            {
                MessageBox.Show("only enter a valid inputs");
            }
        }
        private void button2_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show("ALGORITHM exponential_search(A[0-n], key)\r\n i ← 0 \r\nm ← 0\r\n k ← 0\r\n while A[m] < key and m < n\r\n i ← m\r\n k ← k + 1\r\n m ←pow(2, k)\r\n // linear search on the block\r\n if m < n and A[m] = key\r\n return m\r\n if m > n -1\r\n m ← n-1\r\n for j ← i to m \r\nif key = A[j]\r\n return j\r\n j ← j + 1\r\n return  -1\r\n", "pesudocode");
        }
        private void button3_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            size = -1;
            arr = new int[0];
        }
    }
}
