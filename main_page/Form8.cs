//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////merge sort////////////////////////////////////////////////////////////////////////////
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
    public partial class Form8 : Form
    {
        int[] arr;
        int size = -1;
        public Form8()
        {

            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
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
        private void button4_Click(object sender, EventArgs e)//run button
        {
            int left = 0, right = arr.Length - 1;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Merge(left, right, arr);
            stopwatch.Stop();
            string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
            textBox6.Text = result;
        }
        private void button2_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show("//for divide the array\nMergeSort(A, l, r):\r\nif l >= r\r\nreturn\r\nmid = (l + r)/2\r\nMergeSort(A, l, mid) \r\nMergeSort(A, mid + 1, r) \r\nmerge(A, l, mid, r) \r\n" +
                "//for create the temp arrays\nmerge(A, l, m, r):\r\n//Create L ← A[l..m] and R ← A[m+1..r] \r\nn1 ← m - l + 1\r\nn2 ← r - m\r\nL[n1], R[n2]\r\nfor i ← 0; i < n1; i++ do\r\nL[i] ← A[l + i]\r\nfor j ← 0; j < n2; j++ do\r\nR[j] ← A[m + 1 + j]\r\n" +
                "//to merge the elments from both arrays\ni ← 0, j ← 0, k ← l\r\nwhile i < n1 and j < n2 do\r\nif L[i] <= R[j]\r\nA[k] ← L[i]\r\ni++\r\nelse\r\nA[k] ← R[j]\r\nj++\r\nk++\r\n" +
                "//for the remaining elements in the arrays\nwhile i < n1 do\r\n A[k] ← L[i]\r\n i++\r\n k++\r\n while j < n2 do\r\n A[k] ← R[j]\r\n j++\r\n k++","pesudocode");
        }

        private void button3_Click(object sender, EventArgs e)//clear
        {
            arr = new int[0];
            size = -1;
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox6.Clear();
        }
    }
}
