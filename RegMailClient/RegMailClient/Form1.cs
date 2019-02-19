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
        bool wasConnected = false;



        public Form1()
        {
            InitializeComponent();

            tbMailList.Text = "";

            // HANDLERS

            btnSubmit.Click += BtnSubmit_Click;
            btnClearMailList.Click += BtnClearMailList_Click;
            btnLoadMailList.Click += BtnLoadMailList_Click;
            btnConnect.Click += BtnConnect_Click;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (ConnectServer())
            {
                lbStatusConnection.Text = "Connected";
                lbStatusConnection.ForeColor = Color.Green;
                wasConnected = true;
            }
            else
            {
                lbStatusConnection.Text = "Cannot connect";
                lbStatusConnection.ForeColor = Color.Red;
            }
        }

        private void BtnLoadMailList_Click(object sender, EventArgs e)
        {
            LoadMailList();
        }

        private void BtnClearMailList_Click(object sender, EventArgs e)
        {
            tbMailList.Text = "";
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
            Console.WriteLine(newMail);

            //tbMailList.AppendText(newMail.ToString());
            SendMail(newMail);
            //SetInfo("Mail submited");
            ClearInputs();
            
            
        }

        private void SendMail(Mail mail)
        {
            byte[] package = mail.ToXMLByteArray();
            socket.Send(package);

            // WAIT ANSWER
            byte[] data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            } while (socket.Available > 0);

            Console.WriteLine("Server says: " + builder.ToString());
            SetInfo(builder.ToString());

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
            lbInfo.Text = text;
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

        private void LoadMailList()
        {

        }

        private bool ConnectServer()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(serverAddress), serverPort);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SetInfo(ex.Message);
                return false;
            }
        }

       
    }
}
