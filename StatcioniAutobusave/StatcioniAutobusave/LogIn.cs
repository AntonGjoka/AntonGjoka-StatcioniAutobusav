using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatcioniAutobusave.BO;
using StatcioniAutobusave.BLL;

namespace StatcioniAutobusave
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            if (Username.Trim()=="")
            {
                txtUsername.BackColor = Color.Red;
                txtPassword.Focus();
                return;
            }
            if (Password.Trim() == "")
            {
                txtPassword.BackColor = Color.Red;
                txtPassword.Focus();
                return;
            }
            AdministrationBLL administration = new AdministrationBLL();
            User user  = administration.userlogin(Username,Password);

            if (user==null)
            {
                MessageBox.Show("Kontrolloni username/password ");
            }
            else
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
