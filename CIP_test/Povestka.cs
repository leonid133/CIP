using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            List<Questions> Question = new List<Questions>();
        }

        public Povestka(Povestka a)
        {
            this.LastLoadDate = a.LastLoadDate;
            this.DatePovestka = a.DatePovestka;
            this.Name = a.Name;
            List<Questions> Question = new List<Questions>(a.Question);
        }
        ~Povestka()
        {
            Question.Clear();
        }

        public String GetName()
        {
            return Name;
        }

        public String GetTimeToString()
        {
            return DatePovestka.ToLongDateString();
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
            List<string> AllMaterials = new List<string>(Question.ElementAt(0).GetAllMaterials());
            for (int i = 1; i < Question.Count; i++)
            {
                AllMaterials.Concat(Question.ElementAt(i).GetAllMaterials());
            }
            return AllMaterials;
        }
        private bool ActualLoad(string filepath)
        {
            //Сравнивает дату последней загрузки и дату файла который собираемся загружать, если загружаемый файл новее тогда выдает false

            return false;
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
                List<Questions> Question = new List<Questions>(TempPovestka.Question);
            }
        }

        public void SaveToFile(string filepath)
        {
            XML Bxml = new XML();
            Bxml.WritePovestkaXML(this, filepath);
        }
        
    }
}
