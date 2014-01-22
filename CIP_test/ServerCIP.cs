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
        [DllImport("WININET", EntryPoint = "InternetOpen",
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
            LastUpdate = this.TestXMLFileDate(PoveskaFileLocalName);
            XML Axml = new XML();
            URL = Axml.GetURL_serversetup();
            login = Axml.GetLogin_serversetup();
            password = Axml.GetPassword_serversetup();

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

        public void Set(string log, string pas, string url_)
        {
            URL = url_;
            login = log;
            password = pas;
            this.SaveSetup();
        }

        public String GetURL()
        {
            this.LoadSetup();
            return URL;
        }
        public String GetLogin()
        {
            this.LoadSetup();
            return login;
        }
        public String GetPassword()
        {
            this.LoadSetup();
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
            DateTime TestFileData = new DateTime(2014,1,21);
            // узнавание времени последнего редактирования файла
            
            return TestFileData;
        }
        private void LoadFileURL(string filename, string localfilename)
        {
            //загрузка файла 
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
        }

        void UpdatePovestkaXML()
        {
            if (this.TestInternet())
            {
                string urlFilename;
                urlFilename = URL;
                urlFilename += PoveskaFileServerName;
                if (LastUpdate.CompareTo(this.TestXMLFileDate(urlFilename)) < 0)
                {
                    this.LoadFileURL(PoveskaFileServerName, PoveskaFileLocalName);
                    XML Bxml = new XML();
                    Povestka TempPovestka = new Povestka();
                    TempPovestka.LoadAtFile(PoveskaFileServerName);
                    List<string> AllMaterials = new List<string>(TempPovestka.GetAllMaterials());
                    //Скачивание материалов повестки
                    for (int i = 0; i < AllMaterials.Count; i++)
                    {
                        this.LoadFileURL(AllMaterials.ElementAt(i), AllMaterials.ElementAt(i));
                    }

                    //Преобразование повестки в сохраняемую

                    TempPovestka.SaveToFile(PoveskaFileLocalName);
                }
            }
        }
                
    } 
}
