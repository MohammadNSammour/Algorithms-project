/// <summary>
/// this program to find the GCD by using Euclids algorithm 
/// take 2 integer numbers as integer,and return the GCD for these two numbers
/// </summary>
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        int num1, num2;
        private void button1_Click(object sender, EventArgs e)
        {
            int r;
            if (int.TryParse(textBox3.Text, out num1) && int.TryParse(textBox4.Text, out num2))
            {
                if (num1 > 0 && num2 > 0)
                {
                    Stopwatch sw = new Stopwatch();
                    if (num1 < num2)//ensure that the num1 is always largest
                    {
                        int temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }
                    sw.Start();
                    while (num2 != 0)//while the num2 isn't equal zero,keep looping
                    {
                        r = num1 % num2;//find the reminder
                        num1 = num2;//give num1 the value of num2 (num2,num2)
                        num2 = r;//give num2 the value of the reminder(num1,num2=r) and go back untill the num2 reach zero
                    }
                    sw.Stop();
                    textBox5.Text = num1.ToString();
                    textBox5.ReadOnly = true;
                    textBox6.Text=sw.Elapsed.TotalMilliseconds.ToString()+" ms";
                    textBox6.ReadOnly = true;
                    //GCD(num1, num2) = GCD(num2, num1 % num2) /until num2 becomes 0.
                    //(60,24) --> (24,12) --> (12,0) ----->>>> 12
                }
                else
                {
                    MessageBox.Show("only non-negative numbers");
                }
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Please enter valid integer values in both text boxes.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this program is to find the GCD between two nums by euclids algorithm\r\ninput: m,n \\ m,n->int,m,n>0,m>n\r\noutput:GCD (m,n)\r\n  while n!=0 :\r\n  r <-- m mod n\r\n  m <--n\r\n  n <--r\r\nreturn m\r\n//this is a pseudocode language", "pseudocode");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
