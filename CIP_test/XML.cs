using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace CIP_test
{
    public class XML
    {
        private XmlDocument xmlDoc;
        private String Login, Password, URL;
        private String ServerSetupFileName;
        private String LocalPovestkaFileName;

        public XML()
        {
            xmlDoc = new XmlDocument();
            ServerSetupFileName = "serversetup.xml";
            LocalPovestkaFileName = "actual.xml";
        }
        ~XML()
        {

        }

        private void CreateXMLDocumentServerSetup(string filepath)
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("user");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        private void WriteToXMLDocumentServerSetup(string filepath, string name, string pwd, string urll)
        {
            if (!File.Exists(filepath))
            {
                this.CreateXMLDocumentServerSetup(filepath);
            }
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            // Создаем новую запись USER c аттрибутом id  
            XmlElement user = xd.CreateElement("user");
            user.SetAttribute("id", "1");

            // Создаем 3 поля логин, пароль, адрес
            XmlElement login = xd.CreateElement("login");
            XmlElement pass = xd.CreateElement("password");
            XmlElement url_ = xd.CreateElement("URL");

            // Создаем 3 записи логин, пароль, адрес
            XmlText tLogin = xd.CreateTextNode(name);
            XmlText tPassword = xd.CreateTextNode(pwd);
            XmlText tURL = xd.CreateTextNode(urll);

            login.AppendChild(tLogin); // Забиваем значение логина в поле LOGIN  
            pass.AppendChild(tPassword); // Забиваем значение пароля в поле PASSWORD  
            url_.AppendChild(tURL);

            // Забиваем поля LOGIN и PASSWORD в запись USER  
            user.AppendChild(login);
            user.AppendChild(pass);
            user.AppendChild(url_);

            // ЗАбиваем запись в документ  
            xd.DocumentElement.AppendChild(user);

            fs.Close();         // Закрываем поток  
            xd.Save(filepath); // Сохраняем файл  
        }
        private void ReadXMLDocumentServerSetup(string filepath, string pid)
        {
            if (File.Exists(filepath))
            {
                string name, pwd, url_; // Новые переменные имени и пароля  

                // Объявляем и забиваем файл в документ  
                XmlDocument xd = new XmlDocument();
                FileStream fs = new FileStream(filepath, FileMode.Open);
                xd.Load(fs);

                XmlNodeList list = xd.GetElementsByTagName("user"); // Создаем и заполняем лист по тегу "user"  
                for (int i = 0; i < list.Count; i++)
                {
                    XmlElement id = (XmlElement)xd.GetElementsByTagName("user")[i];         // Забиваем id в переменную  
                    XmlElement user = (XmlElement)xd.GetElementsByTagName("login")[i];      // Забиваем login в переменную  
                    XmlElement pass = (XmlElement)xd.GetElementsByTagName("password")[i];   // Забиваем password в переменную  
                    XmlElement urll = (XmlElement)xd.GetElementsByTagName("URL")[i];

                    if (id.GetAttribute("id") == pid) // Если наткнулся на нужный айдишник  
                    {
                        // Вставляем в переменные текст из тегов  
                        name = user.InnerText;
                        pwd = pass.InnerText;
                        url_ = urll.InnerText;

                        // Заполняем поля   
                        Login = name;
                        Password = pwd;
                        URL = url_;
                        break;
                    }
                    else
                    {
                        // Чистим поля   
                        Login = "";
                        Password = "";
                        URL = "";
                    }
                }
                // Закрываем поток  
                fs.Close();
            }
        }
        public string GetLogin_serversetup()
        {
            this.ReadXMLDocumentServerSetup(ServerSetupFileName, "1");
            return Login;
        }

        public string GetPassword_serversetup()
        {
            this.ReadXMLDocumentServerSetup(ServerSetupFileName, "1");
            return Password;
        }
        public string GetURL_serversetup()
        {
            this.ReadXMLDocumentServerSetup(ServerSetupFileName, "1");
            return URL;
        }

        public void SetLogin_serversetup(string Login_)
        {
            this.Login = Login_;
            this.WriteToXMLDocumentServerSetup(ServerSetupFileName, Login, Password, URL);
        }
        public void SetPassword_serversetup(string Password_)
        {
            this.Password = Password_;
            this.WriteToXMLDocumentServerSetup(ServerSetupFileName, Login, Password, URL);
        }
        public void SetURL_serversetup(string URL_)
        {
            this.URL = URL_;
            this.WriteToXMLDocumentServerSetup(ServerSetupFileName, Login, Password, URL);
        }

        public void CreatePovestkaXML(Povestka PovestkaToPovestkaXML)
        {

        }
        public Povestka ReadPovestkaXML(string filepath)
        {
            Povestka Apovestka = new Povestka();
            //расшифровка из файла
            return Apovestka;
        }
        public void WritePovestkaXML(Povestka PovestkaToActual, string filepath)
        {
            //зашифровка в файл
        }
  
    }
}
