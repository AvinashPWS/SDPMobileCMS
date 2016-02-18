using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace SDPAdmin.Gallery
{
    public partial class Videos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VideoGridView.DataBind();
        }


        protected void VideoSaveButton_Click(object sender, EventArgs e)
        {
            LIST_VIDEOS Video = new LIST_VIDEOS();

            Video.VIDEO_HEADER = VideoHeaderNameTextBox.Text.Trim();
            Video.VIDEO_TITLE = VideoTitleTextBox.Text.Trim();
            Video.VIDEO_URL = VideoURLTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.InsertVideo(Video))
            {
                VideoCancelButton_Click(null, null);
                VideoGridView.DataBind();
            }
        }


        protected void VideoUpdateButton_Click(object sender, EventArgs e)
        {
            LIST_VIDEOS Video = new LIST_VIDEOS();

            Video.ID = Convert.ToInt32(VideoUpdateButton.CommandArgument);
            Video.VIDEO_HEADER = VideoHeaderNameTextBox.Text.Trim();
            Video.VIDEO_TITLE = VideoTitleTextBox.Text.Trim();
            Video.VIDEO_URL = VideoURLTextBox.Text.Trim();

            DBUtility DB = new DBUtility();

            if (DB.UpdateVideo(Video))
            {
                VideoCancelButton_Click(null, null);
                VideoGridView.DataBind();
            }

        }

        protected void VideoCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Gallery/Videos.aspx");
        }

        protected void VideoEditButton_Click(object sender, EventArgs e)
        {
            LinkButton VideoEditButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            LIST_VIDEOS Video = DB.GetVideo(VideoEditButton.CommandArgument);

            VideoSaveButton.Visible = false;
            VideoUpdatePanel.Visible = true;

            VideoUpdateButton.CommandArgument = Convert.ToString(Video.ID);
            VideoHeaderNameTextBox.Text = Video.VIDEO_HEADER;
            VideoTitleTextBox.Text = Video.VIDEO_TITLE;
            VideoURLTextBox.Text = Video.VIDEO_URL;
            VideoPlayer.Attributes["src"] = GetYouTubeVideo(VideoURLTextBox.Text.Trim());

        }

        protected void VideoDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton VideoDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteVideo(VideoDeleteButton.CommandArgument))
            {
                VideoCancelButton_Click(null, null);
                VideoGridView.DataBind();
            }

        }


        public string GetYouTubeVideo(String sVideoURL)
        {

            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["YouTubeURL"]) + sVideoURL;


        }

        protected void VideoPreviewButton_Click(object sender, EventArgs e)
        {
            VideoPlayer.Attributes["src"] = GetYouTubeVideo(VideoURLTextBox.Text.Trim());
        }

    }
}