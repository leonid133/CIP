namespace CIP_test
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureNoUpd = new System.Windows.Forms.PictureBox();
            this.pictureUpd = new System.Windows.Forms.PictureBox();
            this.textBoxNamePovestka = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_time = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.panelServerSetup = new System.Windows.Forms.Panel();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.buttonSaveServerSetup = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonServerSetting = new System.Windows.Forms.Button();
            this.pictureBoxMaterial = new System.Windows.Forms.PictureBox();
            this.buttonkPovestke = new System.Windows.Forms.Button();
            this.buttonNextMaterial = new System.Windows.Forms.Button();
            this.buttonLastMaterial = new System.Windows.Forms.Button();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.button90 = new System.Windows.Forms.Button();
            this.textBoxQuestMat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNoUpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUpd)).BeginInit();
            this.panelServerSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CIP_test.Properties.Resources.logo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.listBox1);
            this.flowLayoutPanel1.Controls.Add(this.listBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(583, 547);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureNoUpd);
            this.panel1.Controls.Add(this.pictureUpd);
            this.panel1.Controls.Add(this.textBoxNamePovestka);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label_time);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 127);
            this.panel1.TabIndex = 1;
            // 
            // pictureNoUpd
            // 
            this.pictureNoUpd.Image = ((System.Drawing.Image)(resources.GetObject("pictureNoUpd.Image")));
            this.pictureNoUpd.Location = new System.Drawing.Point(536, 3);
            this.pictureNoUpd.Name = "pictureNoUpd";
            this.pictureNoUpd.Size = new System.Drawing.Size(36, 29);
            this.pictureNoUpd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureNoUpd.TabIndex = 4;
            this.pictureNoUpd.TabStop = false;
            this.pictureNoUpd.Visible = false;
            // 
            // pictureUpd
            // 
            this.pictureUpd.Image = ((System.Drawing.Image)(resources.GetObject("pictureUpd.Image")));
            this.pictureUpd.Location = new System.Drawing.Point(496, 0);
            this.pictureUpd.Name = "pictureUpd";
            this.pictureUpd.Size = new System.Drawing.Size(34, 32);
            this.pictureUpd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureUpd.TabIndex = 3;
            this.pictureUpd.TabStop = false;
            this.pictureUpd.Visible = false;
            // 
            // textBoxNamePovestka
            // 
            this.textBoxNamePovestka.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNamePovestka.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNamePovestka.Location = new System.Drawing.Point(15, 38);
            this.textBoxNamePovestka.Multiline = true;
            this.textBoxNamePovestka.Name = "textBoxNamePovestka";
            this.textBoxNamePovestka.Size = new System.Drawing.Size(557, 71);
            this.textBoxNamePovestka.TabIndex = 2;
            this.textBoxNamePovestka.Text = "Название повестки";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "РУС/ТАТ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_time.Location = new System.Drawing.Point(12, 12);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(167, 15);
            this.label_time.TabIndex = 0;
            this.label_time.Text = "Дата проведения повестки";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "1. Вопрос повестки",
            "2. Еще один вопрос повестки"});
            this.listBox1.Location = new System.Drawing.Point(3, 143);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(572, 404);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.listBox2.Location = new System.Drawing.Point(3, 560);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(153, 98);
            // 
            // panelServerSetup
            // 
            this.panelServerSetup.Controls.Add(this.textBoxURL);
            this.panelServerSetup.Controls.Add(this.textBoxLogin);
            this.panelServerSetup.Controls.Add(this.buttonSaveServerSetup);
            this.panelServerSetup.Controls.Add(this.textBoxPassword);
            this.panelServerSetup.Location = new System.Drawing.Point(383, 37);
            this.panelServerSetup.MaximumSize = new System.Drawing.Size(200, 100);
            this.panelServerSetup.MinimumSize = new System.Drawing.Size(200, 31);
            this.panelServerSetup.Name = "panelServerSetup";
            this.panelServerSetup.Size = new System.Drawing.Size(200, 59);
            this.panelServerSetup.TabIndex = 5;
            this.panelServerSetup.Visible = false;
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(0, 0);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(181, 20);
            this.textBoxURL.TabIndex = 3;
            this.textBoxURL.Text = "URL";
            this.textBoxURL.Click += new System.EventHandler(this.textBoxURL_Click);
            this.textBoxURL.TextChanged += new System.EventHandler(this.textBoxURL_TextChanged);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(0, 20);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.Text = "Login";
            this.textBoxLogin.Click += new System.EventHandler(this.textBoxLogin_Click);
            // 
            // buttonSaveServerSetup
            // 
            this.buttonSaveServerSetup.Location = new System.Drawing.Point(108, 36);
            this.buttonSaveServerSetup.Name = "buttonSaveServerSetup";
            this.buttonSaveServerSetup.Size = new System.Drawing.Size(73, 23);
            this.buttonSaveServerSetup.TabIndex = 2;
            this.buttonSaveServerSetup.Text = "Сохранить";
            this.buttonSaveServerSetup.UseVisualStyleBackColor = true;
            this.buttonSaveServerSetup.Click += new System.EventHandler(this.buttonSaveServerSetup_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(0, 39);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(101, 20);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.Text = "Password";
            this.textBoxPassword.Click += new System.EventHandler(this.textBoxPassword_Click);
            // 
            // buttonServerSetting
            // 
            this.buttonServerSetting.Location = new System.Drawing.Point(414, 10);
            this.buttonServerSetting.Name = "buttonServerSetting";
            this.buttonServerSetting.Size = new System.Drawing.Size(138, 21);
            this.buttonServerSetting.TabIndex = 4;
            this.buttonServerSetting.Text = "Настройки сервера";
            this.buttonServerSetting.UseVisualStyleBackColor = true;
            this.buttonServerSetting.Click += new System.EventHandler(this.buttonServerSetting_Click);
            // 
            // pictureBoxMaterial
            // 
            this.pictureBoxMaterial.Location = new System.Drawing.Point(3, 5);
            this.pictureBoxMaterial.Name = "pictureBoxMaterial";
            this.pictureBoxMaterial.Size = new System.Drawing.Size(577, 652);
            this.pictureBoxMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMaterial.TabIndex = 6;
            this.pictureBoxMaterial.TabStop = false;
            this.pictureBoxMaterial.Visible = false;
            // 
            // buttonkPovestke
            // 
            this.buttonkPovestke.Location = new System.Drawing.Point(477, 12);
            this.buttonkPovestke.Name = "buttonkPovestke";
            this.buttonkPovestke.Size = new System.Drawing.Size(87, 39);
            this.buttonkPovestke.TabIndex = 7;
            this.buttonkPovestke.Text = "К повестке";
            this.buttonkPovestke.UseVisualStyleBackColor = true;
            this.buttonkPovestke.Visible = false;
            this.buttonkPovestke.Click += new System.EventHandler(this.buttonkPovestke_Click);
            // 
            // buttonNextMaterial
            // 
            this.buttonNextMaterial.Location = new System.Drawing.Point(415, 593);
            this.buttonNextMaterial.Name = "buttonNextMaterial";
            this.buttonNextMaterial.Size = new System.Drawing.Size(100, 44);
            this.buttonNextMaterial.TabIndex = 8;
            this.buttonNextMaterial.Text = "Следующий материал";
            this.buttonNextMaterial.UseVisualStyleBackColor = true;
            this.buttonNextMaterial.Visible = false;
            this.buttonNextMaterial.Click += new System.EventHandler(this.buttonNextMaterial_Click);
            // 
            // buttonLastMaterial
            // 
            this.buttonLastMaterial.Location = new System.Drawing.Point(60, 591);
            this.buttonLastMaterial.Name = "buttonLastMaterial";
            this.buttonLastMaterial.Size = new System.Drawing.Size(105, 46);
            this.buttonLastMaterial.TabIndex = 9;
            this.buttonLastMaterial.Text = "Предыдущий материал";
            this.buttonLastMaterial.UseVisualStyleBackColor = true;
            this.buttonLastMaterial.Visible = false;
            this.buttonLastMaterial.Click += new System.EventHandler(this.buttonLastMaterial_Click);
            // 
            // buttonFirst
            // 
            this.buttonFirst.Location = new System.Drawing.Point(237, 593);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(104, 44);
            this.buttonFirst.TabIndex = 10;
            this.buttonFirst.Text = "К началу";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Visible = false;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // button90
            // 
            this.button90.Location = new System.Drawing.Point(38, 103);
            this.button90.Name = "button90";
            this.button90.Size = new System.Drawing.Size(75, 35);
            this.button90.TabIndex = 11;
            this.button90.Text = "Повернуть на 90";
            this.button90.UseVisualStyleBackColor = true;
            this.button90.Visible = false;
            this.button90.Click += new System.EventHandler(this.button90_Click);
            // 
            // textBoxQuestMat
            // 
            this.textBoxQuestMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQuestMat.Location = new System.Drawing.Point(18, 12);
            this.textBoxQuestMat.Multiline = true;
            this.textBoxQuestMat.Name = "textBoxQuestMat";
            this.textBoxQuestMat.Size = new System.Drawing.Size(453, 81);
            this.textBoxQuestMat.TabIndex = 13;
            this.textBoxQuestMat.Text = "Название текущего вопроса";
            this.textBoxQuestMat.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 662);
            this.Controls.Add(this.textBoxQuestMat);
            this.Controls.Add(this.button90);
            this.Controls.Add(this.buttonFirst);
            this.Controls.Add(this.buttonLastMaterial);
            this.Controls.Add(this.buttonNextMaterial);
            this.Controls.Add(this.buttonkPovestke);
            this.Controls.Add(this.pictureBoxMaterial);
            this.Controls.Add(this.buttonServerSetting);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelServerSetup);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Повестка совещание";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNoUpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUpd)).EndInit();
            this.panelServerSetup.ResumeLayout(false);
            this.panelServerSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureUpd;
        private System.Windows.Forms.TextBox textBoxNamePovestka;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.PictureBox pictureNoUpd;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Panel panelServerSetup;
        private System.Windows.Forms.Button buttonServerSetting;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button buttonSaveServerSetup;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.PictureBox pictureBoxMaterial;
        private System.Windows.Forms.Button buttonkPovestke;
        private System.Windows.Forms.Button buttonNextMaterial;
        private System.Windows.Forms.Button buttonLastMaterial;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button button90;
        private System.Windows.Forms.TextBox textBoxQuestMat;
    }
}

