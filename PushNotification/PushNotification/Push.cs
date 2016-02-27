using PushSharp;
using PushSharp.Google;
using PushSharp.Apple;
using PushSharp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace PushNotification
{
    public class AppPushBrokers
    {
        public ApnsServiceBroker Apns { get; set; }
        public GcmServiceBroker Gcm { get; set; }
    }



    public partial class Push : Form
    {
        public Push()
        {
            InitializeComponent();
        }



        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MessageTexBox.Text.Trim()))
            {
                SendNotifications();
            }
            else
            {
                MessageBox.Show("Please enter a Notification Messsage");
            }
        }


        public void SendNotifications()
        {
            var appleCert = Properties.Resources.SDP_CERTIFICATE_PROD;

            // Configuration
            var appleConfig = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, appleCert, "");
            var googleConfig = new GcmConfiguration(Properties.Resources.GoogleAPIKey);


            // Create a new broker
            var appleBroker = new ApnsServiceBroker(appleConfig);
            var googleBroker = new GcmServiceBroker(googleConfig);

            // Wire up events
            appleBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {

                aggregateEx.Handle(ex =>
                {

                    // See what kind of exception it was to further diagnose
                    if (ex is ApnsNotificationException)
                    {
                        var apnsEx = ex as ApnsNotificationException;

                        // Deal with the failed notification
                        var n = apnsEx.Notification;

                        Console.WriteLine("Notification Failed: ID={n.Identifier}, Code={apnsEx.ErrorStatusCode}");

                    }
                    else if (ex is ApnsConnectionException)
                    {
                        // Something failed while connecting (maybe bad cert?)
                        Console.WriteLine("Notification Failed (Bad APNS Connection)!");
                    }
                    else
                    {
                        Console.WriteLine("Notification Failed (Unknown Reason)!");
                    }

                    // Mark it as handled
                    return true;
                });
            };

            appleBroker.OnNotificationSucceeded += (notification) =>
            {
                Console.WriteLine("Notification Sent!");
            };

            // Wire up events
            googleBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {

                aggregateEx.Handle(ex =>
                {
                    // Mark it as handled
                    return true;
                });
            };

            googleBroker.OnNotificationSucceeded += (notification) =>
            {
                Console.WriteLine("Notification Sent!");
            };

            // Start the broker
            appleBroker.Start();
            googleBroker.Start();

            string sRoles = "";
            for (int i = 0; i < RoleListBox.SelectedItems.Count; i++)
            {
                sRoles += "ROLE LIKE '%" + RoleListBox.SelectedItems[i] + "%' OR ";
            }

            if (string.IsNullOrEmpty(sRoles))
            {
                sRoles = "ROLE LIKE '%ALL%'";
            }
            else
            {
                sRoles = sRoles + "OR";
                sRoles = System.Text.RegularExpressions.Regex.Replace(sRoles, "OR OR", "");
            }

            SqlConnection sConnection = new SqlConnection(Properties.Resources.SaiDatta);

            DataTable DeviceIDDataTable = new DataTable();

            sConnection.Open();

            string sSQL = "SELECT DEVICE_ID,DEVICE_TYPE FROM NOTIFICATION_DEVICES WHERE " + sRoles;

            SqlDataAdapter sAdapter = new SqlDataAdapter(sSQL, sConnection);
            sAdapter.Fill(DeviceIDDataTable);

            List<string> sDeviceIDList = new List<string>();

            for (int i = 0; i < DeviceIDDataTable.Rows.Count; i++)
            {
                if (Convert.ToString(DeviceIDDataTable.Rows[i]["DEVICE_TYPE"]).ToUpper().Trim() == "IOS")
                {
                    // Queue a notification to send
                    appleBroker.QueueNotification(new ApnsNotification
                    {
                        DeviceToken = Convert.ToString(DeviceIDDataTable.Rows[i]["DEVICE_ID"]),
                        Payload = JObject.Parse("{\"aps\":{\"alert\":\"" + MessageTexBox.Text.Trim() + "\"}}"),

                    });
                }
                else
                {
                    sDeviceIDList.Clear();
                    sDeviceIDList.Add(Convert.ToString(DeviceIDDataTable.Rows[i]["DEVICE_ID"]));

                    googleBroker.QueueNotification(new GcmNotification
                    {
                        RegistrationIds = sDeviceIDList,
                        Data = JObject.Parse("{\"alert\":\"" + MessageTexBox.Text.Trim() + "\",\"badge\":1,\"sound\":\"sound.caf\",\"imageURL\":\"http://saidattanj.org/images/banner24.png\"}")
                    });
                }
            }



            // Stop the broker, wait for it to finish   
            // This isn't done after every message, but after you're
            // done with the broker
            appleBroker.Stop();
            googleBroker.Stop();

            MessageBox.Show("Push Notification sent successfully");
        }

        public void SendNotifications1()
        {

            ////create the puchbroker object
            //var push = new pushbr();
            ////Wire up the events for all the services that the broker registers
            //push.OnNotificationSent += NotificationSent;
            ////push.OnChannelException += ChannelException;
            //push.OnServiceException += ServiceException;
            //push.OnNotificationFailed += NotificationFailed;
            //push.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
            //push.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
            ////push.OnChannelCreated += ChannelCreated;
            //push.OnChannelDestroyed += ChannelDestroyed;

            //try
            //{

            //    string sRoles = "";
            //    for (int i = 0; i < RoleListBox.SelectedItems.Count; i++)
            //    {
            //        sRoles += "ROLE LIKE '%" + RoleListBox.SelectedItems[i] + "%' OR ";
            //    }

            //    if (string.IsNullOrEmpty(sRoles))
            //    {
            //        sRoles = "ROLE LIKE '%ALL%'";
            //    }
            //    else
            //    {
            //        sRoles = sRoles + "OR";
            //        sRoles = System.Text.RegularExpressions.Regex.Replace(sRoles, "OR OR", "");
            //    }

            //    //var appleCert = Properties.Resources.SDP_CERTIFICATE_DEV;
            //    //push.RegisterAppleService(new ApplePushChannelSettings(false, appleCert, ""));

            //    try
            //    {
            //        var appleCert = Properties.Resources.SDP_CERTIFICATE_PROD;

            //        push.RegisterAppleService(new ApplePushChannelSettings(true, appleCert, ""));
            //    }
            //    catch (Exception ex)
            //    {

            //    }

            //    push.RegisterGcmService(new GcmPushChannelSettings(Properties.Resources.GoogleAPIKey));

            //    SqlConnection sConnection = new SqlConnection(Properties.Resources.SaiDatta);

            //    DataTable DeviceIDDataTable = new DataTable();

            //    sConnection.Open();

            //    string sSQL = "SELECT DEVICE_ID,DEVICE_TYPE FROM NOTIFICATION_DEVICES WHERE " + sRoles;

            //    SqlDataAdapter sAdapter = new SqlDataAdapter(sSQL, sConnection);
            //    sAdapter.Fill(DeviceIDDataTable);

            //    for (int i = 0; i < DeviceIDDataTable.Rows.Count; i++)
            //    {
            //        if (Convert.ToString(DeviceIDDataTable.Rows[i]["DEVICE_TYPE"]).ToUpper().Trim() == "IOS")
            //        {
            //            push.QueueNotification(new AppleNotification()
            //                                        .ForDeviceToken(Convert.ToString(DeviceIDDataTable.Rows[i]["DEVICE_ID"]))
            //                                        .WithAlert(MessageTexBox.Text.Trim())
            //                                        .WithBadge(1));
            //        }
            //        else
            //        {
            //            //    push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(Convert.ToString(DeviceIDDataTable.Rows[i]["DEVICE_ID"]))
            //            //     .WithJson("{\"alert\":\"" + MessageTexBox.Text.Trim() + "\",\"badge\":1,\"sound\":\"sound.caf\",\"imageURL\":\"http://saidattanj.org/images/banner24.png\"}"));
            //        }
            //    }

            //    sConnection.Close();
            //}
            //catch (Exception ex)
            //{

            //}

            //push.StopAllServices(waitForQueuesToFinish: true);

            //MessageBox.Show("Push Notifications sent successfully!!!");
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
            //    var appleCert = Properties.Resources.FGAppCertificateTEST;
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
            //    //push.RegisterGcmService(new
            //    // GcmPushChannelSettings("YOUR Google API's Console API Access  API KEY for Server Apps HERE"));
            //    ////Fluent construction of an Android GCM Notification
            //    ////IMPORTANT: For Android you MUST use your own RegistrationId 
            //    ////here that gets generated within your Android app itself!
            //    //push.QueueNotification(new GcmNotification().ForDeviceRegistrationId("DEVICE REGISTRATION ID HERE")
            //    // .WithJson("{\"alert\":\"Hello World!\",\"badge\":7,\"sound\":\"sound.caf\"}"));
            //}
            //catch (Exception ex) { }

            //push.StopAllServices(waitForQueuesToFinish: true);

        }

        //Currently it will raise only for android devices
        static void DeviceSubscriptionChanged(object sender,
        string oldSubscriptionId, string newSubscriptionId, INotification notification)
        {
            //Do something here
        }

        //this even raised when a notification is successfully sent
        static void NotificationSent(object sender, INotification notification)
        {
            //Do something here
        }

        //this is raised when a notification is failed due to some reason
        static void NotificationFailed(object sender,
        INotification notification, Exception notificationFailureException)
        {
            //Do something here

            //delete the device id from DB
        }

        ////this is fired when there is exception is raised by the channel
        //static void ChannelException
        //    (object sender, IPushChannel channel, Exception exception)
        //{
        //    //Do something here
        //}

        //this is fired when there is exception is raised by the service
        static void ServiceException(object sender, Exception exception)
        {
            //Do something here
        }

        //this is raised when the particular device subscription is expired
        static void DeviceSubscriptionExpired(object sender,
        string expiredDeviceSubscriptionId,
            DateTime timestamp, INotification notification)
        {
            //Do something here
        }

        //this is raised when the channel is destroyed
        static void ChannelDestroyed(object sender)
        {
            //Do something here
        }

        ////this is raised when the channel is created
        //static void ChannelCreated(object sender, IPushChannel pushChannel)
        //{
        //    //Do something here
        //}

        private void ResetButton_Click(object sender, EventArgs e)
        {
            MessageTexBox.Text = "";
            RoleListBox.SelectedItems.Clear();
        }

    }
}
