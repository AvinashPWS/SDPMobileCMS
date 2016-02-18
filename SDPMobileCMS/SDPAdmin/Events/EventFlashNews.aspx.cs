using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Events
{
    public partial class EventFlashNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FlashNewsEventGridView.DataBind();

        }

        protected void FlashNewsEventSaveButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER FlashNewsEvent = new EVENT_BANNER();

            FlashNewsEvent.EVENT_NAME = FlashNewsEventNameTextBox.Text.Trim();
            FlashNewsEvent.EVENT_DATETIME = FlashNewsEventDateTimeTextBox.Text.Trim();
            FlashNewsEvent.EVENT_ATTACHMENT = FlashNewsEventFileName.Value;
            FlashNewsEvent.EVENT_INFO = FlashNewsEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertEvent(FlashNewsEvent, "EVENT_FLASH"))
            {
                FlashNewsEventCancelButton_Click(null, null);
                FlashNewsEventGridView.DataBind();
            }

        }

        protected void FlashNewsEventFileUploadButton_Click(object sender, EventArgs e)
        {
            FlashNewsEventFileName.Value = FileUtility.SaveFile(FlashNewsEventFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
        }

        protected void FlashNewsEventDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton FlashNewsEventDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteEvent(FlashNewsEventDeleteButton.CommandArgument, "EVENT_FLASH"))
            {
                FlashNewsEventCancelButton_Click(null, null);
                FlashNewsEventGridView.DataBind();
            }
        }

        protected void FlashNewsEventEditButton_Click(object sender, EventArgs e)
        {
            LinkButton FlashNewsEventEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            EVENT_BANNER FlashNewsEvent = DB.GetEvent(FlashNewsEventEditButton.CommandArgument, "EVENT_FLASH");

            FlashNewsEventSaveButton.Visible = false;
            FlashNewsEventUpdatePanel.Visible = true;

            FlashNewsEventUpdateButton.CommandArgument = Convert.ToString(FlashNewsEvent.ID);
            FlashNewsEventNameTextBox.Text = FlashNewsEvent.EVENT_NAME;
            FlashNewsEventDateTimeTextBox.Text = FlashNewsEvent.EVENT_DATETIME;
            FlashNewsEventInfoTextBox.Text = FlashNewsEvent.EVENT_INFO;
        }

        protected void FlashNewsEventUpdateButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER sFlashNewsEvent = new EVENT_BANNER();

            sFlashNewsEvent.ID = Convert.ToInt32(FlashNewsEventUpdateButton.CommandArgument);
            sFlashNewsEvent.EVENT_NAME = FlashNewsEventNameTextBox.Text.Trim();
            sFlashNewsEvent.EVENT_DATETIME = FlashNewsEventDateTimeTextBox.Text.Trim();
            sFlashNewsEvent.EVENT_ATTACHMENT = FlashNewsEventFileName.Value;
            sFlashNewsEvent.EVENT_INFO = FlashNewsEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateEvent(sFlashNewsEvent, "EVENT_FLASH"))
            {
                FlashNewsEventCancelButton_Click(null, null);
                FlashNewsEventGridView.DataBind();
            }

        }

        protected void FlashNewsEventCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Events/EventFlashNews.aspx");
        }

    }
}