using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDPAdmin.Events
{
    public partial class EventBanner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BannerEventGridView.DataBind();

        }


        protected void BannerEventSaveButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER BannerEvent = new EVENT_BANNER();

            BannerEvent.EVENT_NAME = BannerEventNameTextBox.Text.Trim();
            BannerEvent.EVENT_DATETIME = BannerEventDateTimeTextBox.Text.Trim();
            BannerEvent.EVENT_ATTACHMENT = BannerEventFileName.Text.Trim();

            BannerEvent.EVENT_TARGET_TYPE = "FILE";
            if (BannerEventTargetTypeURL.Checked)
            {
                BannerEvent.EVENT_TARGET_TYPE = "URL";
                BannerEventTargetName.Text = BannerEventTargetTypeURLTextBox.Text.Trim();
            }

            BannerEvent.EVENT_TARGET = BannerEventTargetName.Text.Trim();
            BannerEvent.EVENT_INFO = BannerEventInfoTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertEvent(BannerEvent, "EVENT_BANNER"))
            {
                BannerEventCancelButton_Click(null, null);
                BannerEventGridView.DataBind();
            }

        }

        protected void BannerEventFileUploadButton_Click(object sender, EventArgs e)
        {
            if (BannerEventFileUpload.HasFile)
                BannerEventFileName.Text = FileUtility.SaveFile(BannerEventFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
        }

        protected void BannerEventDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton BannerEventDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteEvent(BannerEventDeleteButton.CommandArgument, "EVENT_BANNER"))
            {
                BannerEventCancelButton_Click(null, null);
                BannerEventGridView.DataBind();
            }
        }

        protected void BannerEventEditButton_Click(object sender, EventArgs e)
        {
            LinkButton BannerEventEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            EVENT_BANNER BannerEvent = DB.GetEvent(BannerEventEditButton.CommandArgument, "EVENT_BANNER");

            BannerEventSaveButton.Visible = false;
            BannerEventUpdatePanel.Visible = true;

            BannerEventUpdateButton.CommandArgument = Convert.ToString(BannerEvent.ID);
            BannerEventNameTextBox.Text = BannerEvent.EVENT_NAME;
            BannerEventDateTimeTextBox.Text = BannerEvent.EVENT_DATETIME;
            BannerEventInfoTextBox.Text = BannerEvent.EVENT_INFO;
            BannerEventFileName.Text = BannerEvent.EVENT_ATTACHMENT;
            BannerEventTargetName.Text = BannerEvent.EVENT_TARGET;
            BannerEventTargetType.Value = BannerEvent.EVENT_TARGET_TYPE;


        }

        protected void BannerEventUpdateButton_Click(object sender, EventArgs e)
        {
            EVENT_BANNER BannerEvent = new EVENT_BANNER();

            BannerEvent.ID = Convert.ToInt32(BannerEventUpdateButton.CommandArgument);
            BannerEvent.EVENT_NAME = BannerEventNameTextBox.Text.Trim();
            BannerEvent.EVENT_DATETIME = BannerEventDateTimeTextBox.Text.Trim();
            BannerEvent.EVENT_ATTACHMENT = BannerEventFileName.Text.Trim();
            BannerEvent.EVENT_INFO = BannerEventInfoTextBox.Text.Trim();
            BannerEvent.EVENT_TARGET = BannerEventTargetName.Text.Trim();

            BannerEvent.EVENT_TARGET_TYPE = "FILE";
            if (BannerEventTargetTypeURL.Checked)
            {
                BannerEvent.EVENT_TARGET_TYPE = "URL";
                BannerEventTargetName.Text = BannerEventTargetTypeURLTextBox.Text.Trim();
            }

            DBUtility DB = new DBUtility();

            if (DB.UpdateEvent(BannerEvent, "EVENT_BANNER"))
            {
                BannerEventCancelButton_Click(null, null);
                BannerEventGridView.DataBind();
            }

        }

        protected void BannerEventCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Events/EventBanner.aspx");
        }

        protected void BannerEventTargetFile_CheckedChanged(object sender, EventArgs e)
        {
            if (BannerEventTargetTypeFile.Checked)
            {
                BannerEventTargetType.Value = "FILE";
                BannerEventTargetURLPanel.Visible = false;
                BannerEventTargetTypeFileUpload.Visible = true;
                BannerEventTargetUploadButton.Visible = true;
                //BannerEventTargetNameRequiredFieldValidator.Enabled = true;
                //BannerEventTargetTypeURLRequiredFieldValidator.Enabled = false;
            }
        }

        protected void BannerEventTargetURL_CheckedChanged(object sender, EventArgs e)
        {
            if (BannerEventTargetTypeURL.Checked)
            {
                BannerEventTargetType.Value = "URL";
                BannerEventTargetURLPanel.Visible = true;
                BannerEventTargetTypeFileUpload.Visible = false;
                BannerEventTargetUploadButton.Visible = false;
                //BannerEventTargetNameRequiredFieldValidator.Enabled = false;
                //BannerEventTargetTypeURLRequiredFieldValidator.Enabled = true;
            }
        }

        protected void BannerEventTargetUploadButton_Click(object sender, EventArgs e)
        {
            if (BannerEventTargetTypeFileUpload.HasFile)
                BannerEventTargetName.Text = FileUtility.SaveFile(BannerEventTargetTypeFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
        }

    }
}