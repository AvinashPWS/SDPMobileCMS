using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Events
{
    public partial class EventSponsors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SponsorsEventGridView.DataBind();
        }

        protected void SponsorsEventSaveButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER SponsorsEvent = new EVENT_BANNER();

            SponsorsEvent.EVENT_NAME = SponsorsEventNameTextBox.Text.Trim();
            SponsorsEvent.EVENT_DATETIME = SponsorsEventDateTimeTextBox.Text.Trim();
            SponsorsEvent.EVENT_ATTACHMENT = SponsorsEventFileName.Value;
            SponsorsEvent.EVENT_INFO = SponsorsEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertEvent(SponsorsEvent, "EVENT_SPONSOR"))
            {
                SponsorsEventCancelButton_Click(null, null);
                SponsorsEventGridView.DataBind();
            }

        }

        protected void SponsorsEventFileUploadButton_Click(object sender, EventArgs e)
        {
            SponsorsEventFileName.Value = FileUtility.SaveFile(SponsorsEventFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
        }

        protected void SponsorsEventDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton SponsorsEventDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteEvent(SponsorsEventDeleteButton.CommandArgument, "EVENT_SPONSOR"))
            {
                SponsorsEventCancelButton_Click(null, null);
                SponsorsEventGridView.DataBind();
            }
        }

        protected void SponsorsEventEditButton_Click(object sender, EventArgs e)
        {
            LinkButton SponsorsEventEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            EVENT_BANNER SponsorsEvent = DB.GetEvent(SponsorsEventEditButton.CommandArgument, "EVENT_SPONSOR");

            SponsorsEventSaveButton.Visible = false;
            SponsorsEventUpdatePanel.Visible = true;

            SponsorsEventUpdateButton.CommandArgument = Convert.ToString(SponsorsEvent.ID);
            SponsorsEventNameTextBox.Text = SponsorsEvent.EVENT_NAME;
            SponsorsEventDateTimeTextBox.Text = SponsorsEvent.EVENT_DATETIME;
            SponsorsEventInfoTextBox.Text = SponsorsEvent.EVENT_INFO;
        }

        protected void SponsorsEventUpdateButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER sSponsorsEvent = new EVENT_BANNER();

            sSponsorsEvent.ID = Convert.ToInt32(SponsorsEventUpdateButton.CommandArgument);
            sSponsorsEvent.EVENT_NAME = SponsorsEventNameTextBox.Text.Trim();
            sSponsorsEvent.EVENT_DATETIME = SponsorsEventDateTimeTextBox.Text.Trim();
            sSponsorsEvent.EVENT_ATTACHMENT = SponsorsEventFileName.Value;
            sSponsorsEvent.EVENT_INFO = SponsorsEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateEvent(sSponsorsEvent, "EVENT_SPONSOR"))
            {
                SponsorsEventCancelButton_Click(null, null);
                SponsorsEventGridView.DataBind();
            }

        }

        protected void SponsorsEventCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Events/EventSponsors.aspx");
        }

    }
}