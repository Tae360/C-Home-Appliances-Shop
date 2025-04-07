using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeapplianceShop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UidTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter Admin Name and Password");
            }
            else if (UidTb.Text == "Admin" && PasswordTb.Text == "Pass")
            {
                MainForm Main = new MainForm();
                Main.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong Admin or Password");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Selling Sell = new Selling();
            Sell.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UserManual User = new UserManual();
            User.Show();
            this.Hide();
        }
    }
}
