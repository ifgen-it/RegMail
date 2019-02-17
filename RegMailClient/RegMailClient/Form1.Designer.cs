namespace RegMailClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pickDate = new System.Windows.Forms.DateTimePicker();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTags = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbMailList = new System.Windows.Forms.TextBox();
            this.btnClearMailList = new System.Windows.Forms.Button();
            this.btnLoadMailList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbIP1 = new System.Windows.Forms.TextBox();
            this.tbIP2 = new System.Windows.Forms.TextBox();
            this.tbIP3 = new System.Windows.Forms.TextBox();
            this.tbIP4 = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lbStatusConnection = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSubmit);
            this.tabPage1.Controls.Add(this.pickDate);
            this.tabPage1.Controls.Add(this.tbMessage);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.tbTags);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbFrom);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbTo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbTitle);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 333);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Register";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 288);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(83, 28);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // pickDate
            // 
            this.pickDate.Location = new System.Drawing.Point(112, 51);
            this.pickDate.Name = "pickDate";
            this.pickDate.Size = new System.Drawing.Size(178, 27);
            this.pickDate.TabIndex = 2;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(112, 183);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessage.Size = new System.Drawing.Size(524, 133);
            this.tbMessage.TabIndex = 1;
            this.tbMessage.Text = "How are you, Kate?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Message :";
            // 
            // tbTags
            // 
            this.tbTags.Location = new System.Drawing.Point(112, 150);
            this.tbTags.Name = "tbTags";
            this.tbTags.Size = new System.Drawing.Size(524, 27);
            this.tbTags.TabIndex = 1;
            this.tbTags.Text = "new good mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tags :";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(112, 117);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(524, 27);
            this.tbFrom.TabIndex = 1;
            this.tbFrom.Text = "Evgen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "From :";
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(112, 84);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(524, 27);
            this.tbTo.TabIndex = 1;
            this.tbTo.Text = "Kate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "To :";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(112, 18);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(524, 27);
            this.tbTitle.TabIndex = 1;
            this.tbTitle.Text = "How do you do";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Title :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbMailList);
            this.tabPage2.Controls.Add(this.btnClearMailList);
            this.tabPage2.Controls.Add(this.btnLoadMailList);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 333);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Load";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbMailList
            // 
            this.tbMailList.BackColor = System.Drawing.Color.White;
            this.tbMailList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMailList.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMailList.Location = new System.Drawing.Point(0, 69);
            this.tbMailList.Multiline = true;
            this.tbMailList.Name = "tbMailList";
            this.tbMailList.ReadOnly = true;
            this.tbMailList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMailList.Size = new System.Drawing.Size(652, 268);
            this.tbMailList.TabIndex = 1;
            this.tbMailList.Text = "Here will be loaded mail";
            // 
            // btnClearMailList
            // 
            this.btnClearMailList.Location = new System.Drawing.Point(168, 23);
            this.btnClearMailList.Name = "btnClearMailList";
            this.btnClearMailList.Size = new System.Drawing.Size(126, 28);
            this.btnClearMailList.TabIndex = 0;
            this.btnClearMailList.Text = "Clear";
            this.btnClearMailList.UseVisualStyleBackColor = true;
            // 
            // btnLoadMailList
            // 
            this.btnLoadMailList.Location = new System.Drawing.Point(17, 23);
            this.btnLoadMailList.Name = "btnLoadMailList";
            this.btnLoadMailList.Size = new System.Drawing.Size(126, 28);
            this.btnLoadMailList.TabIndex = 0;
            this.btnLoadMailList.Text = "Load";
            this.btnLoadMailList.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(67, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Info :";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbInfo.Location = new System.Drawing.Point(124, 395);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(292, 19);
            this.lbInfo.TabIndex = 1;
            this.lbInfo.Text = "Welcome to the Registration Mail System";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.btnConnect);
            this.tabPage3.Controls.Add(this.tbIP4);
            this.tabPage3.Controls.Add(this.tbIP3);
            this.tabPage3.Controls.Add(this.tbIP2);
            this.tabPage3.Controls.Add(this.tbPort);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.tbIP1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.lbStatusConnection);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(652, 333);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Connection";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server configuration settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "IP adress :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "Port :";
            // 
            // tbIP1
            // 
            this.tbIP1.Location = new System.Drawing.Point(110, 74);
            this.tbIP1.Name = "tbIP1";
            this.tbIP1.Size = new System.Drawing.Size(37, 27);
            this.tbIP1.TabIndex = 2;
            this.tbIP1.Text = "127";
            this.tbIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP2
            // 
            this.tbIP2.Location = new System.Drawing.Point(153, 74);
            this.tbIP2.Name = "tbIP2";
            this.tbIP2.Size = new System.Drawing.Size(37, 27);
            this.tbIP2.TabIndex = 2;
            this.tbIP2.Text = "0";
            this.tbIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP3
            // 
            this.tbIP3.Location = new System.Drawing.Point(196, 74);
            this.tbIP3.Name = "tbIP3";
            this.tbIP3.Size = new System.Drawing.Size(37, 27);
            this.tbIP3.TabIndex = 2;
            this.tbIP3.Text = "0";
            this.tbIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIP4
            // 
            this.tbIP4.Location = new System.Drawing.Point(239, 74);
            this.tbIP4.Name = "tbIP4";
            this.tbIP4.Size = new System.Drawing.Size(37, 27);
            this.tbIP4.TabIndex = 2;
            this.tbIP4.Text = "1";
            this.tbIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(110, 115);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(80, 27);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "8005";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(110, 180);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(166, 30);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Status :";
            // 
            // lbStatusConnection
            // 
            this.lbStatusConnection.AutoSize = true;
            this.lbStatusConnection.Location = new System.Drawing.Point(106, 290);
            this.lbStatusConnection.Name = "lbStatusConnection";
            this.lbStatusConnection.Size = new System.Drawing.Size(110, 19);
            this.lbStatusConnection.TabIndex = 0;
            this.lbStatusConnection.Text = "Not connected";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(358, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Client settings";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(358, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 19);
            this.label13.TabIndex = 1;
            this.label13.Text = "Name :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(430, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Evgen S";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(684, 432);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 470);
            this.MinimumSize = new System.Drawing.Size(700, 470);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegMail";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker pickDate;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTags;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoadMailList;
        private System.Windows.Forms.TextBox tbMailList;
        private System.Windows.Forms.Button btnClearMailList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbIP4;
        private System.Windows.Forms.TextBox tbIP3;
        private System.Windows.Forms.TextBox tbIP2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbIP1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbStatusConnection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
    }
}

