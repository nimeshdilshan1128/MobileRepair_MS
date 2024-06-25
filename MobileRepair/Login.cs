using System;
using System.Windows.Forms;

namespace MobileRepair
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Details !");
            }
            else if (UNameTb.Text == "Admin" && PasswordTb.Text == "12345")
            {
                Repairs Obj = new Repairs();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or password !");
            }
        }

        private void UNameTb_Click(object sender, EventArgs e)
        {
          
        }

        private void PasswordTb_Click(object sender, EventArgs e)
        {

        }
    }
}
