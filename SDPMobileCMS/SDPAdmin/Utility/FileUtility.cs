using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace SDPAdmin
{
    public static class FileUtility
    {

        public static string SaveFile(FileUpload sFileUpload, string sFilePath, string sFolder)
        {
            if (sFileUpload.HasFile)
            {
                try
                {
                    string sFileName = Path.GetFileName(sFileUpload.FileName);
                    sFileUpload.SaveAs(sFilePath + sFileName);
                    sFilePath = sFolder + sFileName;
                }
                catch (Exception sException)
                {
                    sFilePath = sException.Message;
                }
            }

            return sFilePath;
        }


        public static string SaveFile1(FileUpload FileUpload1, string sFilePath, string sFolder)
        {
            //FTP Server URL.
            string ftp = "ftp://saidattanj.org/";

            //FTP Folder name. Leave blank if you want to upload to root folder.
            string ftpFolder = "SDPAdmin/appData/EVENTS/";

            byte[] fileBytes = null;

            //Read the FileName and convert it to Byte array.
            string fileName = Path.GetFileName(FileUpload1.FileName);
            using (StreamReader fileStream = new StreamReader(FileUpload1.PostedFile.InputStream))
            {
                fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
                fileStream.Close();
            }


             sFilePath = "~/" + ftpFolder + fileName;
            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("saidattanjorg", "SDf#73@4eK");
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }

            return sFilePath;
        }

    }
}