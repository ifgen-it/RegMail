using System;
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

        static List<Mail> mailDb;

        bool serverWasStopped = false;
        Thread threadListener = null;


        delegate void StringArgReturningVoidDelegate(string text);
        delegate void VoidArgReturningVoidDelegate();
        delegate void BoolArgReturningVoidDelegate(bool mode);


        public Form1()
        {
            InitializeComponent();

            tbLog.Text = "";
            tbClients.Text = "";
            btnStopServer.Enabled = false;
            SetKickButtons(false);

            mailDb = new List<Mail>();

            // HANDLERS

            btnStartServer.Click += BtnStartServer_Click;
            btnClearLog.Click += BtnClearLog_Click;
            btnKickAll.Click += BtnKickAll_Click;
            btnKickOne.Click += BtnKickOne_Click;
            btnStopServer.Click += BtnStopServer_Click;
        }

        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            KickAllClients();
            serverWasStopped = true;
            //threadListener.Interrupt();

            listenSocket.Dispose();
            
            //listenSocket.Shutdown(SocketShutdown.Both);
            //listenSocket.Close();

            lbServerStatus.Text = "SERVER IS SLEEPING";
            lbServerStatus.ForeColor = Color.Green;
            SetInfo("Server stopped");
            AddLog("Server stopped");

            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
        }

        private void BtnKickOne_Click(object sender, EventArgs e)
        {
            KickOneClient();
        }

        private void BtnKickAll_Click(object sender, EventArgs e)
        {
            KickAllClients();
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

                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;

                SetInfo(res);
                AddLog(res);
            }
            else
            {
                res = "Server cannot start";
                AddLog(res);
            }
            
        }


        // MY METHODS

        private bool StartServer()
        {
            try
            {
                serverPort = int.Parse(tbPort.Text.Trim());

                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, serverPort);
                listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);

                serverWasStopped = false;
                threadListener = new Thread(socketListener);
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

            if (tbLog.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(AddLog);
                Invoke(d, new object[] { text });
            }
            else
            {
                tbLog.AppendText(log);
            }
        }

        private void socketListener()
        {
            try
            {
                
                while (true)
                {
                    if (serverWasStopped)
                    {
                        Console.WriteLine("socketListener stopped");
                        break;
                    }
                    Socket handler = listenSocket.Accept();
                    socketFound = true;
                    foundSocket = handler;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RunServer()
        {
            while (true)
            {
                if (serverWasStopped)
                {
                    Console.WriteLine("RunServer stopped");
                    break;
                }
                Thread.Sleep(500);
                if (socketFound)
                {
                    Client newClient = new Client();
                    newClient.Socket = foundSocket;
                    newClient.Name = "Client " + newClient.Id.ToString();

                    clientsCounter++;
                    clients.Add(newClient);
                    foundSocket = null;
                    socketFound = false;
                    ShowClientsNames();

                    AddLog(newClient.Name + " was connected");

                    if (clients.Count == 1)
                    {
                        SetKickButtons(true);
                    }
                   
                }

                if (clients.Count > 0)
                {
                    // GET MESSAGE FROM ALL CLIENTS -- TRAVERSING ALL SOCKETS
                    for (int i = 0; i < clients.Count; i++)
                    {
                        if (clients[i].Socket.Available <= 0) continue;

                        // GET THE MESSAGE
                        int bytes = 0;
                        byte[] data = new byte[256];
                        List<byte> reciever = new List<byte>();
                        do
                        {
                            bytes = clients[i].Socket.Receive(data);
                            byte[] buffer = null;
                            if (bytes > 0)
                            {
                                buffer = new byte[bytes];
                                for (int j = 0; j < bytes; j++)
                                {
                                    buffer[j] = data[j];
                                }
                            }
                            reciever.AddRange(buffer);
                        } while (clients[i].Socket.Available > 0);

                        byte[] answer = reciever.ToArray();
                        Package package = Package.XMLByteArrayToPackage(answer);

                        // QUERY : INSERT INTO DB
                        if (package.command.Equals("INSERT"))
                        {
                            Mail mail = package.body[0];
                            mailDb.Add(mail);
                            Console.WriteLine("Package:\n" + mail.ToString());
                            
                            AddLog(clients[i].Name + " : " + package.command + new StringBuilder().AppendLine().ToString() + mail.ToString());

                            // SEND THE ANSWER
                            Package responsePackage = new Package();
                            responsePackage.command = "TEXT";
                            responsePackage.info = "Mail delivered";

                            byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                            clients[i].Socket.Send(byteResponsePackage);

                        }

                        // QUERY : GET ALL MAIL
                        else if (package.command.Equals("GETALLMAIL"))
                        {
                            
                            AddLog(clients[i].Name + " : " + package.command + new StringBuilder().AppendLine().ToString());

                            // SEND THE ANSWER
                            Package responsePackage = new Package();
                            responsePackage.command = "ALLMAIL";
                            if (mailDb.Count == 0)
                            {
                                responsePackage.info = "No mail on the server";
                            }
                            else
                            {
                                responsePackage.body = mailDb;
                                responsePackage.info = "All mails loaded";
                            }
                            

                            byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                            clients[i].Socket.Send(byteResponsePackage);
                        }

                        // QUERY : RENAME CLIENT
                        else if (package.command.Equals("RENAME"))
                        {
                            AddLog(clients[i].Name + " : " + package.command + new StringBuilder().AppendLine().ToString() + package.info);
                            clients[i].Name = package.info;
                            ShowClientsNames();

                            // SEND THE ANSWER
                            Package responsePackage = new Package();
                            responsePackage.command = "TEXT";
                            responsePackage.info = package.info + " successfully connected";

                            byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                            clients[i].Socket.Send(byteResponsePackage);

                        }

                        // QUERY : DISCONNECT CLIENT
                        else if (package.command.Equals("DISCONNECT"))
                        {
                            AddLog(clients[i].Name + " : " + package.command + new StringBuilder().AppendLine().ToString());


                            // SEND THE ANSWER
                            Package responsePackage = new Package();
                            responsePackage.command = "DISCONNECTED";
                            responsePackage.info = "You was disconnected";

                            byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                            clients[i].Socket.Send(byteResponsePackage);

                            //DISCONNECT
                            clients[i].Socket.Shutdown(SocketShutdown.Both);
                            clients[i].Socket.Close();
                            clients.RemoveAt(i);
                            ShowClientsNames();
                            if (clients.Count == 0)
                            {
                                SetKickButtons(false);
                            }
                            break;

                        }
                    }
                }
            }
        }

        private void ShowClientsNames()
        {
            if (tbClients.InvokeRequired)
            {
                VoidArgReturningVoidDelegate d = new VoidArgReturningVoidDelegate(ShowClientsNames);
                Invoke(d);
            }
            else
            {
                tbClients.Text = "";
                for (int i = 0; i < clients.Count; i++)
                {
                    tbClients.AppendText(clients[i].Name + "\n");
                }  
            }
        }

        private void SetKickButtons(bool mode)
        {
            if (btnKickAll.InvokeRequired || btnKickOne.InvokeRequired)
            {
                BoolArgReturningVoidDelegate d = new BoolArgReturningVoidDelegate(SetKickButtons);
                Invoke(d, new object[] { mode });
            }
            else
            {

                if (mode)
                {
                    btnKickOne.Enabled = true;
                    btnKickAll.Enabled = true;
                }
                else
                {
                    btnKickOne.Enabled = false;
                    btnKickAll.Enabled = false;
                }
            }
        }

        private void KickAllClients()
        {
            while (clients.Count != 0)
            {
                Client delClient = clients[0];

                AddLog(clients[0].Name + " was kicked");

                // SEND THE ANSWER
                Package responsePackage = new Package();
                responsePackage.command = "DISCONNECTED";
                responsePackage.info = "You was kicked";

                byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                clients[0].Socket.Send(byteResponsePackage);

                delClient.Socket.Shutdown(SocketShutdown.Both);
                delClient.Socket.Close();
                clients.RemoveAt(0);
                ShowClientsNames();
            }
            SetKickButtons(false);
            SetInfo("All clients was kicked");
        }

        private void KickOneClient()
        {
            string delClientName = tbKickClient.Text.Trim();

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Name.Equals(delClientName))
                {
                    AddLog(clients[i].Name + " was kicked");
                    SetInfo(clients[i].Name + " was kicked");

                    // SEND THE ANSWER
                    Package responsePackage = new Package();
                    responsePackage.command = "DISCONNECTED";
                    responsePackage.info = "You was kicked";

                    byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                    clients[i].Socket.Send(byteResponsePackage);


                    clients[i].Socket.Shutdown(SocketShutdown.Both);
                    clients[i].Socket.Close();
                    clients.RemoveAt(i);
                    ShowClientsNames();
                }
            }
            if (clients.Count == 0)
            {
                SetKickButtons(false);
            }
        }
    }
}
