//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////login screen//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Media;
using System.Diagnostics;
namespace main_page
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//log in button
        {
            string ur_name = textBox0.Text;
            string pass = textBox1.Text;
            if ((ur_name == "mohammad sammour" && pass == "admin1") || (ur_name == "mutaz abu sara" && pass == "admin"))//true info
            {
                button0.BackColor = Color.Green;
                MessageBox.Show($"Welcome to the program {ur_name} !", "Welcome message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SystemSounds.Beep.Play();
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
                form2.FormClosed += (s, args) => Application.Exit();
            }
            else//false info
            {
                button0.BackColor = Color.Red;
                MessageBox.Show("your user name or password in incorrect\nplease contant us", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SystemSounds.Exclamation.Play();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)//social media
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/mohammadnafiz.summour",
                UseShellExecute = true
            });
        }
        private void pictureBox2_Click(object sender, EventArgs e)//social media
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/mohammadnsammour40/",
                UseShellExecute = true
            });
        }
        private void pictureBox3_Click(object sender, EventArgs e)//social media
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/MohammadNSammour",
                UseShellExecute = true
            });
        }
    }
}
