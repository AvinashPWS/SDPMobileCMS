using System;
using System.Web.UI.WebControls;

namespace SDPAdmin.Gallery
{
    public partial class Images : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageGridView.DataBind();
        }

        protected void ImageFileUploadButton_Click(object sender, EventArgs e)
        {
            ImageFileName.Text = FileUtility.SaveFile(ImageFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
            ImagePreview.ImageUrl = ImageFileName.Text.Trim();
        }


        protected void ImageSaveButton_Click(object sender, EventArgs e)
        {
            LIST_IMAGES Image = new LIST_IMAGES();

            Image.IMAGE_HEADER = ImageHeaderNameTextBox.Text.Trim();
            Image.IMAGE_TITLE = ImageTitleTextBox.Text.Trim();
            Image.IMAGE_ATTACHMENT = ImageFileName.Text.Trim();
            Image.IMAGE_TARGET = ImageTargetTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertImage(Image))
            {
                ImageCancelButton_Click(null, null);
                ImageGridView.DataBind();
            }
        }


        protected void ImageUpdateButton_Click(object sender, EventArgs e)
        {
            LIST_IMAGES Image = new LIST_IMAGES();

            Image.ID = Convert.ToInt32(ImageUpdateButton.CommandArgument);
            Image.IMAGE_HEADER = ImageHeaderNameTextBox.Text.Trim();
            Image.IMAGE_TITLE = ImageTitleTextBox.Text.Trim();
            Image.IMAGE_ATTACHMENT = ImageFileName.Text;
            Image.IMAGE_TARGET = ImageTargetTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateImage(Image))
            {
                ImageCancelButton_Click(null, null);
                ImageGridView.DataBind();
            }

        }

        protected void ImageCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Gallery/Images.aspx");
        }

        protected void ImageEditButton_Click(object sender, EventArgs e)
        {
            LinkButton ImageEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            LIST_IMAGES Image = DB.GetImage(ImageEditButton.CommandArgument);

            ImageSaveButton.Visible = false;
            ImageUpdatePanel.Visible = true;

            ImageUpdateButton.CommandArgument = Convert.ToString(Image.ID);
            ImageHeaderNameTextBox.Text = Image.IMAGE_HEADER;
            ImageTitleTextBox.Text = Image.IMAGE_TITLE;
            ImageTargetTextBox.Text = Image.IMAGE_TARGET;
            ImagePreview.ImageUrl = Image.IMAGE_ATTACHMENT;
            ImageTargetTextBox.Text = ImageTargetTextBox.Text;
        }

        protected void ImageDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton ImageDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteImage(ImageDeleteButton.CommandArgument))
            {
                ImageCancelButton_Click(null, null);
                ImageGridView.DataBind();
            }

        }

    }
}