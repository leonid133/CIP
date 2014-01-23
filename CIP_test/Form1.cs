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
        int IndexSelectQuestlist;
        
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();

            pov1 = new Povestka();
            serv1 = new ServerCIP();
            //pov1.GenerateTestDATA();
            //pov1.SaveToFile("actual.xml");
            pictureNoUpd.Visible = true;
            pov1.LoadAtFile("actual.xml");

            // отрисовка главной страницы
            label_time.Text = pov1.GetTimeToString();
            textBoxNamePovestka.Text = pov1.GetName();
            List<string> Question1 = new List<string>();
            Question1 = pov1.GetQuestionsToListString();
            listBox1.Items.Clear();
            for (int i = 0; i < Question1.Count; i++)
            {
                listBox1.Items.Add(Question1.ElementAt(i));
            }
       
        }
        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
                                    
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
            BackgroundWorker worker = sender as BackgroundWorker;
            
            serv1.UpdatePovestkaXML();
            pov1.LoadAtFile("actual.xml");
            worker.CancelAsync();
        }

        
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureNoUpd.Visible = true;
            pictureUpd.Visible = false;
            if (e.Error == null && serv1.internetConnection && serv1.updateStatus)
            {
                pictureNoUpd.Visible = false;
                pictureUpd.Visible = true;
                
            }
            
            // отрисовка главной страницы
            label_time.Text = pov1.GetTimeToString();
            textBoxNamePovestka.Text = pov1.GetName();
            List<string> Question1 = new List<string>();
            Question1 = pov1.GetQuestionsToListString();
            listBox1.Items.Clear();
            for (int i = 0; i < Question1.Count; i++)
            {
                listBox1.Items.Add(Question1.ElementAt(i));
            }
            
            timer1.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonkPovestke_Click(object sender, EventArgs e)
        {
            textBoxQuestMat.Visible = false;
            buttonkPovestke.Visible = false;
            button90.Visible = false;
            buttonLastMaterial.Visible = false;
            buttonFirst.Visible = false;
            buttonNextMaterial.Visible = false;
            pictureBoxMaterial.Visible = false;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBoxQuestMat.Visible = true;
            buttonkPovestke.Visible = true;
            button90.Visible = true;
            buttonLastMaterial.Visible = true;
            buttonFirst.Visible = true;
            buttonNextMaterial.Visible = true;
            pictureBoxMaterial.Visible = true;
            IndexSelectQuestlist = listBox1.SelectedIndex;
            textBoxQuestMat.Text = pov1.GetStringQuestAt(IndexSelectQuestlist);
            Image img = Image.FromFile(pov1.GetFirstMaterialAtQuestion(listBox1.SelectedIndex));
            pictureBoxMaterial.Image = img;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button90_Click(object sender, EventArgs e)
        {
            Image img;
            img = pictureBoxMaterial.Image; 
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBoxMaterial.Image = img;
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(pov1.GetFirstMaterialAtQuestion(IndexSelectQuestlist));
            pictureBoxMaterial.Image = img;
        }

        private void buttonLastMaterial_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(pov1.GetLastMaterialAtQuestion(IndexSelectQuestlist));
            pictureBoxMaterial.Image = img;
        }

        private void buttonNextMaterial_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(pov1.GetNextMaterialAtQuestion(IndexSelectQuestlist));
            pictureBoxMaterial.Image = img;
        }

       
    }


}
