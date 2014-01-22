using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace CIP_test
{
    public class XML: Povestka
    {
        //private XmlDocument xmlDoc;
        private String Login, Password, URL;
        private String ServerSetupFileName;
        private String LocalPovestkaFileName;

        public XML()
        {
            //xmlDoc = new XmlDocument();
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
            //if (!File.Exists(filepath))
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
        private void ReadXMLDocumentServerSetup(string filepath)
        {
            if (File.Exists(filepath))
            {
                string name, pwd, url_; // Новые переменные имени, пароля и адреса
 
                XmlDocument xd = new XmlDocument();
                FileStream fs = new FileStream(filepath, FileMode.Open);
                xd.Load(fs);
                XmlElement user = (XmlElement)xd.GetElementsByTagName("login")[0];
                XmlElement pass = (XmlElement)xd.GetElementsByTagName("password")[0];    
                XmlElement urll = (XmlElement)xd.GetElementsByTagName("URL")[0];
               // Вставляем в переменные текст из тегов  
                name = user.InnerText;
                pwd = pass.InnerText;
                url_ = urll.InnerText;

               // Заполняем поля   
                Login = name;
                Password = pwd;
                URL = url_;
     
                // Закрываем поток  
                fs.Close();
            }
        }
        public string GetLogin_serversetup()
        {
            this.ReadXMLDocumentServerSetup(ServerSetupFileName);
            return Login;
        }

        public string GetPassword_serversetup()
        {
            this.ReadXMLDocumentServerSetup(ServerSetupFileName);
            return Password;
        }
        public string GetURL_serversetup()
        {
            this.ReadXMLDocumentServerSetup(ServerSetupFileName);
            return URL;
        }

        public void SaveLoginPasswordURL_serversetup(string Login_, string Password_, string URL_)
        {
            this.Login = Login_;
            this.Password = Password_;
            this.URL = URL_;
            this.WriteToXMLDocumentServerSetup(ServerSetupFileName, Login, Password, URL);
        }
   
        public void CreatePovestkaXML(string filepath)
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("povestka");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public Povestka ReadPovestkaXML(string filepath)
        {
            Povestka Apovestka = new Povestka();
            //расшифровка из файла
            if (File.Exists(filepath))
            {
                // Объявляем и забиваем файл в документ  
                XmlDocument xd = new XmlDocument();
                FileStream fs = new FileStream(filepath, FileMode.Open);
                xd.Load(fs);

                XmlNodeList list = xd.GetElementsByTagName("povestka"); // Создаем и заполняем лист по тегу "povestka"  
               
                for (int i = 0; i < list.Count; i++)
                {
                    XmlElement povestka = (XmlElement)xd.GetElementsByTagName("povestka")[i];         // Забиваем id в переменную  
                    if (povestka.GetAttribute("id") == "1") // Если наткнулся на нужный айдишник  
                    {
                        Apovestka.SetName(povestka.GetAttribute("name"));
                        Apovestka.SetTime(povestka.GetAttribute("time"));
                        XmlNodeList list2 = xd.GetElementsByTagName("question");
                        for (int i2 = 0; i2 < list2.Count; i2++)
                        {
                            XmlElement question = (XmlElement)xd.GetElementsByTagName("question")[i2];
                            Questions QuestTmp = new Questions(question.GetAttribute("number"), question.GetAttribute("name"), question.GetAttribute("FIO"));

                            XmlNodeList list3 = xd.GetElementsByTagName("material");
                            for (int i3 = 0; i3 < list3.Count; i3++)
                            {
                                XmlElement material = (XmlElement)xd.GetElementsByTagName("material")[i3];
                                string linkmaterial;
                                linkmaterial = material.InnerText;
                                if (Int32.Parse(material.GetAttribute("id")) == i2)
                                    QuestTmp.AddMaterial(linkmaterial);
                            }
                            Apovestka.AddQuestion(QuestTmp);
                        }
                        break;
                    }
                    else
                    {
                      // скорее всего файла нет
                    }
                }
                // Закрываем поток  
                fs.Close();
            }
            return Apovestka;
        }
        public void WritePovestkaXML(Povestka PovestkaToActual, string filepath)
        {
            //зашифровка в файл
           // if (!File.Exists(filepath)) -если раскомментировать, то можно не перезаписывать файл, а писать дальше в него, на случай модернизации для множества повесток
            {
                this.CreatePovestkaXML(filepath);
            }
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            // Создаем новую запись povestka c аттрибутом id  
            XmlElement povestka = xd.CreateElement("povestka");
            povestka.SetAttribute("id", "1");
            povestka.SetAttribute("name", PovestkaToActual.GetName());
            povestka.SetAttribute("time", PovestkaToActual.GetTimeToString());

            List<Questions> ListQuestTmp = new List<Questions>(PovestkaToActual.GetListQuestions());
            for (int i = 0; i < ListQuestTmp.Count; i++)
            {
                XmlElement question = xd.CreateElement("question");
                
                question.SetAttribute("id", i.ToString());
                question.SetAttribute("number", ListQuestTmp.ElementAt(i).GetNumber());
                question.SetAttribute("name", ListQuestTmp.ElementAt(i).GetName());
                question.SetAttribute("FIO", ListQuestTmp.ElementAt(i).GetFIO());

                List<string> LinkMaterialTmp = new List<string>(ListQuestTmp.ElementAt(i).GetListMaterials());
                for(int ii=0; ii<LinkMaterialTmp.Count; ii++)
                {
                    XmlElement material = xd.CreateElement("material");
                    material.SetAttribute("id", i.ToString());
                    XmlText tMaterial = xd.CreateTextNode(LinkMaterialTmp.ElementAt(ii));
                    material.AppendChild(tMaterial);
                    question.AppendChild(material);
                }
                povestka.AppendChild(question);
            }

            // ЗАбиваем запись в документ  
            xd.DocumentElement.AppendChild(povestka);

            fs.Close();         // Закрываем поток  
            xd.Save(filepath); // Сохраняем файл  
        }
  
    }
}
