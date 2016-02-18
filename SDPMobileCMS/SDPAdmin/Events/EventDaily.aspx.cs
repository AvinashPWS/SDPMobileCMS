using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Events
{
    public partial class EventDaily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DailyEventGridView.DataBind();


        }

        protected void DailyEventSaveButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER DailyEvent = new EVENT_BANNER();

            DailyEvent.EVENT_NAME = DailyEventNameTextBox.Text.Trim();
            DailyEvent.EVENT_DATETIME = DailyEventDateTimeTextBox.Text.Trim();
            DailyEvent.EVENT_ATTACHMENT = DailyEventFileName.Text.Trim();
            DailyEvent.EVENT_INFO = DailyEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertEvent(DailyEvent, "EVENT_DAILY"))
            {
                DailyEventCancelButton_Click(null, null);
                DailyEventGridView.DataBind();
            }

        }

        protected void DailyEventFileUploadButton_Click(object sender, EventArgs e)
        {
            DailyEventFileName.Text = FileUtility.SaveFile(DailyEventFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
        }

        protected void DailyEventDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton DailyEventDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteEvent(DailyEventDeleteButton.CommandArgument, "EVENT_DAILY"))
            {
                DailyEventCancelButton_Click(null, null);
                DailyEventGridView.DataBind();
            }
        }

        protected void DailyEventEditButton_Click(object sender, EventArgs e)
        {
            LinkButton DailyEventEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            EVENT_BANNER DailyEvent = DB.GetEvent(DailyEventEditButton.CommandArgument, "EVENT_DAILY");

            DailyEventSaveButton.Visible = false;
            DailyEventUpdatePanel.Visible = true;

            DailyEventUpdateButton.CommandArgument = Convert.ToString(DailyEvent.ID);
            DailyEventNameTextBox.Text = DailyEvent.EVENT_NAME;
            DailyEventDateTimeTextBox.Text = DailyEvent.EVENT_DATETIME;
            DailyEventInfoTextBox.Text = DailyEvent.EVENT_INFO;
        }

        protected void DailyEventUpdateButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER DailyEvent = new EVENT_BANNER();

            DailyEvent.ID = Convert.ToInt32(DailyEventUpdateButton.CommandArgument);
            DailyEvent.EVENT_NAME = DailyEventNameTextBox.Text.Trim();
            DailyEvent.EVENT_DATETIME = DailyEventDateTimeTextBox.Text.Trim();
            DailyEvent.EVENT_ATTACHMENT = DailyEventFileName.Text.Trim();
            DailyEvent.EVENT_INFO = DailyEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateEvent(DailyEvent, "EVENT_DAILY"))
            {
                DailyEventCancelButton_Click(null, null);
                DailyEventGridView.DataBind();
            }

        }

        protected void DailyEventCancelButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SDPAdmin/Events/EventDaily.aspx");
        }

    }
}