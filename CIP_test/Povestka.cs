using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace CIP_test
{
    public class Povestka
    {
        private DateTime DatePovestka;
        private String Name;
        private List<Questions> Question;
        private DateTime LastLoadDate;

        public Povestka()
        {
            this.Question = new List<Questions>();
            this.DatePovestka = new DateTime(2014, 1, 21);
            this.LastLoadDate = new DateTime(1985, 4, 2);
        }

        public Povestka(Povestka a)
        {
            this.LastLoadDate = a.LastLoadDate;
            this.DatePovestka = a.DatePovestka;
            this.Name = a.Name;
            this.Question = new List<Questions>(a.Question);
        }
        ~Povestka()
        {
            //Question.Clear();
        }
        public void GenerateTestDATA()
        {
            DatePovestka = new DateTime(2014, 1, 21);
            this.Name = "Повестка дня четырнадцатого заседания Государственного Совета Республики";
            Questions quest1 = new Questions(1, "Об избрании мировых судей Республики Татарстан", "");
            quest1.AddMaterial("1.jpg");
            quest1.AddMaterial("2.jpg");
            quest1.AddMaterial("3.jpg");
            Questions quest2 = new Questions(2, "О проекте закона Республики Татарстан №6181-4 Об установлении на 2011 год велечины прожиточного минимума пенсионера в Республике Татарстан для определения размера федеральной социальной доплаты к пенсии", "");
            quest2.AddMaterial("4.jpg");
            quest2.AddMaterial("5.jpg");
            quest2.AddMaterial("6.jpg");

            this.Question.Add(quest1);
            this.Question.Add(quest2);
        }
        public String GetName()
        {
            return this.Name;
        }
        public void SetName(String NameToSet)
        {
            this.Name = NameToSet;
        }
        public String GetTimeToString()
        {
            return this.DatePovestka.ToString();
        }
        private DateTime DecodeTime(string time)
        {
            
            /*
            int day = Int32.Parse(time.Split('.')[0].Trim());
            int month = Int32.Parse(time.Split('.')[1].Trim());
            int year = Int32.Parse(time.Split(' '));
            int hour = Int32.Parse(time.Split(':')[0].Trim());
            int minute = Int32.Parse(time.Split(':')[1].Trim());

            DateTime decode = new DateTime(year, month, day, hour, minute, 0);
            */
            CultureInfo MyCultureInfo = new CultureInfo("ru-RU");
            DateTime decode = DateTime.Parse(time, MyCultureInfo,
                                           DateTimeStyles.NoCurrentDateDefault);

            return decode;
        }
        public void SetTime(string TimeString)
        {
            this.DatePovestka = this.DecodeTime(TimeString);
        }

        public List<string> GetQuestionsToListString()
        {
            List<string> QuestionString = new List<string>();
            for (int i = 0; i < Question.Count; i++)
            {
                QuestionString.Add(Question.ElementAt(i).GetStringData());
            }
            return QuestionString;
        }


        public void AddQuestion(Questions QuestionToAdd)
        {
            Question.Add(QuestionToAdd);
        }
        public string GetStringQuestAt(int id)
        {
            return this.Question.ElementAt(id).GetStringData();
        }
        public List<Questions> GetListQuestions()
        {
            return this.Question;
        }
        public void SetTimeDate(DateTime TimeDateToSet)
        {
            DatePovestka = TimeDateToSet;
        }

        public String GetFirstMaterialAtQuestion(int id_Question)
        {
            return Question.ElementAt(id_Question).GetMaterial();
        }
        public String GetNextMaterialAtQuestion(int id_Question)
        {
            return Question.ElementAt(id_Question).GetMaterial("NEXT");
        }
        public String GetLastMaterialAtQuestion(int id_Question)
        {
            return Question.ElementAt(id_Question).GetMaterial("LAST");
        }
        public List<string> GetAllMaterials()
        {
            List<string> AllMaterials = new List<string>();
            for (int i = 0; i < Question.Count; i++)
            {
                List<string> tempListMaterials = new List<string>();
                tempListMaterials = Question.ElementAt(i).GetListMaterials();
                for(int i2=0; i2<tempListMaterials.Count; i2++)
                {
                    AllMaterials.Add(tempListMaterials.ElementAt(i2));
                }
            }
            return AllMaterials;
        }
        private bool ActualLoad(string filepath)
        {
            //Сравнивает дату последней загрузки и дату файла который собираемся загружать, если загружаемый файл новее тогда выдает false
            try
            {
                DateTime dt = File.GetLastWriteTime(filepath);
                if (LastLoadDate.CompareTo(dt)<0)
                    return false;
                else return true;
            }
            catch
            {
                return false;//если поменять на 1, то будет работать как защита от чтения отсутствующего файла
            }
        }

        public void LoadAtFile(string filepath)
        {
            if (!this.ActualLoad(filepath))
            {
                XML Bxml = new XML();
                Povestka TempPovestka = new Povestka(Bxml.ReadPovestkaXML(filepath));
                this.DatePovestka = TempPovestka.DatePovestka;
                this.Name = TempPovestka.Name;
                this.LastLoadDate = TempPovestka.LastLoadDate;
                this.Question = TempPovestka.Question;
                DateTime dateNow = DateTime.Now;
                LastLoadDate = dateNow;
            }
        }

        public void SaveToFile(string filepath)
        {
            XML Bxml = new XML();
            Bxml.WritePovestkaXML(this, filepath);
        }
        
    }
}
