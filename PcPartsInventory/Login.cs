using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PcPartsInventory.Classes;

namespace PcPartsInventory
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            if (username == User.GetUsername(username)
                && Encryption.ComputeSha256Hash(textBox4.Text) == User.GetPassword(username))
            {
                this.Hide();
                HomePage HP = new HomePage();
                HP.ShowDialog();
                textBox4.Text = "";
                textBox3.Text = "";
                this.Show();
            }
            else
                MessageBox.Show("Username or password does not match", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
