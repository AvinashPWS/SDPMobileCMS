using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Net;
namespace SDPAdmin.Notifications
{
    public partial class SendNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void NotificationSendButton_Click(object sender, EventArgs e)
        {
            string filename = "~/SDPAdmin/PushNotification.exe";

            if (filename != "")
            {
                string path = Server.MapPath(filename);
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
                else
                {
                    Response.Write("This file does not exist.");
                }
            }
        }



        public void Sample()
        {

            ////create the puchbroker object
            //var push = new PushBroker();
            ////Wire up the events for all the services that the broker registers
            //push.OnNotificationSent += NotificationSent;
            //push.OnChannelException += ChannelException;
            //push.OnServiceException += ServiceException;
            //push.OnNotificationFailed += NotificationFailed;
            //push.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
            //push.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
            //push.OnChannelCreated += ChannelCreated;
            //push.OnChannelDestroyed += ChannelDestroyed;

            //try
            //{
            //    var appleCert = File.ReadAllBytes(Server.MapPath(ConfigurationManager.AppSettings["AppleCertificate"].ToString()));
            //    //IMPORTANT: If you are using a Development provisioning Profile, you must use
            //    // the Sandbox push notification server 
            //    //  (so you would leave the first arg in the ctor of ApplePushChannelSettings as
            //    // 'false')
            //    //  If you are using an AdHoc or AppStore provisioning profile, you must use the 
            //    //Production push notification server
            //    //  (so you would change the first arg in the ctor of ApplePushChannelSettings to 
            //    //'true')
            //    push.RegisterAppleService(new ApplePushChannelSettings(true, appleCert, "monsanto"));
            //    //Extension method
            //    //Fluent construction of an iOS notification
            //    //IMPORTANT: For iOS you MUST MUST MUST use your own DeviceToken here that gets
            //    // generated within your iOS app itself when the Application Delegate
            //    //  for registered for remote notifications is called, 
            //    // and the device token is passed back to you
            //    push.QueueNotification(new AppleNotification()
            //                                .ForDeviceToken("75e082e97cc16169674595924a5357d0c8bb7af83a26ec39dbb3176285757bbb")//the recipient device id
            //                                .WithAlert("Push Notification from ASP.NET")//the message
            //                                .WithBadge(1)
            //        //.WithSound("sound.caf")
            //                                );


            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}


            //try
            //{
            //    //---------------------------
            //    // ANDROID GCM NOTIFICATIONS
            //    //---------------------------
            //    //Configure and start Android GCM
            //    //IMPORTANT: The API KEY comes from your Google APIs Console App, 
            //    //under the API Access section, 
            //    //  by choosing 'Create new Server key...'
            //    //  You must ensure the 'Google Cloud Messaging for Android' service is 
            //    //enabled in your APIs Console
            //    push.RegisterGcmService(new
            //     GcmPushChannelSettings("YOUR Google API's Console API Access  API KEY for Server Apps HERE"));
            //    //Fluent construction of an Android GCM Notification
            //    //IMPORTANT: For Android you MUST use your own RegistrationId 
            //    //here that gets generated within your Android app itself!
            //    push.QueueNotification(new GcmNotification().ForDeviceRegistrationId("DEVICE REGISTRATION ID HERE")
            //     .WithJson("{\"alert\":\"Hello World!\",\"badge\":7,\"sound\":\"sound.caf\"}"));
            //}
            //catch (Exception ex) { }

            //push.StopAllServices(waitForQueuesToFinish: true);
        }


    }
}