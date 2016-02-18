using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Gallery
{
    public partial class Quotes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            QuoteGridView.DataBind();

        }

        protected void QuoteUpdateButton_Click(object sender, EventArgs e)
        {
            LIST_QUOTES Quote = new LIST_QUOTES();

            Quote.ID = Convert.ToInt32(QuoteUpdateButton.CommandArgument);
            Quote.QUOTE = QuoteTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateQuote(Quote))
            {
                QuoteCancelButton_Click(null, null);
                QuoteGridView.DataBind();
            }
        }

        protected void QuoteCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Gallery/Quotes.aspx");
        }

        protected void QuoteSaveButton_Click(object sender, EventArgs e)
        {
            LIST_QUOTES Quote = new LIST_QUOTES();

            Quote.QUOTE = QuoteTextBox.Text;

            DBUtility DB = new DBUtility();

            if (DB.InsertQuote(Quote))
            {
                QuoteCancelButton_Click(null, null);
                QuoteGridView.DataBind();
            }
        }

        protected void QuoteEditButton_Click(object sender, EventArgs e)
        {
            LinkButton QuoteEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            LIST_QUOTES Quote = DB.GetQuote(QuoteEditButton.CommandArgument);

            QuoteSaveButton.Visible = false;
            QuoteUpdatePanel.Visible = true;

            QuoteUpdateButton.CommandArgument = Convert.ToString(Quote.ID);
            QuoteTextBox.Text = Quote.QUOTE;
        }

        protected void QuoteDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton QuoteDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteQuote(QuoteDeleteButton.CommandArgument))
            {
                QuoteCancelButton_Click(null, null);
                QuoteGridView.DataBind();
            }
        }
    }
}