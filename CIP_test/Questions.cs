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


        public Questions(int Numb, String Quest_Name, String FirstLastName)
        {
            this.id = 0;
            this.Number = Numb;
            this.Name = Quest_Name;
            this.FIO = FirstLastName;
            List<string> LinkMaterial = new List<string>();
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
        public List<string> GetAllMaterials()
        {
            return LinkMaterial;
        }
    }
}
