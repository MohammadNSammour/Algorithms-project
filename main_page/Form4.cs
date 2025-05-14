/// <summary>
/// this form is to find an some element in randomized array elements
/// output an list and make the user enter the number he wants and output the running time
/// </summary>
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace main_page
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            label2.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            button6.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox4.Visible = false;
            textBox7.Visible = false;
        }
        int[] arr;
        int size = -1;
        private void button1_Click_1(object sender, EventArgs e)
        {
            label2.Visible = true;
            label8.Visible = true;
            textBox1.Visible = true;
            button6.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            textBox4.Visible = true;
            textBox7.Visible = true;
            //
            button1.Visible = false;
            button5.Visible = false;
            label1.Visible = false;
            textBox3.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)
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
            else{
                MessageBox.Show("first generate a list");
            }
            
        }
         
        private void button4_Click(object sender, EventArgs e)
        {
            if(size > 0)
            {
                if (int.TryParse(textBox3.Text, out int key)) 
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    //stopwatch.Start();
                    key = int.Parse(textBox3.Text);
                    bool scan = false;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (key == arr[i])
                        {
                            scan = true;
                            textBox5.Text = $"found in {i} index";
                            break;
                        }
                        if (scan == false)
                        {
                            textBox5.Text = "not found";
                        }
                        stopwatch.Stop();
                        textBox6.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                        textBox5.ReadOnly= false;
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
                MessageBox.Show("first generate a list");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ALGORITHM SequentialSearch (A[0..n], K)\r\ni ← 0\r\nwhile i < n and A[i] ≠ K do\r\ni ← i + 1\r\nif i < n\r\nreturn i\r\nelse\r\nreturn -1", "pesudocode");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox7.Clear();
            arr = new int[0];
            size=-1;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out size))
            {
                size = int.Parse(textBox1.Text);
                if (size > 0)
                {
                    arr = new int[size];
                    if (int.TryParse(textBox2.Text, out int seed))
                    {
                        if(int.TryParse(textBox4.Text,out int min)&&int.TryParse(textBox7.Text,out int max))
                        {
                            Random random = new Random(seed);
                            for (int i = 0; i < size; i++)
                            {
                                arr[i] = random.Next(min, max);
                            }
                            MessageBox.Show("Generate is complete,click ok to continue");
                            label10.Visible = false;
                            label11.Visible = false;
                            textBox2.Visible = false;
                            textBox4.Visible = false;
                            textBox7.Visible = false;
                            label2.Visible = false;
                            label8.Visible = false;
                            label9.Visible = false;
                            textBox1.Visible = false;
                            button6.Visible = false;
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
        //forbidden
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}