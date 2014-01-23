using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.InteropServices;

namespace CIP_test
{
    public class ServerCIP
    {
        private String URL;
        private String login;
        private String password;
        private String PoveskaFileServerName;
        private String PoveskaFileLocalName;
        private String ServerSetupFileName;
        private DateTime LastUpdate;
        public Boolean internetConnection;
        public Boolean updateStatus;

        public ServerCIP()
        {
            internetConnection = false;
            updateStatus = false;
            PoveskaFileServerName = "povestka.xml";
            PoveskaFileLocalName = "actual.xml";
            ServerSetupFileName = "serversetup.xml";
            LastUpdate = File.GetLastWriteTime(PoveskaFileServerName);
            LoadSetup();
        }
        ~ServerCIP()
        {

        }
        private void SaveSetup()
        {
            XML Axml = new XML();
            Axml.SaveLoginPasswordURL_serversetup(ServerSetupFileName, login, password, URL);
        }

        private void LoadSetup()
        {
            XML Axml = new XML();
            URL = Axml.GetURL_serversetup(ServerSetupFileName);
            login = Axml.GetLogin_serversetup(ServerSetupFileName);
            password = Axml.GetPassword_serversetup(ServerSetupFileName);
        }

        public void SetLoginPasswordURL(string log, string pas, string url_)
        {
            URL = url_;
            login = log;
            password = pas;
            this.SaveSetup();
        }

        public String GetURL()
        {
            return URL;
        }
        public String GetLogin()
        {
            return login;
        }
        public String GetPassword()
        {
            return password;
        }


        private bool TestInternet()
        {
            IPStatus status = IPStatus.Unknown;
            try
            {
                status = new Ping().Send("ya.ru").Status;
            }
            catch { }

            if (status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DateTime TestXMLFileDate(string locationfilename)
        {
            DateTime TestFileData;
            try
            {
                // узнавание времени последнего редактирования файла на сервере
                //Create FTP request & login to server 
                FtpWebRequest request = FtpWebRequest.Create(URL + "/CIP/" + locationfilename) as FtpWebRequest;
                request.Credentials = new NetworkCredential(login, password);

                //Get the DATE & TIME stamp of the file 
                request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                TestFileData = response.LastModified;
                
            }
            catch
            { 
                TestFileData = new DateTime(1985, 4, 2);
            }
            return TestFileData;
        }
        private void LoadFileURL(List<string> ListFile)
        {
            //загрузка файлов материалов
            for (int i = 0; i < ListFile.Count; i++)
            {
                string filename = ListFile.ElementAt(i);
                bool status = true;
                string webError = string.Empty;
                FtpWebResponse response = null;
                Stream ftpStream = null;
                FileStream outputStream = null;
                //FtpDownloadToFolder = @"\\servername\SharedFolder\";

                FtpWebRequest reqFTP = WebRequest.Create(new Uri(URL + "/CIP/" + filename)) as FtpWebRequest;
                reqFTP.Credentials = new NetworkCredential(login, password);
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                //reqFTP.Timeout = FtpTimeout;
                response = reqFTP.GetResponse() as FtpWebResponse;
                ftpStream = response.GetResponseStream();

                outputStream = new FileStream(filename, FileMode.Create);

                long cl = response.ContentLength;
                int bufferSize = 2048;
                byte[] buffer = new byte[bufferSize];
                int readCount = ftpStream.Read(buffer, 0, bufferSize);

                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
            }
        }
        private void LoadFileURL(string filename)
        {
            //загрузка файла повестки
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL + "/CIP/" + filename);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(login, password);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                File.WriteAllText(filename, reader.ReadToEnd(), Encoding.UTF32);

                //Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

                reader.Close();
                response.Close();
                LastUpdate = File.GetLastWriteTime(PoveskaFileServerName);
                
            }
            catch { updateStatus = false; }
            
        }

        public void UpdatePovestkaXML()
        {
            //if (TestInternet())  //у меня на работе пинг перестал проходить через файервол, отключил на время
            {
                internetConnection = true;
                if (LastUpdate.CompareTo(TestXMLFileDate(PoveskaFileServerName)) < 0)
                {
                    updateStatus = false;
                    LoadFileURL(PoveskaFileServerName);
                    XML Bxml = new XML();
                    Povestka TempPovestka = new Povestka();
                    TempPovestka.LoadAtFile(PoveskaFileServerName);
                    List<string> AllMaterials = new List<string>(TempPovestka.GetAllMaterials());
                    //Скачивание материалов повестки
                    LoadFileURL(AllMaterials);

                    //Преобразование повестки в сохраняемую

                    TempPovestka.SaveToFile(PoveskaFileLocalName);
                    
                }
                else { updateStatus = true; }
            }
           /* else
            {
                internetConnection = false;
            }*/
        }
                
    } 
}
