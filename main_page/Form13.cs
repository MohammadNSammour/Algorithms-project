/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////string matching//////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        string word = "";
        string pattern = "";
        private void button4_Click(object sender, EventArgs e)//running button
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    word = textBox1.Text;
                    pattern = textBox2.Text;
                    int first_match_index = -1;
                    int i = 0;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (i = 0; i < word.Length - pattern.Length; i++)
                    {
                        int j = 0;
                        while (j < pattern.Length && pattern[j] == word[i + j])
                        {
                            j++;
                        }
                        if (j == pattern.Length)
                        {
                            first_match_index = i;
                            break;
                        }
                    }
                    stopwatch.Stop();
                    string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                    textBox6.Text = result;
                    if (first_match_index == -1)
                    {
                        textBox3.Text = "Not found";
                    }
                    else
                    {
                        textBox3.Text = $"found in index {i}";
                    }
                    textBox6.Text = result;
                }
                else
                {
                    MessageBox.Show("ener the pattern");
                }
            }
            else
            {
                MessageBox.Show("enter the word");
            }
        }

        private void button6_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show("ALGORITHM BruteForceStringMatch(T [0..n − 1], P[0..m − 1])\r\n for i ← 0 to n - m do\r\n j ← 0\r\n while j < m and P[j] = T[i + j] do\r\n j ← j + 1\r\n if j = m\r\n return i\r\n return -1", "pesudocode");
        }

        private void button5_Click(object sender, EventArgs e)//clear
        {
            word = "";
            pattern = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
        }
    }
}
