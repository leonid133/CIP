using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace CIP_test
{

    public partial class Form1 : Form
    {
        Povestka pov1;

        public Form1()
        {
            InitializeComponent();
            pov1 = new Povestka();
            
            pov1.GenerateTestDATA();
            pov1.SaveToFile("1.xml");
            pov1.LoadAtFile("1.xml");
            pov1.LoadAtFile("1.xml");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void buttonSaveServerSetup_Click(object sender, EventArgs e)
        {
            this.buttonServerSetting_Click(sender, e);
        }

        private void buttonServerSetting_Click(object sender, EventArgs e)
        {
            this.panelServerSetup.Visible = !this.panelServerSetup.Visible;
        }

       
    }


}
