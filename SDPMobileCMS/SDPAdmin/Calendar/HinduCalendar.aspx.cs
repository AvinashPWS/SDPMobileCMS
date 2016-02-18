using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Calendar
{
    public partial class HinduCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HinduCalendarGridView.DataBind();

        }

        protected void HinduCalendarSaveButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER HinduCalendar = new EVENT_BANNER();

            HinduCalendar.EVENT_NAME = HinduCalendarNameTextBox.Text.Trim();
            HinduCalendar.EVENT_ATTACHMENT = HinduCalendarFileName.Text.Trim();
            HinduCalendar.EVENT_TARGET = HinduCalendarDetailFileName.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertEvent(HinduCalendar, "EVENT_CALENDAR"))
            {
                HinduCalendarCancelButton_Click(null, null);
                HinduCalendarGridView.DataBind();
            }

        }

        protected void HinduCalendarFileUploadButton_Click(object sender, EventArgs e)
        {
            if (HinduCalendarFileUpload.HasFile)
            {
                HinduCalendarFileName.Text = FileUtility.SaveFile(HinduCalendarFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
            }
        }

        protected void HinduCalendarDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton HinduCalendarDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteEvent(HinduCalendarDeleteButton.CommandArgument, "EVENT_CALENDAR"))
            {
                HinduCalendarCancelButton_Click(null, null);
                HinduCalendarGridView.DataBind();
            }
        }

        protected void HinduCalendarEditButton_Click(object sender, EventArgs e)
        {
            LinkButton HinduCalendarEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            EVENT_BANNER HinduCalendar = DB.GetEvent(HinduCalendarEditButton.CommandArgument, "EVENT_CALENDAR");

            HinduCalendarSaveButton.Visible = false;
            HinduCalendarUpdatePanel.Visible = true;

            HinduCalendarUpdateButton.CommandArgument = HinduCalendar.ID.ToString();
            HinduCalendarNameTextBox.Text = HinduCalendar.EVENT_NAME;
            HinduCalendarFileName.Text = HinduCalendar.EVENT_ATTACHMENT;
            HinduCalendarDetailFileName.Text = HinduCalendar.EVENT_TARGET;

        }

        protected void HinduCalendarUpdateButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER sHinduCalendar = new EVENT_BANNER();

            sHinduCalendar.ID = Convert.ToInt32(HinduCalendarUpdateButton.CommandArgument);
            sHinduCalendar.EVENT_NAME = HinduCalendarNameTextBox.Text.Trim();
            sHinduCalendar.EVENT_ATTACHMENT = HinduCalendarFileName.Text.Trim();


            DBUtility DB = new DBUtility();

            if (DB.UpdateEvent(sHinduCalendar, "EVENT_CALENDAR"))
            {
                HinduCalendarCancelButton_Click(null, null);
                HinduCalendarGridView.DataBind();
            }

        }

        protected void HinduCalendarCancelButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SDPAdmin/Calendar/HinduCalendar.aspx");

        }

        protected void HinduCalendarDetailFileUploadButton_Click(object sender, EventArgs e)
        {
            if (HinduCalendarDetailFileUpload.HasFile)
            {
                HinduCalendarDetailFileName.Text = FileUtility.SaveFile(HinduCalendarDetailFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
            }
        }
    }
}