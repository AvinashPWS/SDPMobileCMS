using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Configuration;
using System.Net.Mail;

namespace SDPAdmin.API
{
    [ScriptService]
    public partial class SDPMobileService : System.Web.UI.Page
    {
        [WebMethod]
        public static void GetData(string sSP_Name)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write(js.Serialize(GetDataEntity(sSP_Name)));
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        [WebMethod]
        public static void SetDonation(string sDonationJSON, string sDetailJSON)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            DonationDetail sDonationDetails = js.Deserialize<DonationDetail>(sDonationJSON);
            List<DonationMember> sDonationMembers = js.Deserialize<List<DonationMember>>(sDetailJSON);

            System.Text.StringBuilder StrXml = new System.Text.StringBuilder();
            StrXml.Append("<NewDataSet>").AppendLine();

            for (int i = 0; i < sDonationMembers.Count; i++)
            {

                StrXml.Append("<Table1>").AppendLine();
                StrXml.Append("<Name>" + sDonationMembers[i].Name + "</Name>").AppendLine();
                StrXml.Append("<Nakshatram>" + sDonationMembers[i].Nakshatram + "</Nakshatram>").AppendLine();
                StrXml.Append("</Table1>").AppendLine();
            }

            StrXml.Append("</NewDataSet>").AppendLine();

            string str = StrXml.ToString();

            DateTime sDonationDate = Convert.ToDateTime(sDonationDetails.DateOn);

            SqlConnection sConnection = new SqlConnection(Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["SaiDatta"]));
            sConnection.Open();

            SqlCommand sCommand = new SqlCommand("uspInsertDonationPaymentDetails", sConnection);
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.Parameters.AddWithValue("@DonationID", Convert.ToInt32(sDonationDetails.DonationID));
            sCommand.Parameters.AddWithValue("@TotAmount", Convert.ToString(sDonationDetails.TotalAmount));
            sCommand.Parameters.AddWithValue("@Email", Convert.ToString(sDonationDetails.Email));
            sCommand.Parameters.AddWithValue("@Mobile", Convert.ToString(sDonationDetails.PhoneNumber));
            sCommand.Parameters.AddWithValue("@Gothram", Convert.ToString(sDonationDetails.Gotram));
            sCommand.Parameters.AddWithValue("@xmlString", Convert.ToString(str));
            sCommand.Parameters.Add("@DATE", SqlDbType.DateTime).Value = sDonationDate;

            sCommand.ExecuteNonQuery();
            sConnection.Close();

            SendMailDonation(StrXml.ToString(), sDonationDetails);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write("{\"STATUS\":\"TRUE\"}");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }


        [WebMethod]
        public static void SetDonationSthalaSeva(string sDonationJSON, string sDetailJSON)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            DonationDetail sDonationDetails = js.Deserialize<DonationDetail>(sDonationJSON);
            List<DonationMember> sDonationMembers = js.Deserialize<List<DonationMember>>(sDetailJSON);

            System.Text.StringBuilder StrXml = new System.Text.StringBuilder();
            StrXml.Append("<NewDataSet>").AppendLine();

            for (int i = 0; i < sDonationMembers.Count; i++)
            {
                StrXml.Append("<Table1>").AppendLine();
                StrXml.Append("<SNO>" + sDonationMembers[i].SNO + "</SNO>").AppendLine();
                StrXml.Append("<FirstName>" + sDonationMembers[i].FirstName + "</FirstName>").AppendLine();
                StrXml.Append("<LastName>" + sDonationMembers[i].LastName + "</LastName>").AppendLine();
                StrXml.Append("</Table1>").AppendLine();
            }

            StrXml.Append("</NewDataSet>").AppendLine();

            string str = StrXml.ToString();

            DateTime sDonationDate = Convert.ToDateTime(sDonationDetails.DateOn);

            SqlConnection sConnection = new SqlConnection(Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["SaiDatta"]));
            sConnection.Open();

            SqlCommand sCommand = new SqlCommand("uspInsertPaymentDetails", sConnection);
            sCommand.CommandType = CommandType.StoredProcedure;

            sCommand.Parameters.AddWithValue("@TotAmount", Convert.ToString(sDonationDetails.TotalAmount));
            sCommand.Parameters.AddWithValue("@Email", Convert.ToString(sDonationDetails.Email));
            sCommand.Parameters.AddWithValue("@Mobile", Convert.ToString(sDonationDetails.PhoneNumber));
            sCommand.Parameters.AddWithValue("@xmlString", Convert.ToString(str));

            sCommand.ExecuteNonQuery();
            sConnection.Close();

            SendMailSthalaSeva(StrXml.ToString(), sDonationDetails);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write("{\"STATUS\":\"TRUE\"}");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        [WebMethod]
        public static void SetDeviceToken(string sDeviceTokenJSON)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            NOTIFICATION_DEVICES sDeviceToken = js.Deserialize<NOTIFICATION_DEVICES>(sDeviceTokenJSON);

            SDPAdmin.SDPEntities SDPDatabase = new SDPAdmin.SDPEntities();

            string sResponse = "{\"STATUS\":\"TRUE\"}";
            try
            {

                NOTIFICATION_DEVICES sDeleteDeviceToken = (from DeviceToken in SDPDatabase.NOTIFICATION_DEVICES
                                                           where DeviceToken.DEVICE_ID == sDeviceToken.DEVICE_ID
                                                           select DeviceToken).FirstOrDefault();
                if (sDeleteDeviceToken != null)
                {
                    SDPDatabase.DeleteObject(sDeleteDeviceToken);
                    SDPDatabase.SaveChanges();
                }

                if (string.IsNullOrEmpty(sDeviceToken.ROLE.Trim()))
                {
                    sDeviceToken.ROLE = "ALL";
                }

                sDeviceToken.DATETIME = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                SDPDatabase.AddToNOTIFICATION_DEVICES(sDeviceToken);
                SDPDatabase.SaveChanges();
            }
            catch (Exception sException)
            {
                sResponse = "{\"STATUS\":\"" + sException.Message + "\"}";
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            HttpContext.Current.Response.Write(sResponse);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static Object GetDataEntity(string sSP_Name)
        {
            SDPAdmin.SDPEntities SDPDatabase = new SDPAdmin.SDPEntities();

            Object sListSpecific = new Object();

            SqlConnection sConnection = new SqlConnection(Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["SaiDatta"]));

            switch (sSP_Name)
            {

                case "GET_DONATIONS":

                    List<Donation> DonationList = new List<Donation>();
                    SqlCommand sCommand = new SqlCommand("uspBindDonations", sConnection);
                    sCommand.CommandType = CommandType.StoredProcedure;
                    sConnection.Open();

                    using (IDataReader reader = sCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DonationList.Add(new Donation
                            {
                                ID = Convert.ToString(reader["DONATION_ID"]),
                                Name = Convert.ToString(reader["DONATION_NAME"]),
                                Amount = (Convert.ToString(reader["DONATION_NAME"]) == "Daily Annadhanam" ? "151" : (Convert.ToString(reader["DONATION_NAME"]) == "Weekend (1 Day) Annadhanam" ? "251" : (Convert.ToString(reader["DONATION_NAME"]) == "Weekly (7 Days) Annadhanam" ? "516" : (Convert.ToString(reader["DONATION_NAME"]) == "Monthly Annadhanam" ? "1116" : (Convert.ToString(reader["DONATION_NAME"]) == "Saswitha Annadhanam (Yearly 1 day for life)" ? "5116" : "100")))))
                            });
                        }
                    }

                    sListSpecific = DonationList;

                    sConnection.Close();

                    break;

                case "EVENT_BANNER":
                    sListSpecific = (from row in SDPDatabase.EVENT_BANNER
                                     select row).ToList<EVENT_BANNER>();
                    break;
                case "EVENT_CALENDAR":
                    sListSpecific = (from row in SDPDatabase.EVENT_CALENDAR
                                     select row).ToList<EVENT_CALENDAR>();
                    break;
                case "EVENT_DAILY":
                    sListSpecific = (from row in SDPDatabase.EVENT_DAILY
                                     select row).ToList<EVENT_DAILY>();
                    break;
                case "EVENT_FLASH":
                    sListSpecific = (from row in SDPDatabase.EVENT_FLASH
                                     select row).ToList<EVENT_FLASH>();
                    break;
                case "EVENT_REGULAR":
                    sListSpecific = (from row in SDPDatabase.EVENT_REGULAR
                                     select row).ToList<EVENT_REGULAR>();
                    break;
                case "EVENT_SPONSOR":
                    sListSpecific = (from row in SDPDatabase.EVENT_SPONSOR
                                     select row).ToList<EVENT_SPONSOR>();
                    break;
                case "EVENT_UPCOMING":
                    sListSpecific = (from row in SDPDatabase.EVENT_UPCOMING
                                     select row).ToList<EVENT_UPCOMING>();
                    break;
                case "LIST_IMAGES":
                    sListSpecific = (from row in SDPDatabase.LIST_IMAGES
                                     select row).ToList<LIST_IMAGES>();
                    break;
                case "LIST_QUOTES":

                    int maxValue = (from row in SDPDatabase.LIST_QUOTES
                                    select row).ToList<LIST_QUOTES>().Count;
                    Random rand = new Random();
                    int toSkip = rand.Next(0, maxValue);
                    sListSpecific = SDPDatabase.LIST_QUOTES.OrderBy(c => c.ID).Skip(toSkip).Take(1).FirstOrDefault();

                    break;
                case "LIST_VIDEOS":
                    sListSpecific = (from row in SDPDatabase.LIST_VIDEOS
                                     select row).ToList<LIST_VIDEOS>();
                    break;
                case "SEVA_STHALA_FAQ":
                    sListSpecific = (from row in SDPDatabase.SEVA_STHALA_FAQ
                                     select row).ToList<SEVA_STHALA_FAQ>();
                    break;
                case "SEVA_STHALA_MEDIA":
                    sListSpecific = (from row in SDPDatabase.SEVA_STHALA_MEDIA
                                     select row).ToList<SEVA_STHALA_MEDIA>();
                    break;

                case "SEVA_ANNADANAM_MEDIA":
                    sListSpecific = (from row in SDPDatabase.SEVA_ANNADANAM_MEDIA
                                     select row).ToList<SEVA_ANNADANAM_MEDIA>();
                    break;

                case "LIST_AUDIO":
                    sListSpecific = (from row in SDPDatabase.LIST_AUDIO
                                     select row).ToList<LIST_AUDIO>();
                    break;

            }


            return sListSpecific;
        }

        public static void SendMailSthalaSeva(string StrXml, DonationDetail DonationDetails)
        {
            string FromEmailID = ConfigurationManager.AppSettings["FromMail"].ToString();
            string toEmailID = ConfigurationManager.AppSettings["ToMail"].ToString();
            string smtpServer = ConfigurationManager.AppSettings["SMTPSERVER"].ToString();
            string Message__1 = "<table style='font-family:Calibri;' border='0' cellpadding='0' cellspacing='0' width='30%'>";
            Message__1 += "<tr><td height='5'></td></tr>";
            Message__1 += "<tr><td>";
            Message__1 += "Details of Sponsors: </td></tr>";
            Message__1 += "<tr><td height='10'></td></tr>";
            Message__1 += "<tr><td>";
            Message__1 += " " + StrXml + "</td></tr>";
            Message__1 += "<tr><td height='10'></td></tr>";
            Message__1 += "<tr><td  colspan='3'>Email : " + DonationDetails.Email.Trim() + "</td></tr>";
            Message__1 += "<tr><td colspan='3'>Phone No : " + DonationDetails.PhoneNumber + "</td></tr>";
            Message__1 += "<tr><td></td></tr>";
            Message__1 += "<tr><td colspan='3'>Total amount Transferred : $ " + DonationDetails.TotalAmount + " USD </td></tr>";
            Message__1 += "<tr><td height='5'></td></tr>";
            Message__1 += "<tr><td>";
            Message__1 += "</td></tr>";
            Message__1 += "<tr><td>";
            Message__1 += "<span style='font-style:italic;'></span>";
            Message__1 += "</td></tr></table>";

            SmtpClient smtp = new SmtpClient(smtpServer);
            MailMessage message__2 = new MailMessage();
            message__2.To.Add(toEmailID);
            message__2.From = new MailAddress(FromEmailID);
            message__2.Subject = "Sthala Seva Sponsors details";
            message__2.Body = Message__1;
            message__2.IsBodyHtml = true;
            smtp.Send(message__2);
        }

        public static void SendMailDonation(string StrXml, DonationDetail DonationDetails)
        {
            string FromEmailID = ConfigurationManager.AppSettings["FromMail"].ToString();
            string toEmailID = ConfigurationManager.AppSettings["ToMail"].ToString();
            string smtpServer = ConfigurationManager.AppSettings["SMTPSERVER"].ToString();
            string Message__1 = "<table style='font-family:Calibri;' border='0' cellpadding='0' cellspacing='0' width='30%'>";
            Message__1 += "<tr><td height='10'></td></tr>";
            Message__1 += "<tr><td><b>Donation Type </b></td><td><b>:</b></td><td> " + DonationDetails.DonationID + "</td></tr>";
            //Message__1 += "<tr><td><b>No of Days </b></td><td><b>:</b></td><td> " + txtNoofDays.Text + "</td></tr>";
            Message__1 += "<tr><td><b>Name </b></td><td><b>:</b></td><td> " + DonationDetails.Name + "</td></tr>";
            Message__1 += "<tr><td><b>Nakshatram </b></td><td><b>:</b></td><td> " + DonationDetails.Nakshatram + "</td></tr>";
            Message__1 += "<tr><td><b>Email </b></td><td><b>:</b></td><td> " + DonationDetails.Email + "</td></tr>";
            Message__1 += "<tr><td><b>Phone No </b></td><td><b>:</b></td><td> " + DonationDetails.PhoneNumber + "</td></tr>";
            Message__1 += "<tr><td><b>Gotram </b></td><td><b>:</b></td><td> " + DonationDetails.Gotram + "</td></tr>";
            Message__1 += "<tr><td></td></tr>";
            Message__1 += "<tr><td><b>Total amount</b> </td><td><b>:</b></td><td> $ " + DonationDetails.TotalAmount + " USD </td></tr>";
            Message__1 += "</table>";
            Message__1 += "<table style='font-family:Calibri;' border='0' cellpadding='0' cellspacing='0' width='30%'>";
            Message__1 += "<tr><td height='5'></td></tr>";
            Message__1 += "<tr><td height='10'></td></tr>";
            Message__1 += "<tr><td><b>Details of Family Members:</b> </td></tr>";
            Message__1 += "<tr><td height='5'></td></tr>";
            Message__1 += "<tr><td>";
            Message__1 += " " + StrXml + "</td></tr>";
            Message__1 += "<tr><td>";
            Message__1 += "</td></tr>";
            Message__1 += "<tr><td>";
            Message__1 += "<span style='font-style:italic;'></span>";
            Message__1 += "</td></tr></table>";

            SmtpClient smtp = new SmtpClient(smtpServer);
            MailMessage message__2 = new MailMessage();
            message__2.To.Add(toEmailID);
            message__2.To.Add(DonationDetails.Email);
            message__2.From = new MailAddress(FromEmailID);
            message__2.Subject = "Donation Sponsors details";
            message__2.Body = Message__1;
            message__2.IsBodyHtml = true;
            //smtp.Send(message__2);
        }

    }

}