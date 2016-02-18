using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Seva
{
    public partial class SevaSthalaFAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            FAQGridView.DataBind();

        }

        protected void FAQUpdateButton_Click(object sender, EventArgs e)
        {

            SEVA_STHALA_FAQ SEVA_STHALA_FAQ = new SDPAdmin.SEVA_STHALA_FAQ();
            SEVA_STHALA_FAQ.ID = Convert.ToInt32(FAQUpdateButton.CommandArgument);
            SEVA_STHALA_FAQ.QUESTION = QuestionTextBox.Text.Trim();
            SEVA_STHALA_FAQ.ANSWER = AnswerTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateFAQ(SEVA_STHALA_FAQ))
            {
                FAQCancelButton_Click(null, null);
                FAQGridView.DataBind();
            }
        }

        protected void FAQCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Seva/SevaSthalaFAQ.aspx");
        }

        protected void FAQSaveButton_Click(object sender, EventArgs e)
        {
            SEVA_STHALA_FAQ SEVA_STHALA_FAQ = new SDPAdmin.SEVA_STHALA_FAQ();
            SEVA_STHALA_FAQ.QUESTION = QuestionTextBox.Text.Trim();
            SEVA_STHALA_FAQ.ANSWER = AnswerTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertFAQ(SEVA_STHALA_FAQ))
            {
                FAQCancelButton_Click(null, null);
                FAQGridView.DataBind();
            }
        }

        protected void FAQEditButton_Click(object sender, EventArgs e)
        {
            LinkButton FAQEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            SEVA_STHALA_FAQ SEVA_STHALA_FAQ = DB.GetFAQ(FAQEditButton.CommandArgument);

            FAQSaveButton.Visible = false;
            FAQUpdatePanel.Visible = true;

            FAQUpdateButton.CommandArgument = Convert.ToString(SEVA_STHALA_FAQ.ID);
            QuestionTextBox.Text = SEVA_STHALA_FAQ.QUESTION;
            AnswerTextBox.Text = SEVA_STHALA_FAQ.ANSWER;
        }

        protected void FAQDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton FAQDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteFAQ(FAQDeleteButton.CommandArgument))
            {
                FAQCancelButton_Click(null, null);
                FAQGridView.DataBind();
            }
        }
    }
}