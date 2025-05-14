//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////counting coins////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace main_page
{
    public partial class Form10 : Form
    {
        int cash = 0;
        int[] coins_types;
        bool is_num_one_there = false;
        public Form10()
        {
            InitializeComponent();
            button6.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            textBox2.Visible = false;
            button7.Visible = false;
            textBox4.Visible = false;

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)//to take the cash ammount
        {
            if (int.TryParse(textBox1.Text, out cash))
            {
                cash = int.Parse(textBox1.Text);
                if (cash > 0)
                {
                    button1.Visible = false;
                    button6.Visible = true;
                    //label2.Visible = false;
                    //textBox1.Visible = false;
                    label6.Visible = true;
                    textBox3.Visible = true;
                }
                else
                {
                    MessageBox.Show("enter a valid ammount of cash");
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("enter an valid input");
            }
        }

        private void button6_Click(object sender, EventArgs e)//to create the coins types array
        {
            if (cash > 0)
            {
                if (int.TryParse(textBox3.Text, out int num_of_coins))
                {
                    coins_types = new int[num_of_coins];
                    if(num_of_coins > 0)
                    {
                        button6.Visible = false;
                        button7.Visible = true;
                        label1.Visible = true;
                        textBox2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("enter a valid number");
                        textBox3.Clear();
                    }  
                }
                else
                {
                    MessageBox.Show("enter an valid input");
                }
            }
            else
            {
                MessageBox.Show("first enter the cash amount");
            }
        }
        int i = 0;
        private void button7_Click(object sender, EventArgs e)//to take the coins types from user
        {
            if (i < coins_types.Length)
            {
                if (int.TryParse(textBox2.Text, out int coinValue))
                {
                    coins_types[i] = coinValue;
                    if (coinValue == 1)
                    {
                        is_num_one_there = true;
                    }
                    i++;
                    if (i == coins_types.Length)
                    {
                        button7.Visible = false;
                        textBox2.Visible = false;
                        textBox4.Visible = true;
                        textBox4.ReadOnly = true;
                        textBox4.Text = string.Join(" ", coins_types);
                    }
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Enter a valid coin value.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        { 
        }

        private void button4_Click(object sender, EventArgs e)//run button
        {
            if (cash > 0)
            {
                if (is_num_one_there)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    int sum = 0;
                    string result = "";
                    int Count = 0;
                    int i, j, temp;
                    //sorting
                    for (i = 1; i < coins_types.Length; i++)
                    {
                        temp = coins_types[i];
                        j = i - 1;
                        while (j >= 0 && coins_types[j] < temp)
                        {
                            coins_types[j + 1] = coins_types[j];
                            j--;
                        }
                        coins_types[j + 1] = temp;
                    }
                    //generate the coins series
                    int num_oc = 0;
                    while (sum != cash)
                    {
                        if (sum + coins_types[Count] <= cash)
                        {
                            num_oc++;
                            sum += coins_types[Count];
                            result += coins_types[Count].ToString() + " ";
                        }
                        else
                        {
                            Count++;
                        }
                    }
                    stopwatch.Stop();
                    string time = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                    textBox5.Text = $"{num_oc}";
                    textBox6.Text = result;
                    textBox7.Text = time;
                }
                else
                {
                    MessageBox.Show("you must ensure that number 1 is in the list\nclear your inputs and try again");
                }
            }
            else
            {
                MessageBox.Show("first enter the cash amount");
            }
        }

        private void button2_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show("ALGORITHM Counting Coins (coins[0..n], value)\r\noutput_linked_list, sum ← 0, count ← 0\r\ndecreaseSort(coins)\r\nwhile sum ≠ value do \r\nif sum + coins[count] <= value then\r\nsum ← sum + coins[count]\r\noutput_linked_list ← coins[count] \r\nelse\r\ncount ← count + 1\r\nreturn output_linked_list", "pesudocode");
        }

        private void button3_Click(object sender, EventArgs e)//reset
        {
            cash = 0;// reset cash amount
            coins_types = new int[0];// clear coins array
            is_num_one_there = false;// reset the flag
            i = 0;// reset the index for entering coin types
            button1.Visible = true;
            button6.Visible = false;// hide until cash is entered
            button7.Visible = false;// hide until coin types are entered
            textBox1.Text = "";// clear cash input
            textBox2.Text = "";// clear coin type input
            textBox3.Text = "";// clear number of coin types input
            textBox4.Clear();// clear display of entered coin types
            textBox5.Clear();// clear display of result count
            textBox6.Clear();// clear display of result coins
            textBox7.Clear();// clear display of execution time
            label6.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            textBox2.Visible = false;
            textBox4.Visible = false;
        }
    }
}

