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

            Push.ActiveForm.Enabled = false;


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
                        //Data = JObject.Parse("{\"alert\":\"" + MessageTexBox.Text.Trim() + "\",\"badge\":1,\"sound\":\"sound.caf\",\"imageURL\":\"http://saidattanj.org/images/banner24.png\"}")
                        Data = JObject.Parse("{\"alert\":\"" + MessageTexBox.Text.Trim() + "\",\"badge\":1,\"sound\":\"sound.caf\",\"imageURL\":\"\"}")
                    });
                }
            }



            // Stop the broker, wait for it to finish   
            // This isn't done after every message, but after you're
            // done with the broker
            appleBroker.Stop();
            googleBroker.Stop();

            MessageBox.Show("Push Notification sent successfully");

            MessageTexBox.Text = "";
            RoleListBox.SelectedItems.Clear();

            Push.ActiveForm.Enabled = true;
        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            MessageTexBox.Text = "";
            RoleListBox.SelectedItems.Clear();
        }

    }

    public class AppPushBrokers
    {
        public ApnsServiceBroker Apns { get; set; }
        public GcmServiceBroker Gcm { get; set; }
    }

}
