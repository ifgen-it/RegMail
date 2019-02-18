﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace RegMailServer
{
    public partial class Form1 : Form
    {
        static int serverPort = 8005;
        static string localHost = "127.0.0.1";
        static int clientsCounter = 0;
        static Socket listenSocket;
        static bool socketFound = false;
        static Socket foundSocket;
        static List<Client> clients;


        delegate void StringArgReturningVoidDelegate(string text);


        public Form1()
        {
            InitializeComponent();

            tbLog.Text = "";
            tbClients.Text = "";


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
                lbServerStatus.Text = "SERVER IS RUNNING";
                lbServerStatus.ForeColor = Color.Red;
                tbClients.Text = "";
                tbKickClient.Text = "";

                Thread threadRunServer = new Thread(RunServer);
                threadRunServer.Start();
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

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, serverPort);
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);
                Thread threadListener = new Thread(socketListener);
                threadListener.Start();
                clients = new List<Client>();

                return true;
            }
            catch(Exception ex)
            {
                lbInfo.Text = ex.Message;
                return false;
            }
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

        private static void socketListener()
        {
            while (true)
            {
                Socket handler = listenSocket.Accept();
                socketFound = true;
                foundSocket = handler;
                Thread.Sleep(1000);
            }
        }

        private void RunServer()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (socketFound)
                {
                    Client newClient = new Client();
                    newClient.Socket = foundSocket;
                    newClient.Name = "Client " + newClient.Id.ToString();

                    clientsCounter++;
                    ShowClientsNames(newClient.Name);
                    

                    clients.Add(newClient);
                    foundSocket = null;
                    socketFound = false;
                }
            }
        }

        private void ShowClientsNames(string name)
        {
            if (tbClients.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(ShowClientsNames);
                Invoke(d, new object[] { name });
            }
            else
            {
                tbClients.AppendText(name);
            }
        }
    }
}
