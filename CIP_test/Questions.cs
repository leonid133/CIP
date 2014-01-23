using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIP_test
{
    public class Questions
    {
        private int Number;
        private String Name;
        private String FIO;
        private List<string> LinkMaterial;
        private int id;
        /*
        public Questions()
        {
            this.id = 0;
            this.Number = 0;
            this.Name = "";
            this.FIO = "";
            List<string>  LinkMaterial = new List<string>();
        }*/
        public Questions(string Numb, String Quest_Name, String FirstLastName)
        {
            this.id = 0;
            this.Number = Int32.Parse(Numb.Trim());
            this.Name = Quest_Name;
            this.FIO = FirstLastName;
            LinkMaterial = new List<string>();
        }
        public Questions(int Numb, String Quest_Name, String FirstLastName)
        {
            this.id = 0;
            this.Number = Numb;
            this.Name = Quest_Name;
            this.FIO = FirstLastName;
            LinkMaterial = new List<string>();
        }
        public Questions(Questions a)
        {
            this.id = a.id;
            this.Number = a.Number;
            this.Name = a.Name;
            this.FIO = a.FIO;
            LinkMaterial = new List<string>();
            LinkMaterial = a.LinkMaterial;
        }
        ~Questions()
        {
            LinkMaterial.Clear();
        }

        public string GetStringData()
        {
            string txt;
            txt = Number.ToString();
            txt += ". ";
            txt += Name;
            txt += "; ";
            txt += "Учасники: ";
            txt += FIO;

            return txt;
        }
        public string GetNumber()
        {
            return this.Number.ToString();
        }
        public string GetName()
        {
            return this.Name;
        }
        public string GetFIO()
        {
            return this.FIO;
        }

        public void AddMaterial(string Material)
        {
            LinkMaterial.Add(Material);
        }

        public string GetMaterial(String Next_Last)
        {
            if (Next_Last == "NEXT")
            {
                id++;
                if (id > LinkMaterial.Count)
                    id = 0;
            }
            else if (Next_Last == "LAST")
            {
                id--;
                if (id <= 0)
                    id = LinkMaterial.Count;
            }
            else id = 0;

            if (id <= LinkMaterial.Count && id >= 0)
            {
                return LinkMaterial.ElementAt(id);
            }
            return "NULL";
        }
        public string GetMaterial()
        {
            id = 0;
            if (id <= LinkMaterial.Count && id >= 0)
            {
                return LinkMaterial.ElementAt(id);
            }
            return "NULL";
        }
        public string GetMaterial(int id)
        {
            if (id <= LinkMaterial.Count && id >= 0)
            {
                return LinkMaterial.ElementAt(id);
            }
            return "NULL";
        }
        public List<string> GetListMaterials()
        {
            return LinkMaterial;
        }
    }
}
