//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////interpolation way/////////////////////////////////////////////////////////////////////////////
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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }
        int size = -1;
        int[] array;
        private void button6_Click(object sender, EventArgs e)//create an array
        {
                if (int.TryParse(textBox1.Text, out size))
                {
                    size = int.Parse(textBox1.Text);
                    if (size > 0)
                    {
                        array = new int[size];
                        if (int.TryParse(textBox8.Text, out int seed))
                        {
                            Random random = new Random(seed);
                            if (int.TryParse(textBox5.Text, out int min) && int.TryParse(textBox7.Text, out int max))
                            {
                                for (int i = 0; i < size; i++)
                                {
                                    array[i] = random.Next(min, max);
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
        /////////////////////////////////////////////////////////merge sort operation
        static void MERGE(int l, int r, int[] a, int m)
        {
            int size1 = m - l + 1;
            int size2 = r - m;
            int[] temp1 = new int[size1];
            int[] temp2 = new int[size2];
            int i, j;
            for (i = 0; i < size1; i++)
            {
                temp1[i] = a[i + l];
            }
            for (i = 0; i < size2; i++)
            {
                temp2[i] = a[i + m + 1];
            }
            i = 0;
            j = 0;
            int k = l;
            while (i < size1 && j < size2)
            {
                if (temp1[i] < temp2[j])
                {
                    a[k] = temp1[i];
                    i++;
                    k++;
                }
                else
                {
                    a[k] = temp2[j];
                    j++;
                    k++;
                }
            }
            while (i < size1)
            {
                a[k] = temp1[i];
                i++;
                k++;
            }
            while (j < size2)
            {
                a[k] = temp2[j];
                j++;
                k++;
            }
        }
        static void merge(int left, int right, int[] arr)
        {
            if (left == right) return;
            int mid = (left + right) / 2;
            merge(left, mid, arr);
            merge(mid + 1, right, arr);
            MERGE(left, right, arr, mid);
        }
        /////////////////////////////////////////////////////////merge sort operation
        private void button4_Click(object sender, EventArgs e)//running button
        {
            if (size > 0)
            {
                if (int.TryParse(textBox2.Text, out int key))
                {
                    key = int.Parse(textBox2.Text);
                    int l = 0, h = array.Length - 1, mid;
                    int index = -1;
                    merge(l, h, array);
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (l <= h)
                    {
                        if (array[h] == array[l])
                        {
                            if (array[l] == key)
                            {
                                index = l;
                            }
                            break;
                        }
                        mid = l + (((h - l) * (key - array[l])) / (array[h] - array[l]));//interpolation equation
                        if (mid < l || mid > h) break;
                        if (array[mid] == key)
                        {
                            index = mid;
                            break;
                        }
                        else if (array[mid] < key)
                        {
                            l = mid + 1;
                        }
                        else
                        {
                            h = mid - 1;
                        }
                    }
                    stopwatch.Stop();
                    string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                    textBox6.Text = result;
                    if (index != -1)
                    {
                        textBox4.Text = $"Key found at index {index}";
                    }
                    else
                    {
                        textBox4.Text = "Key not found";
                    }
                }
                else
                {
                    MessageBox.Show("enter an valid input");
                }
            }
            else
            {
                MessageBox.Show("you dont have any data");
            }
        }
        private void button5_Click(object sender, EventArgs e)//show the series
        {
            if (size > 0)
            {
                string series = "";
                for(int i = 0; i < size; i++)
                {
                    series += array[i] + " ";
                }
                MessageBox.Show(series);
            }
            else
            {
                MessageBox.Show("you dont have any data");
            }
        }

        private void button2_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show("ALGORITHM Interpolation_Search (A[0..n], key)\r\n L ← 0 \r\nH ← n-1\r\n while L <= H do\r\n mid ← L + (((H - L) * (key - A[L])) // (A[H] - A[L]))\r\n if key = A[mid]\r\n return mid\r\n if key < A[mid]\r\n H← mid - 1\r\n else \r\nL ← mid + 1\r\n return  -1\r\n", "pesudocode");
        }

        private void button1_Click(object sender, EventArgs e)//hint the user
        {
            MessageBox.Show("hint:this type of search methods could be useful if you have an sorted data and equally distributed\n(in other words data with a specific relationship)");
        }

        private void button3_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox8.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox5.Clear();
            size = -1;
            array= new int[0];
        }
    }
}
