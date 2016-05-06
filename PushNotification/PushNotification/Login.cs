using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PushNotification
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UserIDTextbox.Text = "";
            PasswordTextbox.Text = "";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserIDTextbox.Text.Trim().Equals(Properties.Resources.UserID) && PasswordTextbox.Text.Trim().Equals(Properties.Resources.Password))
            {
                Login.ActiveForm.Hide();
                Push p = new Push();
                p.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials", "Sai Datta Peetham - Pusher App");
            }
        }
    }
}
