using System;
using System.Web.UI.WebControls;

namespace SDPAdmin.Seva
{
    public partial class SevaSthalaMedia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MediaGridView.DataBind();
        }

        protected void MediaFileUploadButton_Click(object sender, EventArgs e)
        {
            MediaFileName.Text = FileUtility.SaveFile(MediaFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");

        }


        protected void MediaSaveButton_Click(object sender, EventArgs e)
        {

            SEVA_STHALA_MEDIA Media = new SEVA_STHALA_MEDIA();

            Media.MEDIA_HEADER = MediaHeaderNameTextBox.Text.Trim();
            Media.MEDIA_TITLE = MediaTitleTextBox.Text.Trim();
            Media.MEDIA_TYPE = MediaTypeDropDownList.SelectedItem.Text;
            if (MediaTypeDropDownList.SelectedIndex == 0)
            {
                Media.MEDIA_ATTACHMENT = MediaFileName.Text;
            }
            else
            {
                Media.MEDIA_ATTACHMENT = MediaAttachmentTextbox.Text;
            }


            DBUtility DB = new DBUtility();

            if (DB.InsertMedia(Media, "SEVA_STHALA_MEDIA"))
            {
                MediaCancelButton_Click(null, null);
                MediaGridView.DataBind();
            }
        }


        protected void MediaUpdateButton_Click(object sender, EventArgs e)
        {
            SEVA_STHALA_MEDIA Media = new SEVA_STHALA_MEDIA();

            Media.ID = Convert.ToInt32(MediaUpdateButton.CommandArgument);
            Media.MEDIA_HEADER = MediaHeaderNameTextBox.Text.Trim();
            Media.MEDIA_TITLE = MediaTitleTextBox.Text.Trim();
            Media.MEDIA_TYPE = MediaTypeDropDownList.SelectedItem.Text;
            if (MediaTypeDropDownList.SelectedIndex == 0)
            {
                Media.MEDIA_ATTACHMENT = MediaFileName.Text;
            }
            else
            {
                Media.MEDIA_ATTACHMENT = MediaAttachmentTextbox.Text;
            }

            DBUtility DB = new DBUtility();

            if (DB.UpdateMedia(Media, "SEVA_STHALA_MEDIA"))
            {
                MediaCancelButton_Click(null, null);
                MediaGridView.DataBind();
            }

        }

        protected void MediaCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Seva/SevaSthalaMedia.aspx");
        }

        protected void MediaEditButton_Click(object sender, EventArgs e)
        {
            LinkButton MediaEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            SEVA_STHALA_MEDIA Media = DB.GetMedia(MediaEditButton.CommandArgument, "SEVA_STHALA_MEDIA");

            MediaSaveButton.Visible = false;
            MediaUpdatePanel.Visible = true;

            MediaUpdateButton.CommandArgument = Convert.ToString(Media.ID);
            MediaHeaderNameTextBox.Text = Media.MEDIA_HEADER;
            MediaTitleTextBox.Text = Media.MEDIA_TITLE;
            MediaTypeDropDownList.SelectedIndex = Media.MEDIA_TYPE == "IMAGE" ? 0 : 1;

            if (MediaTypeDropDownList.SelectedIndex == 0)
            {
                MediaFileName.Text = Media.MEDIA_ATTACHMENT;
            }
            else
            {
                MediaAttachmentTextbox.Text = Media.MEDIA_ATTACHMENT;
            }


        }

        protected void MediaDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton MediaDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteMedia(MediaDeleteButton.CommandArgument, "SEVA_STHALA_MEDIA"))
            {
                MediaCancelButton_Click(null, null);
                MediaGridView.DataBind();
            }

        }

        protected void MediaTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MediaTypeDropDownList.SelectedIndex == 0)
            {
                MediaTypeImagePanel.Visible = true;
                MediaTypeVideoPanel.Visible = false;
                MediaAttachmentRequiredFieldValidator.Enabled = true;
            }
            else
            {
                MediaTypeImagePanel.Visible = false;
                MediaTypeVideoPanel.Visible = true;
                MediaAttachmentRequiredFieldValidator.Enabled = false;
            }
        }

    }
}