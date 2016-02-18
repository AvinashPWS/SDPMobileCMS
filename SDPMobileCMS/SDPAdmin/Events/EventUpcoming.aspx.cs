using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Events
{
    public partial class EventUpcoming : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UpcomingEventGridView.DataBind();

        }

        protected void UpcomingEventSaveButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER UpcomingEvent = new EVENT_BANNER();

            UpcomingEvent.EVENT_NAME = UpcomingEventNameTextBox.Text.Trim();
            UpcomingEvent.EVENT_DATETIME = UpcomingEventDateTimeTextBox.Text.Trim();
            UpcomingEvent.EVENT_ATTACHMENT = UpcomingEventFileName.Value;
            UpcomingEvent.EVENT_INFO = UpcomingEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertEvent(UpcomingEvent, "EVENT_UPCOMING"))
            {
                UpcomingEventCancelButton_Click(null, null);
                UpcomingEventGridView.DataBind();
            }

        }

        protected void UpcomingEventFileUploadButton_Click(object sender, EventArgs e)
        {
            UpcomingEventFileName.Value = FileUtility.SaveFile(UpcomingEventFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
        }

        protected void UpcomingEventDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton UpcomingEventDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteEvent(UpcomingEventDeleteButton.CommandArgument, "EVENT_UPCOMING"))
            {
                UpcomingEventCancelButton_Click(null, null);
                UpcomingEventGridView.DataBind();
            }
        }

        protected void UpcomingEventEditButton_Click(object sender, EventArgs e)
        {
            LinkButton UpcomingEventEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            EVENT_BANNER UpcomingEvent = DB.GetEvent(UpcomingEventEditButton.CommandArgument, "EVENT_UPCOMING");

            UpcomingEventSaveButton.Visible = false;
            UpcomingEventUpdatePanel.Visible = true;

            UpcomingEventUpdateButton.CommandArgument = Convert.ToString(UpcomingEvent.ID);
            UpcomingEventNameTextBox.Text = UpcomingEvent.EVENT_NAME;
            UpcomingEventDateTimeTextBox.Text = UpcomingEvent.EVENT_DATETIME;
            UpcomingEventInfoTextBox.Text = UpcomingEvent.EVENT_INFO;
        }

        protected void UpcomingEventUpdateButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER sUpcomingEvent = new EVENT_BANNER();

            sUpcomingEvent.ID = Convert.ToInt32(UpcomingEventUpdateButton.CommandArgument);
            sUpcomingEvent.EVENT_NAME = UpcomingEventNameTextBox.Text.Trim();
            sUpcomingEvent.EVENT_DATETIME = UpcomingEventDateTimeTextBox.Text.Trim();
            sUpcomingEvent.EVENT_ATTACHMENT = UpcomingEventFileName.Value;
            sUpcomingEvent.EVENT_INFO = UpcomingEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateEvent(sUpcomingEvent, "EVENT_UPCOMING"))
            {
                UpcomingEventCancelButton_Click(null, null);
                UpcomingEventGridView.DataBind();
            }

        }

        protected void UpcomingEventCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Events/EventUpcoming.aspx");
        }

    }
}