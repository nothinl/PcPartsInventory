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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.UserAdd(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text);
            MessageBox.Show("Account Creation Successful", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
