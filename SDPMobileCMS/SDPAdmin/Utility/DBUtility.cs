using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace SDPAdmin
{
    public class DBUtility
    {

        SqlConnection sConnection;
        SqlCommand sCommand;

        public DBUtility()
        {
            this.sConnection = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["SaiDatta"]));
            this.sCommand = new SqlCommand();
            this.sCommand.Connection = this.sConnection;
        }


        public bool InsertEvent(EVENT_BANNER Event, string sTableName)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                if (sTableName.Equals("EVENT_BANNER"))
                {
                    sCommand.CommandText = "INSERT INTO " + sTableName + " VALUES(@EVENT_NAME,@EVENT_DATETIME,@EVENT_INFO,@EVENT_ATTACHMENT,@EVENT_TARGET_TYPE,@EVENT_TARGET,@DATETIME)";

                    sCommand.Parameters.AddWithValue("@EVENT_DATETIME", Event.EVENT_DATETIME);
                    sCommand.Parameters.AddWithValue("@EVENT_INFO", Event.EVENT_INFO);
                    sCommand.Parameters.AddWithValue("@EVENT_TARGET_TYPE", Event.EVENT_TARGET_TYPE);
                    sCommand.Parameters.AddWithValue("@EVENT_TARGET", Event.EVENT_TARGET);
                }
                else if (sTableName.Equals("EVENT_CALENDAR"))
                {
                    sCommand.CommandText = "INSERT INTO " + sTableName + " VALUES(@EVENT_NAME,@EVENT_ATTACHMENT,@EVENT_TARGET,@DATETIME)";
                    sCommand.Parameters.AddWithValue("@EVENT_TARGET", Event.EVENT_TARGET);

                }
                else
                {
                    sCommand.CommandText = "INSERT INTO " + sTableName + " VALUES(@EVENT_NAME,@EVENT_DATETIME,@EVENT_INFO,@EVENT_ATTACHMENT,@DATETIME)";
                    sCommand.Parameters.AddWithValue("@EVENT_DATETIME", Event.EVENT_DATETIME);
                    sCommand.Parameters.AddWithValue("@EVENT_INFO", Event.EVENT_INFO);
                }

                sCommand.Parameters.AddWithValue("@EVENT_NAME", Event.EVENT_NAME);
                sCommand.Parameters.AddWithValue("@EVENT_ATTACHMENT", Event.EVENT_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;

        }

        public bool UpdateEvent(EVENT_BANNER Event, string sTableName)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();


                if (sTableName.Equals("EVENT_BANNER"))
                {
                    sCommand.CommandText = "UPDATE " + sTableName + " SET EVENT_NAME=@EVENT_NAME,EVENT_DATETIME=@EVENT_DATETIME," +
                                           "EVENT_INFO=@EVENT_INFO,EVENT_ATTACHMENT=@EVENT_ATTACHMENT," +
                                           "EVENT_TARGET_TYPE=@EVENT_TARGET_TYPE,EVENT_TARGET=@EVENT_TARGET " +
                                           "WHERE ID=@ID";

                    sCommand.Parameters.AddWithValue("@EVENT_DATETIME", Event.EVENT_DATETIME);
                    sCommand.Parameters.AddWithValue("@EVENT_INFO", Event.EVENT_INFO);
                    sCommand.Parameters.AddWithValue("@EVENT_TARGET_TYPE", Event.EVENT_TARGET_TYPE);
                    sCommand.Parameters.AddWithValue("@EVENT_TARGET", Event.EVENT_TARGET);
                }
                else if (sTableName.Equals("EVENT_CALENDAR"))
                {
                    sCommand.CommandText = "UPDATE " + sTableName + " SET EVENT_NAME=@EVENT_NAME," +
                                          "EVENT_ATTACHMENT=@EVENT_ATTACHMENT, EVENT_TARGET=@EVENT_TARGET " +
                                          "WHERE ID=@ID";

                    sCommand.Parameters.AddWithValue("@EVENT_TARGET", Event.EVENT_TARGET);

                }
                else
                {
                    sCommand.CommandText = "UPDATE " + sTableName + " SET EVENT_NAME=@EVENT_NAME,EVENT_DATETIME=@EVENT_DATETIME," +
                                          "EVENT_INFO=@EVENT_INFO,EVENT_ATTACHMENT=@EVENT_ATTACHMENT " +
                                          "WHERE ID=@ID";

                    sCommand.Parameters.AddWithValue("@EVENT_DATETIME", Event.EVENT_DATETIME);
                    sCommand.Parameters.AddWithValue("@EVENT_INFO", Event.EVENT_INFO);
                }

                sCommand.Parameters.AddWithValue("@ID", Event.ID);
                sCommand.Parameters.AddWithValue("@EVENT_NAME", Event.EVENT_NAME);
                sCommand.Parameters.AddWithValue("@EVENT_ATTACHMENT", Event.EVENT_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public bool DeleteEvent(string sID, string sTableName)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "DELETE FROM " + sTableName + " WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public EVENT_BANNER GetEvent(string sID, string sTableName)
        {

            EVENT_BANNER Event = new EVENT_BANNER();

            try
            {

                sConnection.Open();

                sCommand.CommandText = "SELECT * FROM " + sTableName + " WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                SqlDataReader sReader = sCommand.ExecuteReader();

                while (sReader.Read())
                {
                    Event.ID = Convert.ToInt32(sReader["ID"]);
                    Event.EVENT_NAME = Convert.ToString(sReader["EVENT_NAME"]);
                    Event.EVENT_ATTACHMENT = Convert.ToString(sReader["EVENT_ATTACHMENT"]);

                    if (!sTableName.ToUpper().Equals("EVENT_CALENDAR"))
                    {
                        Event.EVENT_DATETIME = Convert.ToString(sReader["EVENT_DATETIME"]);
                        Event.EVENT_INFO = Convert.ToString(sReader["EVENT_INFO"]);
                    }

                    if (sTableName.ToUpper().Equals("EVENT_CALENDAR"))
                    {
                        Event.EVENT_TARGET = Convert.ToString(sReader["EVENT_TARGET"]);
                    }

                    if (sTableName.ToUpper().Equals("EVENT_BANNER"))
                    {
                        Event.EVENT_TARGET = Convert.ToString(sReader["EVENT_TARGET"]);
                        Event.EVENT_TARGET_TYPE = Convert.ToString(sReader["EVENT_TARGET_TYPE"]);
                    }
                }

                sConnection.Close();

            }
            catch (Exception sException)
            {

            }
            finally
            {
                sConnection.Close();
            }

            return Event;
        }

        public bool InsertImage(LIST_IMAGES Image)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "INSERT INTO LIST_IMAGES VALUES(@IMAGE_HEADER,@IMAGE_TITLE,@IMAGE_ATTACHMENT,@IMAGE_TARGET,@DATETIME)";

                sCommand.Parameters.AddWithValue("@IMAGE_HEADER", Image.IMAGE_HEADER.ToUpper());
                sCommand.Parameters.AddWithValue("@IMAGE_TITLE", Image.IMAGE_TITLE);
                sCommand.Parameters.AddWithValue("@IMAGE_ATTACHMENT", Image.IMAGE_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@IMAGE_TARGET", Image.IMAGE_TARGET);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;

        }

        public bool UpdateImage(LIST_IMAGES Image)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "UPDATE LIST_IMAGES SET IMAGE_HEADER=@IMAGE_HEADER," +
                                       "IMAGE_TITLE=@IMAGE_TITLE,IMAGE_ATTACHMENT=@IMAGE_ATTACHMENT,IMAGE_TARGET=@IMAGE_TARGET,DATETIME=@DATETIME " +
                                       "WHERE ID=@ID";

                sCommand.Parameters.AddWithValue("@ID", Image.ID);
                sCommand.Parameters.AddWithValue("@IMAGE_HEADER", Image.IMAGE_HEADER.ToUpper());
                sCommand.Parameters.AddWithValue("@IMAGE_TITLE", Image.IMAGE_TITLE);
                sCommand.Parameters.AddWithValue("@IMAGE_ATTACHMENT", Image.IMAGE_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@IMAGE_TARGET", Image.IMAGE_TARGET);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public bool DeleteImage(string sID)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "DELETE FROM LIST_IMAGES WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public LIST_IMAGES GetImage(string sID)
        {

            LIST_IMAGES Image = new LIST_IMAGES();

            try
            {

                sConnection.Open();

                sCommand.CommandText = "SELECT * FROM LIST_IMAGES WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                SqlDataReader sReader = sCommand.ExecuteReader();

                while (sReader.Read())
                {
                    Image.ID = Convert.ToInt32(sReader["ID"]);
                    Image.IMAGE_HEADER = Convert.ToString(sReader["IMAGE_HEADER"]);
                    Image.IMAGE_TITLE = Convert.ToString(sReader["IMAGE_TITLE"]);
                    Image.IMAGE_TARGET = Convert.ToString(sReader["IMAGE_TARGET"]);
                    Image.IMAGE_ATTACHMENT = Convert.ToString(sReader["IMAGE_ATTACHMENT"]);
                    Image.DATETIME = Convert.ToString(sReader["DATETIME"]);
                }

                sConnection.Close();

            }
            catch (Exception sException)
            {

            }
            finally
            {
                sConnection.Close();
            }

            return Image;
        }

        public bool InsertVideo(LIST_VIDEOS Video)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "INSERT INTO LIST_VIDEOS VALUES(@VIDEO_HEADER,@VIDEO_TITLE,@VIDEO_URL,@DATETIME)";

                sCommand.Parameters.AddWithValue("@VIDEO_HEADER", Video.VIDEO_HEADER.ToUpper());
                sCommand.Parameters.AddWithValue("@VIDEO_TITLE", Video.VIDEO_TITLE);
                sCommand.Parameters.AddWithValue("@VIDEO_URL", Video.VIDEO_URL);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;

        }

        public bool UpdateVideo(LIST_VIDEOS Video)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "UPDATE LIST_VIDEOS SET VIDEO_HEADER=@VIDEO_HEADER," +
                                       "VIDEO_TITLE=@VIDEO_TITLE,VIDEO_URL=@VIDEO_URL,DATETIME=@DATETIME " +
                                       "WHERE ID=@ID";

                sCommand.Parameters.AddWithValue("@ID", Video.ID);
                sCommand.Parameters.AddWithValue("@VIDEO_HEADER", Video.VIDEO_HEADER.ToUpper());
                sCommand.Parameters.AddWithValue("@VIDEO_TITLE", Video.VIDEO_TITLE);
                sCommand.Parameters.AddWithValue("@VIDEO_URL", Video.VIDEO_URL);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public bool DeleteVideo(string sID)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "DELETE FROM LIST_VIDEOS WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public LIST_VIDEOS GetVideo(string sID)
        {

            LIST_VIDEOS Video = new LIST_VIDEOS();

            try
            {

                sConnection.Open();

                sCommand.CommandText = "SELECT * FROM LIST_VIDEOS WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                SqlDataReader sReader = sCommand.ExecuteReader();

                while (sReader.Read())
                {
                    Video.ID = Convert.ToInt32(sReader["ID"]);
                    Video.VIDEO_HEADER = Convert.ToString(sReader["VIDEO_HEADER"]);
                    Video.VIDEO_TITLE = Convert.ToString(sReader["VIDEO_TITLE"]);
                    Video.VIDEO_URL = Convert.ToString(sReader["VIDEO_URL"]);
                    Video.DATETIME = Convert.ToString(sReader["DATETIME"]);
                }

                sConnection.Close();

            }
            catch (Exception sException)
            {

            }
            finally
            {
                sConnection.Close();
            }

            return Video;
        }


        public bool InsertQuote(LIST_QUOTES Quote)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "INSERT INTO LIST_QUOTES VALUES(@QUOTE,@DATETIME)";

                sCommand.Parameters.AddWithValue("@QUOTE", Quote.QUOTE);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;

        }

        public bool UpdateQuote(LIST_QUOTES Quote)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "UPDATE LIST_QUOTES SET QUOTE=@QUOTE," +
                                       "DATETIME=@DATETIME " +
                                       "WHERE ID=@ID";

                sCommand.Parameters.AddWithValue("@ID", Quote.ID);
                sCommand.Parameters.AddWithValue("@QUOTE", Quote.QUOTE);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public bool DeleteQuote(string sID)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "DELETE FROM LIST_QUOTES WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public LIST_QUOTES GetQuote(string sID)
        {

            LIST_QUOTES Quote = new LIST_QUOTES();

            try
            {

                sConnection.Open();

                sCommand.CommandText = "SELECT * FROM LIST_QUOTES WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                SqlDataReader sReader = sCommand.ExecuteReader();

                while (sReader.Read())
                {
                    Quote.ID = Convert.ToInt32(sReader["ID"]);
                    Quote.QUOTE = Convert.ToString(sReader["QUOTE"]);
                    Quote.DATETIME = Convert.ToString(sReader["DATETIME"]);
                }

                sConnection.Close();

            }
            catch (Exception sException)
            {

            }
            finally
            {
                sConnection.Close();
            }

            return Quote;
        }

        public bool InsertFAQ(SEVA_STHALA_FAQ SEVA_STHALA_FAQ)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "INSERT INTO SEVA_STHALA_FAQ VALUES(@QUESTION,@ANSWER,@DATETIME)";

                sCommand.Parameters.AddWithValue("@QUESTION", SEVA_STHALA_FAQ.QUESTION);
                sCommand.Parameters.AddWithValue("@ANSWER", SEVA_STHALA_FAQ.ANSWER);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;

        }

        public bool UpdateFAQ(SEVA_STHALA_FAQ SEVA_STHALA_FAQ)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "UPDATE SEVA_STHALA_FAQ SET " +
                                       "QUESTION=@QUESTION,ANSWER=@ANSWER," +
                                       "DATETIME=@DATETIME " +
                                       "WHERE ID=@ID";

                sCommand.Parameters.AddWithValue("@ID", SEVA_STHALA_FAQ.ID);
                sCommand.Parameters.AddWithValue("@QUESTION", SEVA_STHALA_FAQ.QUESTION);
                sCommand.Parameters.AddWithValue("@ANSWER", SEVA_STHALA_FAQ.ANSWER);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public bool DeleteFAQ(string sID)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "DELETE FROM SEVA_STHALA_FAQ WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public SEVA_STHALA_FAQ GetFAQ(string sID)
        {

            SEVA_STHALA_FAQ SEVA_STHALA_FAQ = new SEVA_STHALA_FAQ();

            try
            {

                sConnection.Open();

                sCommand.CommandText = "SELECT * FROM SEVA_STHALA_FAQ WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                SqlDataReader sReader = sCommand.ExecuteReader();

                while (sReader.Read())
                {
                    SEVA_STHALA_FAQ.ID = Convert.ToInt32(sReader["ID"]);
                    SEVA_STHALA_FAQ.QUESTION = Convert.ToString(sReader["QUESTION"]);
                    SEVA_STHALA_FAQ.ANSWER = Convert.ToString(sReader["ANSWER"]);
                }

                sConnection.Close();

            }
            catch (Exception sException)
            {

            }
            finally
            {
                sConnection.Close();
            }

            return SEVA_STHALA_FAQ;
        }


        public DataTable GetDeviceIDs(string sRole)
        {

            DataTable DeviceIDDataTable = new DataTable();

            sConnection.Open();

            sCommand.CommandText = "SELECT DEVICE_ID,DEVICE_TYPE FROM NOTIFICATION_DEVICES WHERE UPPER(ROLE) LIKE '%" + sRole.ToUpper() + "%'";

            SqlDataAdapter sAdapter = new SqlDataAdapter(sCommand.CommandText, sConnection);
            sAdapter.Fill(DeviceIDDataTable);

            sConnection.Close();

            return DeviceIDDataTable;

        }

        public bool InsertMedia(SEVA_STHALA_MEDIA Media, string sTable)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "INSERT INTO " + sTable + " VALUES(@MEDIA_HEADER,@MEDIA_TITLE,@MEDIA_TYPE,@MEDIA_ATTACHMENT,@DATETIME)";

                sCommand.Parameters.AddWithValue("@MEDIA_HEADER", Media.MEDIA_HEADER);
                sCommand.Parameters.AddWithValue("@MEDIA_TITLE", Media.MEDIA_TITLE);
                sCommand.Parameters.AddWithValue("@MEDIA_TYPE", Media.MEDIA_TYPE);
                sCommand.Parameters.AddWithValue("@MEDIA_ATTACHMENT", Media.MEDIA_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;

        }

        public bool UpdateMedia(SEVA_STHALA_MEDIA Media, string sTable)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "UPDATE " + sTable + " SET MEDIA_HEADER=@MEDIA_HEADER," +
                                       "MEDIA_TITLE=@MEDIA_TITLE,MEDIA_TYPE=@MEDIA_TYPE,MEDIA_ATTACHMENT=@MEDIA_ATTACHMENT,DATETIME=@DATETIME " +
                                       "WHERE ID=@ID";

                sCommand.Parameters.AddWithValue("@ID", Media.ID);
                sCommand.Parameters.AddWithValue("@MEDIA_HEADER", Media.MEDIA_HEADER);
                sCommand.Parameters.AddWithValue("@MEDIA_TITLE", Media.MEDIA_TITLE);
                sCommand.Parameters.AddWithValue("@MEDIA_TYPE", Media.MEDIA_TYPE);
                sCommand.Parameters.AddWithValue("@MEDIA_ATTACHMENT", Media.MEDIA_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public bool DeleteMedia(string sID, string sTable)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "DELETE FROM " + sTable + " WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public SEVA_STHALA_MEDIA GetMedia(string sID, string sTable)
        {

            SEVA_STHALA_MEDIA Media = new SEVA_STHALA_MEDIA();

            try
            {

                sConnection.Open();

                sCommand.CommandText = "SELECT * FROM " + sTable + " WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                SqlDataReader sReader = sCommand.ExecuteReader();

                while (sReader.Read())
                {
                    Media.ID = Convert.ToInt32(sReader["ID"]);
                    Media.MEDIA_HEADER = Convert.ToString(sReader["MEDIA_HEADER"]);
                    Media.MEDIA_TITLE = Convert.ToString(sReader["MEDIA_TITLE"]);
                    Media.MEDIA_TYPE = Convert.ToString(sReader["MEDIA_TYPE"]);
                    Media.MEDIA_ATTACHMENT = Convert.ToString(sReader["MEDIA_ATTACHMENT"]);
                    Media.DATETIME = Convert.ToString(sReader["DATETIME"]);
                }

                sConnection.Close();

            }
            catch (Exception sException)
            {

            }
            finally
            {
                sConnection.Close();
            }

            return Media;
        }

        public bool InsertAudio(LIST_AUDIO Audio)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "INSERT INTO LIST_AUDIO VALUES(@AUDIO_TITLE,@AUDIO_ATTACHMENT,@DATETIME)";

                sCommand.Parameters.AddWithValue("@AUDIO_TITLE", Audio.AUDIO_TITLE);
                sCommand.Parameters.AddWithValue("@AUDIO_ATTACHMENT", Audio.AUDIO_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;

        }

        public bool UpdateAudio(LIST_AUDIO Audio)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "UPDATE LIST_AUDIO SET " +
                                       "AUDIO_TITLE=@AUDIO_TITLE,AUDIO_ATTACHMENT=@AUDIO_ATTACHMENT,DATETIME=@DATETIME " +
                                       "WHERE ID=@ID";

                sCommand.Parameters.AddWithValue("@ID", Audio.ID);
                sCommand.Parameters.AddWithValue("@AUDIO_TITLE", Audio.AUDIO_TITLE);
                sCommand.Parameters.AddWithValue("@AUDIO_ATTACHMENT", Audio.AUDIO_ATTACHMENT);
                sCommand.Parameters.AddWithValue("@DATETIME", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public bool DeleteAudio(string sID)
        {
            bool sTransaction = false;

            try
            {
                sTransaction = true;

                sConnection.Open();

                sCommand.CommandText = "DELETE FROM LIST_AUDIO WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                sCommand.ExecuteNonQuery();

                sConnection.Close();

            }
            catch (Exception sException)
            {
                sTransaction = false;
            }
            finally
            {
                sConnection.Close();
            }

            return sTransaction;
        }

        public LIST_AUDIO GetAudio(string sID)
        {

            LIST_AUDIO Audio = new LIST_AUDIO();

            try
            {

                sConnection.Open();

                sCommand.CommandText = "SELECT * FROM LIST_AUDIO WHERE ID=@ID";
                sCommand.Parameters.AddWithValue("@ID", sID);

                SqlDataReader sReader = sCommand.ExecuteReader();

                while (sReader.Read())
                {
                    Audio.ID = Convert.ToInt32(sReader["ID"]);
                    Audio.AUDIO_TITLE = Convert.ToString(sReader["AUDIO_TITLE"]);
                    Audio.AUDIO_ATTACHMENT = Convert.ToString(sReader["AUDIO_ATTACHMENT"]);
                    Audio.DATETIME = Convert.ToString(sReader["DATETIME"]);
                }

                sConnection.Close();

            }
            catch (Exception sException)
            {

            }
            finally
            {
                sConnection.Close();
            }

            return Audio;
        }

    }
}