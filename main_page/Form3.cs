/// <summary>
/// this program to find the GCD by using consecutive integer checking algorithm 
/// take 2 integer numbers as integer,and return the GCD for these two numbers
/// </summary>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace main_page
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int num1, num2;
        private void button1_Click(object sender, EventArgs e)//run button
        {
            int min;
            Stopwatch stopwatch = new Stopwatch();
            if (int.TryParse(textBox3.Text, out num1) && int.TryParse(textBox4.Text, out num2))//to ensure that the inputs of integer type
            {
                if (num1 > 0 && num2 > 0)
                {
                    if (num1 > num2)//find smallest number
                    {
                        min = num2;
                    }
                    else
                    {
                        min = num1;
                    }
                    stopwatch.Start();//start
                    while (min > 0)
                    {
                        if (num1 % min != 0 || num2 % min != 0)//while the min doesn't divide the two numbers with reminder zero,keep looping
                        {
                            min--;//decreaments the min
                        }
                        else
                        {
                            break;//if we reach that min can divide the numbers evenly with reminder zero
                        }
                    }
                    stopwatch.Stop();//end 
                    textBox5.Text = min.ToString();
                    textBox5.ReadOnly = true;
                    textBox6.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                    textBox6.ReadOnly = true;
                    //GCD = num1%min and num2%min =0,which the greatest number can divide num1 and num2 evenly with reminder zero
                    //(60,24) min=24(num1 no,num2 yes),23(no,no),22(no,no),...,15(yes,no),14(no,no),13(no,no),12(yes,yes) then the result is 12
                }
                else
                {
                    MessageBox.Show("only non negative numbers");
                }
            }
            else
            {
                // handle invalid input
                MessageBox.Show("Please enter valid integer values in both text boxes.");
            }
        }
        private void button2_Click(object sender, EventArgs e)//pesudocode button
        {
            MessageBox.Show("input: m,n \\m,n>0\r\noutput: GCD(m,n)\r\nt <-- min{m,n}\r\nif m mod t =0:\r\n  if n mod t =0:\r\n    return t\r\nelse\r\nt <-- t-1","pesudocode");
        }
        private void button3_Click(object sender, EventArgs e)//clear button
        {
            num1 = -1;
            num2 = -1;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
