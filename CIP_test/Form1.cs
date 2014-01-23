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
        ServerCIP serv1;

        public Form1()
        {
            InitializeComponent();
            pov1 = new Povestka();
            /*
            pov1.GenerateTestDATA();
            pov1.SaveToFile("actual.xml");*/
            pov1.LoadAtFile("actual.xml");
           

            serv1 = new ServerCIP();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            serv1.UpdatePovestkaXML();

        }

        private void buttonSaveServerSetup_Click(object sender, EventArgs e)
        {
            this.buttonServerSetting_Click(sender, e);
            if (textBoxURL.Text == "URL")
            {
                textBoxURL.Text = serv1.GetURL(); 
            }
            if (textBoxLogin.Text == "Login")
            {
                textBoxLogin.Text = serv1.GetLogin();
            }
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Text = serv1.GetPassword();
            }
            serv1.SetLoginPasswordURL(textBoxLogin.Text, textBoxPassword.Text, textBoxURL.Text);
        }

        private void buttonServerSetting_Click(object sender, EventArgs e)
        {
            this.panelServerSetup.Visible = !this.panelServerSetup.Visible;
        }

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxURL_Click(object sender, EventArgs e)
        {
            textBoxURL.Text = serv1.GetURL(); 
        }

        private void textBoxLogin_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = serv1.GetLogin();
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text = serv1.GetPassword();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = ComputeFibonacci((int)e.Argument, worker, e);
            serv1.UpdatePovestkaXML();*/
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

       
    }


}
