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
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace RegMailClient
{
    public partial class Form1 : Form
    {

        static int serverPort = 8005;
        static string serverAddress = "127.0.0.1";
        Socket socket = null;
        string clientName = null;
        Thread threadClientSocketListener = null;
        bool wasDisconnected = false;

        delegate void StringArgReturningVoidDelegate(string text);

        public Form1()
        {
            InitializeComponent();

            tbMailList.Text = "";
            btnDisconnect.Enabled = false;
            btnLoadMail.Enabled = false;
            btnSubmit.Enabled = false;

            // HANDLERS

            btnSubmit.Click += BtnSubmit_Click;
            btnClearMail.Click += BtnClearMailList_Click;
            btnLoadMail.Click += BtnLoadMailList_Click;
            btnConnect.Click += BtnConnect_Click;
            btnDisconnect.Click += BtnDisconnect_Click;

        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectServer();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (ConnectServer())
            {
                lbStatusConnection.Text = "Connected";
                lbStatusConnection.ForeColor = Color.Green;
            }
            else
            {
                lbStatusConnection.Text = "Cannot connect";
                lbStatusConnection.ForeColor = Color.Red;
            }
        }

        private void BtnLoadMailList_Click(object sender, EventArgs e)
        {
            LoadMail();
        }

        private void BtnClearMailList_Click(object sender, EventArgs e)
        {
            tbMailList.Text = "";
            SetInfo("Cleared");
        }


        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Sumbit();
        }


        // MY METHODS

        private void Sumbit()
        {
            if (!CheckInputs())
            {
                SetInfo("Input required fields: Title, To, From, Message");
                return;
            }
            Mail newMail = CreateMail();
            List<Mail> newListMail = new List<Mail> { newMail };
            string command = "INSERT";
            Console.WriteLine(newMail);

            SendPackage(new Package(command, newListMail));
            ClearInputs();
            
            
        }

        private void SendPackage(Package pack)
        {
            try
            {

                byte[] package = pack.ToXMLByteArray();
                socket.Send(package);

               
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }

        }

        private bool CheckInputs()
        {
            if (!tbTitle.Text.Equals("") && !tbTo.Text.Equals("") && !tbFrom.Text.Equals("") && !tbMessage.Text.Equals(""))
            {
                return true;
            }
            else return false;
        }

        private void SetInfo(string text)
        {
            if (lbInfo.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetInfo);
                Invoke(d, new object[] { text });
            }
            else
            {
                lbInfo.Text = text;
            }
        }

        private void SetMailList(string text)
        {
            if (tbMailList.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetMailList);
                Invoke(d, new object[] { text });
            }
            else
            {
                tbMailList.Text = text;
            }
        }

        private void SetSocketStatus(string text)
        {
            if (lbStatusConnection.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetSocketStatus);
                Invoke(d, new object[] { text });
            }
            else
            {
                lbStatusConnection.Text = text;
                lbStatusConnection.ForeColor = Color.Red;

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                Console.WriteLine("Socket status : " + socket.Connected);

                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                btnLoadMail.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }



        private Mail CreateMail()
        {
            Mail m1 = new Mail();
            m1.title = tbTitle.Text;
            m1.to = tbTo.Text;
            m1.from = tbFrom.Text;
            m1.message = tbMessage.Text;
            m1.date = pickDate.Value;

            if (tbTags.Equals(""))
            {
                m1.tags = null;
            }
            else
            {
                m1.tags = new List<string>();

                string strTags = tbTags.Text;
                char[] separators = { ' ', ',', '.', ';', ':' };
                string[] arrTags = strTags.Split(separators);
                for (int i = 0; i < arrTags.Length; i++)
                {
                    string temp = arrTags[i].Trim();
                    if (!temp.Equals(""))
                    {
                        m1.tags.Add(temp);
                    }
                }
                if (m1.tags.Count == 0)
                {
                    m1.tags = null;
                }
            }
            return m1;
        }

        private void ClearInputs()
        {
            tbTitle.Text = "";
            tbTo.Text = "";
            tbFrom.Text = "";
            tbTags.Text = "";
            tbMessage.Text = "";
            pickDate.Value = DateTime.Now;
        }

        private void LoadMail()
        {
            tbMailList.Text = "";
            string command = "GETALLMAIL";
            Package newPackage = new Package();
            newPackage.command = command;
            SendPackage(newPackage);
            
        }

        private void ConfigServer()
        {
            string ip1 = tbIP1.Text.Trim();
            string ip2 = tbIP2.Text.Trim();
            string ip3 = tbIP3.Text.Trim();
            string ip4 = tbIP4.Text.Trim();
            serverPort = int.Parse(tbPort.Text.Trim());
            clientName = tbClientName.Text.Trim();

            serverAddress = ip1 + "." + ip2 + "." + ip3 + "." + ip4;
        }

        private bool ConnectServer()
        {
            ConfigServer();
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(serverAddress), serverPort);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);

                wasDisconnected = false;
                threadClientSocketListener = new Thread(clientSocketListener);
                threadClientSocketListener.Start();

                SendName();
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnLoadMail.Enabled = true;
                btnSubmit.Enabled = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SetInfo(ex.Message);
                return false;
            }
        }

        private void SendName()
        {
            string command = "RENAME";
            Package newPackage = new Package();
            newPackage.command = command;
            newPackage.info = clientName;
            SendPackage(newPackage);

        }

        private void DisconnectServer()
        {
            string command = "DISCONNECT";
            Package newPackage = new Package();
            newPackage.command = command;
            SendPackage(newPackage);

            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            btnLoadMail.Enabled = false;
            btnSubmit.Enabled = false;
        }

        private void clientSocketListener()
        {
            try
            {

                while (true)
                {
                    if (wasDisconnected)
                    {
                        Console.WriteLine("was disconnected : " + wasDisconnected);
                        break;
                    }

                    Thread.Sleep(100);

                    // GET THE MESSAGE
                    int bytes = 0;
                    byte[] data = new byte[256];
                    List<byte> reciever = new List<byte>();
                    do
                    {
                        bytes = socket.Receive(data);
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
                    } while (socket.Available > 0);

                    byte[] answer = reciever.ToArray();
                    Package answerPackage = Package.XMLByteArrayToPackage(answer);

                    if (answerPackage.command.Equals("TEXT"))
                    {
                        Console.WriteLine("Server says: " + answerPackage.info);
                        SetInfo(answerPackage.info);
                    }

                    else if (answerPackage.command.Equals("ALLMAIL"))
                    {
                        Console.WriteLine("Server says: " + answerPackage.info);
                        SetInfo(answerPackage.info);

                        List<Mail> mailDb = answerPackage.body;
                        StringBuilder text = new StringBuilder();
                        for (int i = 0; i < mailDb.Count; i++)
                        {
                            text.Append(mailDb[i].ToString());
                        }
                        SetMailList(text.ToString());
                    }

                    else if (answerPackage.command.Equals("DISCONNECTED"))
                    {
                        Console.WriteLine("Server says: " + answerPackage.info);
                        SetInfo(answerPackage.info);

                        SetSocketStatus("Disconnected");
                        wasDisconnected = true;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
