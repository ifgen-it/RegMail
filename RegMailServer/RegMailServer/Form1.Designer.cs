namespace RegMailServer
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
            this.tbKickClient = new System.Windows.Forms.TextBox();
            this.tbClients = new System.Windows.Forms.TextBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnKickAll = new System.Windows.Forms.Button();
            this.btnKickOne = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbServerStatus = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.lbServerStatus);
            this.tabPage1.Controls.Add(this.tbKickClient);
            this.tabPage1.Controls.Add(this.tbClients);
            this.tabPage1.Controls.Add(this.btnStopServer);
            this.tabPage1.Controls.Add(this.btnKickAll);
            this.tabPage1.Controls.Add(this.btnKickOne);
            this.tabPage1.Controls.Add(this.btnStartServer);
            this.tabPage1.Controls.Add(this.tbPort);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.ForeColor = System.Drawing.Color.Blue;
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Control";
            // 
            // tbKickClient
            // 
            this.tbKickClient.Location = new System.Drawing.Point(393, 271);
            this.tbKickClient.Name = "tbKickClient";
            this.tbKickClient.Size = new System.Drawing.Size(201, 27);
            this.tbKickClient.TabIndex = 6;
            this.tbKickClient.Text = "Kicked Client";
            // 
            // tbClients
            // 
            this.tbClients.BackColor = System.Drawing.Color.White;
            this.tbClients.Location = new System.Drawing.Point(393, 85);
            this.tbClients.Multiline = true;
            this.tbClients.Name = "tbClients";
            this.tbClients.ReadOnly = true;
            this.tbClients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbClients.Size = new System.Drawing.Size(201, 148);
            this.tbClients.TabIndex = 3;
            this.tbClients.TabStop = false;
            this.tbClients.Text = "Client1\r\nClient2\r\n";
            // 
            // btnStopServer
            // 
            this.btnStopServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStopServer.Location = new System.Drawing.Point(36, 135);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(293, 32);
            this.btnStopServer.TabIndex = 3;
            this.btnStopServer.Text = "Stop";
            this.btnStopServer.UseVisualStyleBackColor = true;
            // 
            // btnKickAll
            // 
            this.btnKickAll.ForeColor = System.Drawing.Color.Black;
            this.btnKickAll.Location = new System.Drawing.Point(36, 267);
            this.btnKickAll.Name = "btnKickAll";
            this.btnKickAll.Size = new System.Drawing.Size(139, 32);
            this.btnKickAll.TabIndex = 4;
            this.btnKickAll.Text = "Kick all clients";
            this.btnKickAll.UseVisualStyleBackColor = true;
            // 
            // btnKickOne
            // 
            this.btnKickOne.ForeColor = System.Drawing.Color.Black;
            this.btnKickOne.Location = new System.Drawing.Point(190, 267);
            this.btnKickOne.Name = "btnKickOne";
            this.btnKickOne.Size = new System.Drawing.Size(139, 32);
            this.btnKickOne.TabIndex = 5;
            this.btnKickOne.Text = "Kick one client";
            this.btnKickOne.UseVisualStyleBackColor = true;
            // 
            // btnStartServer
            // 
            this.btnStartServer.ForeColor = System.Drawing.Color.Green;
            this.btnStartServer.Location = new System.Drawing.Point(36, 85);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(293, 32);
            this.btnStartServer.TabIndex = 2;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPort.ForeColor = System.Drawing.Color.Blue;
            this.tbPort.Location = new System.Drawing.Point(89, 42);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(73, 27);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "8005";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(389, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Connected clients :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(33, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnClearLog);
            this.tabPage2.Controls.Add(this.tbLog);
            this.tabPage2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ForeColor = System.Drawing.Color.Blue;
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(652, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.ForeColor = System.Drawing.Color.Black;
            this.btnClearLog.Location = new System.Drawing.Point(14, 20);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(135, 29);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.AcceptsReturn = true;
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLog.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLog.ForeColor = System.Drawing.Color.Blue;
            this.tbLog.Location = new System.Drawing.Point(3, 69);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(646, 253);
            this.tbLog.TabIndex = 2;
            this.tbLog.Text = "Here will be server log\r\nИ сообщения юзеров\r\n";
            this.tbLog.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(48, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Info : ";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbInfo.Location = new System.Drawing.Point(101, 390);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(164, 19);
            this.lbInfo.TabIndex = 1;
            this.lbInfo.Text = "Welcome to the Server";
            // 
            // lbServerStatus
            // 
            this.lbServerStatus.AutoSize = true;
            this.lbServerStatus.ForeColor = System.Drawing.Color.Green;
            this.lbServerStatus.Location = new System.Drawing.Point(183, 45);
            this.lbServerStatus.Name = "lbServerStatus";
            this.lbServerStatus.Size = new System.Drawing.Size(146, 19);
            this.lbServerStatus.TabIndex = 5;
            this.lbServerStatus.Text = "SERVER IS SLEEPING";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(684, 432);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 470);
            this.MinimumSize = new System.Drawing.Size(700, 470);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegMail Server";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TextBox tbKickClient;
        private System.Windows.Forms.TextBox tbClients;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnKickAll;
        private System.Windows.Forms.Button btnKickOne;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lbServerStatus;
    }
}

