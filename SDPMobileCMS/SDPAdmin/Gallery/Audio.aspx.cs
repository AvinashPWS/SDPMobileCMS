using System;
using System.Web.UI.WebControls;

namespace SDPAdmin.Gallery
{
    public partial class Audio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AudioGridView.DataBind();
        }

        protected void AudioFileUploadButton_Click(object sender, EventArgs e)
        {
            AudioFileName.Text = FileUtility.SaveFile(AudioFileUpload, Server.MapPath("~/SDPAdmin/appData/EVENTS/"), "~/SDPAdmin/appData/EVENTS/");
            
        }


        protected void AudioSaveButton_Click(object sender, EventArgs e)
        {
            LIST_AUDIO Audio = new LIST_AUDIO();


            Audio.AUDIO_TITLE = AudioTitleTextBox.Text.Trim();
            Audio.AUDIO_ATTACHMENT = AudioFileName.Text.Trim();


            DBUtility DB = new DBUtility();

            if (DB.InsertAudio(Audio))
            {
                AudioCancelButton_Click(null, null);
                AudioGridView.DataBind();
            }
        }


        

        protected void AudioCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SDPAdmin/Gallery/Audio.aspx");
        }

       

        protected void AudioDeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton AudioDeleteButton = (LinkButton)sender;

            DBUtility DB = new DBUtility();

            if (DB.DeleteAudio(AudioDeleteButton.CommandArgument))
            {
                AudioCancelButton_Click(null, null);
                AudioGridView.DataBind();
            }

        }

    }
}