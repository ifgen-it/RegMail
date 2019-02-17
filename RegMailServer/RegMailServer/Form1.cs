using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegMailServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tbLog.Text = "";

            // HANDLERS

            btnStartServer.Click += BtnStartServer_Click;
            btnClearLog.Click += BtnClearLog_Click;
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            tbLog.Text = "";
        }
        
        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            string res = "";
            if (StartServer())
            {
                res = "Server started";
            }
            else
            {
                res = "Server cannot start";
            }
            SetInfo(res);
            AddLog(res);
        }


        // MY METHODS

        private bool StartServer()
        {
            return false;
        }

        private void SetInfo(string text)
        {
            lbInfo.Text = text;
        }

        private void AddLog(string text)
        {
            string log = DateTime.Now + " " + text + "\n";
            tbLog.AppendText(log);
        }
    }
}
