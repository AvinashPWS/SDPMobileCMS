using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Events
{
    public partial class EventRegular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            RegularEventGridView.DataBind();

        }

        protected void RegularEventSaveButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER RegularEvent = new EVENT_BANNER();

            RegularEvent.EVENT_NAME = RegularEventNameTextBox.Text.Trim();
            RegularEvent.EVENT_DATETIME = RegularEventDateTimeTextBox.Text.Trim();
            RegularEvent.EVENT_ATTACHMENT = RegularEventFileName.Value;
            RegularEvent.EVENT_INFO = RegularEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertEvent(RegularEvent, "EVENT_REGULAR"))
            {
                RegularEventCancelButton_Click(null, null);
                RegularEventGridView.DataBind();
            }

        }

        protected void RegularEventFileUploadButton_Click(object sender, EventArgs e)
        {
            RegularEventFileName.Value = FileUtility.SaveFile(RegularEventFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
        }

        protected void RegularEventDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton RegularEventDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteEvent(RegularEventDeleteButton.CommandArgument, "EVENT_REGULAR"))
            {
                RegularEventCancelButton_Click(null, null);
                RegularEventGridView.DataBind();
            }
        }

        protected void RegularEventEditButton_Click(object sender, EventArgs e)
        {
            LinkButton RegularEventEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            EVENT_BANNER RegularEvent = DB.GetEvent(RegularEventEditButton.CommandArgument, "EVENT_REGULAR");

            RegularEventSaveButton.Visible = false;
            RegularEventUpdatePanel.Visible = true;

            RegularEventUpdateButton.CommandArgument = Convert.ToString(RegularEvent.ID);
            RegularEventNameTextBox.Text = RegularEvent.EVENT_NAME;
            RegularEventDateTimeTextBox.Text = RegularEvent.EVENT_DATETIME;
            RegularEventInfoTextBox.Text = RegularEvent.EVENT_INFO;
        }

        protected void RegularEventUpdateButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER RegularEvent = new EVENT_BANNER();

            RegularEvent.ID = Convert.ToInt32(RegularEventUpdateButton.CommandArgument);
            RegularEvent.EVENT_NAME = RegularEventNameTextBox.Text.Trim();
            RegularEvent.EVENT_DATETIME = RegularEventDateTimeTextBox.Text.Trim();
            RegularEvent.EVENT_ATTACHMENT = RegularEventFileName.Value;
            RegularEvent.EVENT_INFO = RegularEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateEvent(RegularEvent, "EVENT_REGULAR"))
            {
                RegularEventCancelButton_Click(null, null);
                RegularEventGridView.DataBind();
            }

        }

        protected void RegularEventCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Events/EventRegular.aspx");
        }

    }
}