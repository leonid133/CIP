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
       /* [DllImport("WININET", EntryPoint = "InternetOpen",
        SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr __InternetOpen(
            string lpszAgent,
            int dwAccessType,
            string lpszProxyName,
            string lpszProxyBypass,
            int dwFlags);

        [DllImport("WININET", EntryPoint = "InternetCloseHandle",
            SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool __InternetCloseHandle(IntPtr hInternet);

        [DllImport("WININET", EntryPoint = "InternetConnect",
            SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr __InternetConnect(
            IntPtr hInternet,
            string lpszServerName,
            int nServerPort,
            string lpszUsername,
            string lpszPassword,
            int dwService,
            int dwFlags,
            int dwContext);

        [DllImport("WININET", EntryPoint = "FtpSetCurrentDirectory",
            SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool __FtpSetCurrentDirectory(
            IntPtr hConnect,
            string lpszDirectory);

        [DllImport("WININET", EntryPoint = "InternetAttemptConnect",
            SetLastError = true, CharSet = CharSet.Auto)]
        static extern int __InternetAttemptConnect(int dwReserved);

        [DllImport("WININET", EntryPoint = "FtpGetFile",
            SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool __FtpGetFile(
            IntPtr hConnect,
            string lpszRemoteFile,
            string lpszNewFile,
            bool fFailIfExists,
            FileAttributes dwFlagsAndAttributes,
            int dwFlags,
            int dwContext);

        const int ERROR_SUCCESS = 0;
        const int INTERNET_OPEN_TYPE_DIRECT = 1;
        const int INTERNET_SERVICE_FTP = 1;
        */
        private String URL;
        private String login;
        private String password;
        private String PoveskaFileServerName;
        private String PoveskaFileLocalName;
        private DateTime LastUpdate;

        public ServerCIP()
        {
            PoveskaFileServerName = "povestka.xml";
            PoveskaFileLocalName = "actual.xml";
            LastUpdate = File.GetLastWriteTime(PoveskaFileLocalName);
            LoadSetup();
        }
        ~ServerCIP()
        {

        }
        private void SaveSetup()
        {
            XML Axml = new XML();
            Axml.SaveLoginPasswordURL_serversetup(login, password, URL);
        }

        private void LoadSetup()
        {
            XML Axml = new XML();
            URL = Axml.GetURL_serversetup();
            login = Axml.GetLogin_serversetup();
            password = Axml.GetPassword_serversetup();
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
        private void LoadFileURL(string filename)
        {
            //загрузка файла 
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL + "/CIP/" + filename);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(login, password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            File.WriteAllText(filename, reader.ReadToEnd());

            //Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close(); 
            /*
            //Create FTP request & login to server 
            FtpWebRequest request = FtpWebRequest.Create(URL + "/CIP/" + filename) as FtpWebRequest;
            request.Credentials = new NetworkCredential(login, password);

            //download file
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close(); 
             */
            /*
            IntPtr inetHandle = IntPtr.Zero;
            IntPtr ftpconnectHandle = IntPtr.Zero;

            try
            {
                //check for inet connection
                if (__InternetAttemptConnect(0) != ERROR_SUCCESS)
                {
                    throw new InvalidOperationException(
                        "no connection to internet available");
                }

                //connect to inet
                inetHandle = __InternetOpen(
                    "billyboy FTP", INTERNET_OPEN_TYPE_DIRECT, null, null, 0);
                if (inetHandle == IntPtr.Zero)
                {
                    throw new NullReferenceException(
                        "couldn't establish a connection to the internet");
                }

                //connect to ftp
                ftpconnectHandle = __InternetConnect(
                    inetHandle, URL, 21, login,
                    password, INTERNET_SERVICE_FTP,
                    0, 0);
                if (ftpconnectHandle == IntPtr.Zero)
                {
                    throw new NullReferenceException(
                        "couldn't connect");
                }

                //set to desired directory on FTP server
                if (!__FtpSetCurrentDirectory(ftpconnectHandle, "/CIP"))
                {
                    throw new InvalidOperationException(
                        "couldn't set to desired directory");
                }

                //download file from server
                if (!__FtpGetFile(ftpconnectHandle, filename,
                                   localfilename, false, 0, 0, 0))
                {
                    throw new IOException("couldn't download file");
                }

                //success
                Console.WriteLine("SUCCESS: file downloaded successfully");
            }
            catch (Exception ex)
            {
                //print error message
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                //close connection to ftp
                if (ftpconnectHandle != IntPtr.Zero)
                {
                    __InternetCloseHandle(ftpconnectHandle);
                }
                ftpconnectHandle = IntPtr.Zero;

                //close connection to inet
                if (inetHandle != IntPtr.Zero)
                {
                    __InternetCloseHandle(inetHandle);
                }
                inetHandle = IntPtr.Zero;
            }

            Console.ReadLine();
            */
        }

        public void UpdatePovestkaXML()
        {
            if (TestInternet())
            {
                if (LastUpdate.CompareTo(TestXMLFileDate(PoveskaFileServerName)) < 0)
                {
                    LoadFileURL(PoveskaFileServerName);
                    XML Bxml = new XML();
                    Povestka TempPovestka = new Povestka();
                    TempPovestka.LoadAtFile(PoveskaFileServerName);
                    List<string> AllMaterials = new List<string>(TempPovestka.GetAllMaterials());
                    //Скачивание материалов повестки
                    for (int i = 0; i < AllMaterials.Count; i++)
                    {
                        LoadFileURL(AllMaterials.ElementAt(i));
                    }

                    //Преобразование повестки в сохраняемую

                    TempPovestka.SaveToFile(PoveskaFileLocalName);
                }
            }
        }
                
    } 
}
