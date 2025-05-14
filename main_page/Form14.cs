//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////closest pairs//////////////////////////////////////////////////////////////////////////
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

namespace main_page
{
    public partial class Form14 : Form
    {
        struct point
        {
            public int x;
            public int y;
        }
        Button button3 = new Button();
        public Form14()
        {
            InitializeComponent();
            //for button3 events and properites
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(50, 126);
            button3.Name = "button3";
            button3.Size = new Size(75, 30);
            button3.TabIndex = 111;
            button3.Text = "Send";
            button3.UseVisualStyleBackColor = true;
            this.Controls.Add(button3);
            button3.Visible = false;
            button3.Click += button3_Click;
            //
        }
        private int number_of_points = -1;
        point[] points;
        private void button4_Click(object sender, EventArgs e)//create the array
        {
            if (int.TryParse(textBox1.Text, out number_of_points))
            {
                number_of_points = int.Parse(textBox1.Text);
                if (number_of_points > 0)
                {
                    button4.Visible = false;
                    button3.Visible = true;
                    textBox1.ReadOnly = true;
                    points = new point[number_of_points];
                    for (int i = 0; i < number_of_points; i++)
                    {
                        points[i] = new point();
                        points[i].x = points[i].y = -1;
                    }
                }
                else
                {
                    MessageBox.Show("enter a valid number");
                }
            }
            else
            {
                MessageBox.Show("enter an valid input");
            }
        }
        int count = 0;
        string pairs = "";
        private void button3_Click(object? sender, EventArgs e)//take the x and y values
        {
            if (count < number_of_points)
            {
                if (int.TryParse(textBox2.Text, out int y) && int.TryParse(textBox3.Text, out int x))
                {
                    x = int.Parse(textBox2.Text);
                    y = int.Parse(textBox3.Text);
                    textBox2.Clear();
                    textBox3.Clear();
                    points[count] = new point { x = x, y = y };
                    pairs += "(" + points[count].x + "," + points[count].y + ") ";
                    count++;
                    if (count == number_of_points)
                    {
                        button3.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("enter only numbers");
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)//show the pairs
        {
            if (number_of_points > 0)
            {
                if (points[0].x != -1 && points[0].y != -1)
                {
                    MessageBox.Show(pairs);
                }
                else
                {
                    MessageBox.Show("no points are entered");
                }
            }
            else
            {
                MessageBox.Show("enter the number of points first");
            }

        }

        private void button1_Click(object sender, EventArgs e)//running button
        {
            if (number_of_points > 0)
            {
                if (points.All(p => p.x != -1 && p.y != -1))
                {
                    double distance = double.PositiveInfinity;
                    int point1 = -1;
                    int point2 = -1;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < number_of_points; i++)
                    {
                        for (int j = i + 1; j < number_of_points; j++)
                        {
                            double currentDistance = Math.Sqrt(Math.Pow(points[i].x - points[j].x, 2) + Math.Pow(points[i].y - points[j].y, 2));
                            if (currentDistance < distance)
                            {
                                distance = currentDistance;
                                point1 = i;
                                point2 = j;
                            }
                        }
                    }
                    stopwatch.Stop();
                    if (point1 != -1 && point2 != -1)
                    {
                        string result = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";
                        textBox6.Text = "(" + points[point1].x + "," + points[point1].y + ")";
                        textBox7.Text = "(" + points[point2].x + "," + points[point2].y + ")";
                        textBox4.Text = distance.ToString();
                        textBox5.Text = result;
                    }
                else
                {
                        MessageBox.Show("no valid points found for distance calculation");
                    }
            }
            else
                {
                    MessageBox.Show("no points exist");
                }
            }
            else
            {
                MessageBox.Show("enter the number of points first");
            }
        }

        private void button6_Click(object sender, EventArgs e)//pesudocode
        {
            MessageBox.Show(" d ← ∞\r\n for i ← 0 to n - 1 do\r\n for j ← i + 1 to n - 1 do\r\nd ← min(d, sqrt((xi – xj)2 + (yi – yj)2)) // sqrt is square root\r\n j ← j + 1\r\n i ← i + 1\r\n return d\r\n","pesudocode");
        }
        private void button5_Click(object sender, EventArgs e)//clear
        {
            number_of_points = -1;
            pairs = "";
            points = new point[0];
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            button3.Visible = false;
            button4.Visible = true;
            textBox1.ReadOnly = false;
        }
    }
}
