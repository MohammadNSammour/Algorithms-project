///<summary>
///this form for the main menu in the program
///provide an algorithms list and let the user choose any algorithm,and run the form that direct to that algorithm
///</summary>
using System;
using System.Diagnostics;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace main_page
{
    public partial class Form2 : Form
    {
        private System.Windows.Forms.Timer timer;
        private DateTime currentDate;
        //
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");//for cpu utilize reader
        private PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");//for ram utilize reader 
        public Form2()
        {
            InitializeComponent();
            currentDate = DateTime.Now.Date;//for date
            label9.Text = currentDate.ToString("yyyy-MM-dd");//to show the date
            StartClock();
        }
        private void StartClock()//update the time every second or every 1000 interval to show the real time now
        {
            timer = timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;//1 second
            timer.Tick += Timer_Tick;//this event will be excuted every 1000 interval(1 second)
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("HH:mm:ss");//to show the time
            try
            {
                label12.Text = $"{cpuCounter.NextValue():0.00}%";//cpu
                label13.Text = $"{ramCounter.NextValue()} MB";//ram
            }
            catch (Exception ex)//so many cases one of them is that you don't have permissions to access them(requires previlige access)
            {
                label12.Text = "error fetching CPU data.";
                label13.Text = "error fetching RAM data.";
                Console.WriteLine(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)//1.GCD by using consecutive integer checking algorithm
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
        private void button2_Click(object sender, EventArgs e)//2.GCD by using Euclids algorithm
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
        private void button3_Click(object sender, EventArgs e)//3.Sequential search
        {
            Form4 form4 = new Form4();
            form4.Show();

        }
        private void button4_Click(object sender, EventArgs e)//4.Binary search
        {
            Form6 form6 = new Form6();
            form6.Show();
        }
        private void button5_Click(object sender, EventArgs e)//5.Insertion sort
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
        private void button6_Click(object sender, EventArgs e)//6.Merge sort
        {
            Form8 form8 = new Form8();
            form8.Show();
        }
        private void button7_Click(object sender, EventArgs e)//7.Quick sort
        {
            Form9 form9 = new Form9();
            form9.Show();
        }
        private void button8_Click(object sender, EventArgs e)//8.Counting Coins
        {
            Form10 form10 = new Form10();
            form10.Show();
        }
        private void button9_Click(object sender, EventArgs e)//9.selection sort
        {
            Form11 form11 = new Form11();
            form11.Show();
        }
        private void button10_Click(object sender, EventArgs e)//10.bubble sort
        {
            Form12 form12 = new Form12();
            form12.Show();
        }
        private void button11_Click(object sender, EventArgs e)//11.string matching
        {
            Form13 form13 = new Form13();
            form13.Show();
        }
        private void button12_Click(object sender, EventArgs e)//12.closest pair
        {
            Form14 form14 = new Form14();
            form14.Show();
        }
        private void button13_Click(object sender, EventArgs e)//13.fibonacci series
        {
            Form15 form15 = new Form15();
            form15.Show();
        }
        private void button14_Click(object sender, EventArgs e)//14.Fib_T_D
        {
            Form16 form16 = new Form16();
            form16.Show();
        }
        private void button15_Click(object sender, EventArgs e)//15.Fib_B_U
        {
            Form17 form17 = new Form17();
            form17.Show();
        }

        private void button16_Click(object sender, EventArgs e)//16.Interpolation search
        {
            Form18 form18 = new Form18();
            form18.Show();
        }

        private void button17_Click(object sender, EventArgs e)//17.jump search
        {
            Form19 form19 = new Form19();
            form19.Show();
        }

        private void button18_Click(object sender, EventArgs e)//18.exponential search
        {
            Form20 form20 = new Form20();
            form20.Show();
        }
    }
}
