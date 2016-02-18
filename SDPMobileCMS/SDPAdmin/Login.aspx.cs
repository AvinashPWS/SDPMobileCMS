using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace SDPAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string sUserID = UserIDTextbox.Text.Trim();
            string sPassword = PasswordTextbox.Text.Trim();

            if (!string.IsNullOrEmpty(sUserID) && !string.IsNullOrEmpty(sPassword))
            {
                if (sUserID.Equals(ConfigurationManager.AppSettings["UserID"].ToString()) & sPassword.Equals(ConfigurationManager.AppSettings["Password"].ToString()))
                {
                    Response.Redirect("~/SDPAdmin/Events/EventBanner.aspx");
                }
                else
                {
                    UserIDTextbox.Text = "";
                    PasswordTextbox.Text = "";
                    LoginMessageLabel.InnerHtml = "Invalid User";
                    UserIDTextbox.Focus();

                }
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            UserIDTextbox.Text = "";
            PasswordTextbox.Text = "";
            LoginMessageLabel.InnerHtml = "";
        }
    }
}