namespace MoonSub
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.bittxt = new System.Windows.Forms.Label();
            this.ostxt = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblversion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.botPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.checkOrganize = new System.Windows.Forms.CheckBox();
            this.checkData = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkNew = new System.Windows.Forms.CheckBox();
            this.checkRename = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.infoBox = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPriority = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.languageList = new System.Windows.Forms.CheckedListBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.botPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.bittxt);
            this.topPanel.Controls.Add(this.ostxt);
            this.topPanel.Controls.Add(this.pictureBox1);
            this.topPanel.Controls.Add(this.lblversion);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(964, 77);
            this.topPanel.TabIndex = 8;
            // 
            // bittxt
            // 
            this.bittxt.AutoSize = true;
            this.bittxt.ForeColor = System.Drawing.Color.Silver;
            this.bittxt.Location = new System.Drawing.Point(224, 46);
            this.bittxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bittxt.Name = "bittxt";
            this.bittxt.Size = new System.Drawing.Size(56, 20);
            this.bittxt.TabIndex = 6;
            this.bittxt.Text = "bitness";
            // 
            // ostxt
            // 
            this.ostxt.AutoSize = true;
            this.ostxt.ForeColor = System.Drawing.Color.Silver;
            this.ostxt.Location = new System.Drawing.Point(224, 26);
            this.ostxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ostxt.Name = "ostxt";
            this.ostxt.Size = new System.Drawing.Size(24, 20);
            this.ostxt.TabIndex = 5;
            this.ostxt.Text = "os";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblversion
            // 
            this.lblversion.AutoSize = true;
            this.lblversion.ForeColor = System.Drawing.Color.Silver;
            this.lblversion.Location = new System.Drawing.Point(90, 46);
            this.lblversion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(64, 20);
            this.lblversion.TabIndex = 4;
            this.lblversion.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(88, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "MoonSub";
            // 
            // botPanel
            // 
            this.botPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botPanel.Controls.Add(this.label3);
            this.botPanel.Controls.Add(this.label1);
            this.botPanel.Controls.Add(this.button4);
            this.botPanel.Controls.Add(this.checkOrganize);
            this.botPanel.Controls.Add(this.checkData);
            this.botPanel.Controls.Add(this.button3);
            this.botPanel.Controls.Add(this.checkNew);
            this.botPanel.Controls.Add(this.checkRename);
            this.botPanel.Controls.Add(this.panel2);
            this.botPanel.Controls.Add(this.button2);
            this.botPanel.Controls.Add(this.txtInput);
            this.botPanel.Controls.Add(this.button1);
            this.botPanel.Controls.Add(this.lblPriority);
            this.botPanel.Controls.Add(this.panel1);
            this.botPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botPanel.Location = new System.Drawing.Point(0, 77);
            this.botPanel.Margin = new System.Windows.Forms.Padding(2);
            this.botPanel.Name = "botPanel";
            this.botPanel.Size = new System.Drawing.Size(964, 571);
            this.botPanel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(194, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 28);
            this.label3.TabIndex = 87;
            this.label3.Tag = "themeable";
            this.label3.Text = "File or folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(195, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 28);
            this.label1.TabIndex = 86;
            this.label1.Tag = "themeable";
            this.label1.Text = "Information:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(568, 79);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 38);
            this.button4.TabIndex = 85;
            this.button4.Tag = "themeable";
            this.button4.Text = "Options";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkOrganize
            // 
            this.checkOrganize.AutoSize = true;
            this.checkOrganize.Location = new System.Drawing.Point(465, 148);
            this.checkOrganize.Margin = new System.Windows.Forms.Padding(2);
            this.checkOrganize.Name = "checkOrganize";
            this.checkOrganize.Size = new System.Drawing.Size(161, 24);
            this.checkOrganize.TabIndex = 82;
            this.checkOrganize.Text = "Organize in folders";
            this.checkOrganize.UseVisualStyleBackColor = true;
            this.checkOrganize.CheckedChanged += new System.EventHandler(this.checkOrganize_CheckedChanged);
            // 
            // checkData
            // 
            this.checkData.AutoSize = true;
            this.checkData.Location = new System.Drawing.Point(200, 148);
            this.checkData.Margin = new System.Windows.Forms.Padding(2);
            this.checkData.Name = "checkData";
            this.checkData.Size = new System.Drawing.Size(233, 24);
            this.checkData.TabIndex = 80;
            this.checkData.Text = "Download movie data (IMDb)";
            this.checkData.UseVisualStyleBackColor = true;
            this.checkData.CheckedChanged += new System.EventHandler(this.checkData_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(445, 79);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 38);
            this.button3.TabIndex = 84;
            this.button3.Tag = "themeable";
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkNew
            // 
            this.checkNew.AutoSize = true;
            this.checkNew.Location = new System.Drawing.Point(465, 122);
            this.checkNew.Margin = new System.Windows.Forms.Padding(2);
            this.checkNew.Name = "checkNew";
            this.checkNew.Size = new System.Drawing.Size(221, 24);
            this.checkNew.TabIndex = 79;
            this.checkNew.Text = "Ignore movies with subtitles";
            this.checkNew.UseVisualStyleBackColor = true;
            this.checkNew.CheckedChanged += new System.EventHandler(this.checkNew_CheckedChanged);
            // 
            // checkRename
            // 
            this.checkRename.AutoSize = true;
            this.checkRename.Location = new System.Drawing.Point(200, 122);
            this.checkRename.Margin = new System.Windows.Forms.Padding(2);
            this.checkRename.Name = "checkRename";
            this.checkRename.Size = new System.Drawing.Size(163, 24);
            this.checkRename.TabIndex = 78;
            this.checkRename.Text = "Rename movie files";
            this.checkRename.UseVisualStyleBackColor = true;
            this.checkRename.CheckedChanged += new System.EventHandler(this.checkRename_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.infoBox);
            this.panel2.Location = new System.Drawing.Point(199, 206);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 305);
            this.panel2.TabIndex = 7;
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.infoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoBox.ForeColor = System.Drawing.Color.White;
            this.infoBox.FormattingEnabled = true;
            this.infoBox.ItemHeight = 20;
            this.infoBox.Location = new System.Drawing.Point(0, 0);
            this.infoBox.Margin = new System.Windows.Forms.Padding(2);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(750, 303);
            this.infoBox.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(322, 79);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 38);
            this.button2.TabIndex = 75;
            this.button2.Tag = "themeable";
            this.button2.Text = "Select file";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.ForeColor = System.Drawing.Color.Silver;
            this.txtInput.Location = new System.Drawing.Point(199, 46);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(751, 27);
            this.txtInput.TabIndex = 77;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(199, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 38);
            this.button1.TabIndex = 76;
            this.button1.Tag = "themeable";
            this.button1.Text = "Select folder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPriority
            // 
            this.lblPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblPriority.Location = new System.Drawing.Point(8, 530);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(82, 28);
            this.lblPriority.TabIndex = 5;
            this.lblPriority.Tag = "themeable";
            this.lblPriority.Text = "Priority:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.languageList);
            this.panel1.Location = new System.Drawing.Point(12, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 497);
            this.panel1.TabIndex = 1;
            // 
            // languageList
            // 
            this.languageList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.languageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.languageList.CheckOnClick = true;
            this.languageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.languageList.ForeColor = System.Drawing.Color.White;
            this.languageList.FormattingEnabled = true;
            this.languageList.Items.AddRange(new object[] {
            "Arabic",
            "Bulgarian",
            "Chinese",
            "Croatian",
            "Czech",
            "Danish",
            "Dutch",
            "English",
            "Estonian",
            "FYROM",
            "Finnish",
            "French",
            "Galician",
            "German",
            "Greek",
            "Hebrew",
            "Hungarian",
            "Indonesian",
            "Italian",
            "Japanese",
            "Korean",
            "Norwegian",
            "Persian",
            "Polish",
            "Portuguese",
            "Romanian",
            "Russian",
            "Serbian",
            "Slovak",
            "Spanish",
            "Swedish",
            "Turkish",
            "Vietnamese"});
            this.languageList.Location = new System.Drawing.Point(0, 0);
            this.languageList.Margin = new System.Windows.Forms.Padding(2);
            this.languageList.Name = "languageList";
            this.languageList.Size = new System.Drawing.Size(171, 497);
            this.languageList.TabIndex = 0;
            this.languageList.SelectedIndexChanged += new System.EventHandler(this.languageList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(964, 648);
            this.Controls.Add(this.botPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoonSub";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.botPanel.ResumeLayout(false);
            this.botPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblversion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel botPanel;
        private System.Windows.Forms.Label bittxt;
        private System.Windows.Forms.Label ostxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox languageList;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox infoBox;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkOrganize;
        private System.Windows.Forms.CheckBox checkData;
        private System.Windows.Forms.CheckBox checkNew;
        private System.Windows.Forms.CheckBox checkRename;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

