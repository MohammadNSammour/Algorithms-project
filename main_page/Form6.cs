//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////binary search/////////////////////////////////////////////////////////////////////////
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
namespace main_page
{
    public partial class Form6 : Form
    {
        int[] arr;
        int size = -1;
        bool is_sorted = false;
        public Form6()
        {
            InitializeComponent();
            label9.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            label2.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            textBox4.Visible = false;
            textBox7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)//button1...generate a list(for hide elements to let the user enter the size)
        {
            button1.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            label1.Visible = false;
            textBox3.Visible = false;
            //
            textBox2.Visible = true;
            textBox4.Visible = true;
            textBox7.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            //
            label2.Visible = true;
            label8.Visible = true;
            textBox1.Visible = true;
            button6.Visible = true;

        }
        private void button6_Click(object sender, EventArgs e)//button6...generate(to take and handle the size) 
        {
            if (int.TryParse(textBox1.Text, out size))
            {

                size = int.Parse(textBox1.Text);
                if (size>0)
                {
                    arr = new int[size];
                    if (int.TryParse(textBox2.Text, out int seed))
                    {
                        if (int.TryParse(textBox4.Text, out int min) && int.TryParse(textBox7.Text, out int max))
                        {
                            Random random = new Random(seed);
                            for (int i = 0; i < size; i++)
                            {
                                arr[i] = random.Next(min, max);
                            }
                            MessageBox.Show("Generate is complete,click ok to continue");
                            textBox2.Visible = false;
                            textBox4.Visible = false;
                            textBox7.Visible = false;
                            label10.Visible = false;
                            label11.Visible = false;
                            label12.Visible = false;
                            //
                            label10.Visible = false;
                            label11.Visible = false;
                            textBox4.Visible = false;
                            textBox7.Visible = false;
                            label2.Visible = false;
                            label8.Visible = false;
                            textBox1.Visible = false;
                            button6.Visible = false;
                            //
                            button1.Visible = true;
                            button5.Visible = true;
                            label1.Visible = true;
                            textBox3.Visible = true;
                            button7.Visible = true;
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
        private void Form6_Load(object sender, EventArgs e)
        {
        }
        private void button7_Click(object sender, EventArgs e)//to show the sorting options
        {
            if (size>0)
            {
                button7.Visible = false;
                label9.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = true;
                button12.Visible = true;
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }
        private void button8_Click(object sender, EventArgs e)//insertion sort
        {
            if (size>0)
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
                MessageBox.Show($"the elements is sorted by insertion sort\nwith running time = {result}");
                is_sorted = true;
                label9.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                //
                button1.Visible = true;
                button5.Visible = true;
                button7.Visible = true;
                label1.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }
        /////////////////////////////////////////////////////////merge sort operation
        private void mergesort(int le, int ri, int m, int[] ar)
        {
            m = (le + ri) / 2;
            int size1 = m - le + 1;
            int size2 = ri - m;
            int[] temp1 = new int[size1];
            int[] temp2 = new int[size2];
            int i, j;
            for (i = 0; i < size1; i++)
            {
                temp1[i] = arr[le + i];
            }
            for (j = 0; j < size2; j++)
            {
                temp2[j] = arr[m + 1 + j];
            }
            i = 0;
            j = 0;
            int k = le;
            while (i < size1 && j < size2)
            {
                if (temp1[i] <= temp2[j])
                {
                    arr[k] = temp1[i];
                    i++;
                }
                else if (temp1[i] > temp2[j])
                {
                    arr[k] = temp2[j];
                    j++;
                }
                k++;
            }
            while (i < size1)
            {
                arr[k] = temp1[i];
                i++;
                k++;
            }
            while (j < size2)
            {
                arr[k] = temp2[j];
                j++;
                k++;
            }
        }
        private void Merge(int l, int r, int[] a)
        {
            if (l >= r)
            {
                return;
            }
            int mid = (l + r) / 2;
            Merge(l, mid, a);
            Merge(mid + 1, r, a);
            mergesort(l, r, mid, arr);
        }
        /////////////////////////////////////////////////////////merge sort operation
        private void button10_Click(object sender, EventArgs e)//merge sort
        {
            if (size > 0)
            {
                int left = 0, right = arr.Length - 1;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Merge(left, right, arr);
                stopwatch.Stop();
                string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                MessageBox.Show($"the elements is sorted by merge sort\nwith running time = {result}");
                is_sorted = true;
                label9.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                //
                button1.Visible = true;
                button5.Visible = true;
                button7.Visible = true;
                label1.Visible = true;
                textBox3.Visible = true;
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
        private void button9_Click(object sender, EventArgs e)//quick sort
        {
            if (size > 0)
            {
                int left = 0, right = arr.Length - 1;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                quicksort(left, right, arr);
                stopwatch.Stop();
                string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                MessageBox.Show($"the elements is sorted by quick sort\nwith running time = {result}");
                is_sorted = true;
                label9.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                //
                button1.Visible = true;
                button5.Visible = true;
                button7.Visible = true;
                label1.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }
        private void button11_Click(object sender, EventArgs e)//selection sort
        {
            if (size>0)
            {
            int i, j, min_index, min;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (i = 0; i < arr.Length; i++)
            {
                min = arr[i];
                min_index = i;
                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        min_index = j;
                    }
                }
                arr[min_index] = arr[i];
                arr[i] = min;
            }
            stopwatch.Stop();
            string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                MessageBox.Show($"the elements is sorted by selection sort\nwith running time = {result}");
                is_sorted = true;
                label9.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                //
                button1.Visible = true;
                button5.Visible = true;
                button7.Visible = true;
                label1.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }
        private void button12_Click(object sender, EventArgs e)//bubble sort
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
                MessageBox.Show($"the elements is sorted by bubble sort\nwith running time = {result}");
                is_sorted = true;
                label9.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                //
                button1.Visible = true;
                button5.Visible = true;
                button7.Visible = true;
                label1.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }

        private void button4_Click(object sender, EventArgs e)//Run button
        {
            if (size > 0)
            {
                if (is_sorted)
                {
                    if (int.TryParse(textBox3.Text, out int key))
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        key = int.Parse(textBox3.Text);
                        bool scan = false;
                        int l = 0, r = arr.Length - 1, mid;
                        while (l <= r)
                        {
                            mid = (l + r) / 2;
                            if (arr[mid] == key)
                            {
                                scan = true;
                                stopwatch.Stop();
                                textBox5.Text = $"found at index {mid}";
                                break;
                            }
                            else if (arr[mid] > key)
                            {
                                r = mid - 1;
                            }
                            else if (arr[mid] < key)
                            {
                                l = mid + 1;
                            }
                        }
                        stopwatch.Stop();
                        string results = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                        if (scan == false)
                        {
                            textBox5.Text = "not found";
                        }
                        textBox6.Text = results;
                    }
                }
                else
                {
                    MessageBox.Show("you must sort the list");
                }
            }
            else
            {
                MessageBox.Show("first generate a list");
            }
        }

        string result = "";
        private void button5_Click(object sender, EventArgs e)//to show the list
        {
            if (size > 0)
            {
                result = "";
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
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ALGORITHM BinarySearch (A[0..n], key)\r\nL = 1, H = A.size\r\nsort()\r\nwhile L <= H do\r\nmid ← (L+ H )/ 2\r\nif key = A[mid]\r\nreturn mid\r\nif key < A[mid]\r\nH ← mid - 1\r\nelse\r\nL ← mid + 1\r\nreturn -1");
        }

        private void button3_Click(object sender, EventArgs e)//to reset
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox7.Clear();
            size = -1;
            arr = new int[0];
            result = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
