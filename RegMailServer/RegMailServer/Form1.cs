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
using System.Configuration;
using System.Data.SqlClient;


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

        bool dbConnected = false;
        SqlConnection connection = null;


        delegate void StringArgReturningVoidDelegate(string text);
        delegate void VoidArgReturningVoidDelegate();
        delegate void BoolArgReturningVoidDelegate(bool mode);


        public Form1()
        {
            InitializeComponent();

            tbLog.Text = "";
            tbClients.Text = "";
            tbKickClient.Text = "";
            btnStopServer.Enabled = false;
            SetKickButtons(false);

            btnDisconnectDb.Enabled = false;

            mailDb = new List<Mail>();

            // HANDLERS

            btnStartServer.Click += BtnStartServer_Click;
            btnClearLog.Click += BtnClearLog_Click;
            btnKickAll.Click += BtnKickAll_Click;
            btnKickOne.Click += BtnKickOne_Click;
            btnStopServer.Click += BtnStopServer_Click;
            btnConnectDb.Click += BtnConnectDb_Click;
            btnDisconnectDb.Click += BtnDisconnectDb_Click;
        }

        private void BtnDisconnectDb_Click(object sender, EventArgs e)
        {
            DbDisconnect();
        }

        private void BtnConnectDb_Click(object sender, EventArgs e)
        {
            // получаем строку подключения
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Console.WriteLine(connectionString);

            // Создание подключения
            connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");

                SetInfo("Database connection opened");
                AddLog("Database connection opened");
                lbStatus.Text = "Status : Connected";
                lbStatus.ForeColor = Color.Green;
                dbConnected = true;
                btnDisconnectDb.Enabled = true;
                btnConnectDb.Enabled = false;

                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);
                Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                SetInfo(ex.Message);
            }
            
        }

        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            StopServer();
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

                btnConnectDb.Enabled = false;
                btnDisconnectDb.Enabled = false;

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
            string log = DateTime.Now + " " + text + new StringBuilder().AppendLine().ToString();

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

                            if (dbConnected)
                            {
                                bool res = DbInsert(mail);
                                Console.WriteLine(res);
                            }
                            else
                            {
                                mailDb.Add(mail);
                            }

                            Console.WriteLine("Package:\n" + mail.ToString());
                            
                            AddLog(clients[i].Name + " : " + package.command + " : " + new StringBuilder().AppendLine().ToString() + mail.ToString());

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
                            
                            AddLog(clients[i].Name + " : " + package.command);

                            // SEND THE ANSWER
                            Package responsePackage = new Package();
                            responsePackage.command = "ALLMAIL";

                            if (dbConnected)
                            {
                                List<Mail> result = DbGetAllMail();
                                if (result.Count == 0)
                                {
                                    responsePackage.info = "No mail on the server";
                                }
                                else
                                {
                                    responsePackage.body = result;
                                    responsePackage.info = "All mails loaded";
                                }
                                
                            }
                            else
                            {
                                if (mailDb.Count == 0)
                                {
                                    responsePackage.info = "No mail on the server";
                                }
                                else
                                {
                                    responsePackage.body = mailDb;
                                    responsePackage.info = "All mails loaded";
                                }
                            }

                            byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                            clients[i].Socket.Send(byteResponsePackage);
                        }

                        // QUERY : RENAME CLIENT
                        else if (package.command.Equals("RENAME"))
                        {
                            AddLog(clients[i].Name + " : " + package.command + " : " + new StringBuilder().AppendLine().ToString() + package.info);
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
                            AddLog(clients[i].Name + " : " + package.command);


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
            if (clients == null)
            {
                return;
            }

            while (clients.Count != 0)
            {
                Client delClient = clients[0];

                AddLog(clients[0].Name + " was kicked");

                // SEND THE ANSWER
                Package responsePackage = new Package();
                responsePackage.command = "DISCONNECTED";
                responsePackage.info = "You was kicked";

                byte[] byteResponsePackage = responsePackage.ToXMLByteArray();
                try
                {
                    clients[0].Socket.Send(byteResponsePackage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

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
            if (clients == null)
            {
                return;
            }

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
                    try
                    {
                        clients[i].Socket.Send(byteResponsePackage);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

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

        private bool DbInsert(Mail mail)
        {
            bool result = false;

            try
            {
                string strTags = "";
                if (mail.tags == null)
                {
                    strTags = "NULL";
                }
                else
                {
                    foreach (var item in mail.tags)
                    {
                        strTags += item + " ";
                    }
                    strTags.Trim();
                    strTags = "'" + strTags + "'";
                    Console.WriteLine(strTags);
                }

                string strDate = mail.date.ToString("yyyy-MM-dd HH:mm:ss");
                string strDateDb = string.Format("CONVERT(DATETIME, '{0}', 20)", strDate);   // гггг - мм - дд чч: ми: сс

                string sqlExpression = string.Format("INSERT INTO mail1(title, date, mail_to, mail_from, tags, message) VALUES('{0}', {1}, '{2}', '{3}', {4}, '{5}')",
                mail.title, strDateDb, mail.to, mail.from, strTags, mail.message);

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);

                if (number == 1)
                {
                    result = true;
                }
                else result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               // SetInfo(ex.Message);
            }            
            return result;  
        }

        private List<Mail> DbGetAllMail()
        {
            List<Mail> allMail = new List<Mail>();

            try
            {
                string sqlExpression = "SELECT * FROM mail1";
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                        reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5), reader.GetName(6));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object title = reader.GetValue(1);
                        object date = reader.GetValue(2);
                        object to = reader.GetValue(3);
                        object from = reader.GetValue(4);
                        object strTags = reader.GetValue(5);
                        object message = reader.GetValue(6);

                        
                        Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6}", id, title, date, to, from, strTags, message);

                        Mail m1 = CreateMail(id, title, date, to, from, strTags, message);
                        allMail.Add(m1);

                    }
                    Console.WriteLine();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SetInfo(ex.Message);
            }
            return allMail;
        }

        private Mail CreateMail(object id, object title, object date, object to, object from, object strDbTags, object message)
        {
            Mail m1 = new Mail();
            m1.id = (int)id;
            m1.title = (string)title;
            m1.to = (string)to;
            m1.from = (string)from;
            m1.message = (string)message;
            m1.date = (DateTime)date;

            string tags = strDbTags as string;


            if (tags == null || tags.Equals(""))
            {
                m1.tags = null;
                Console.WriteLine("m1 tags is null");
            }
            else
            {
                m1.tags = new List<string>();

                string strTags = tags;
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

        private void DbDisconnect()
        {
            // закрываем подключение
            connection.Close();
            Console.WriteLine("Подключение закрыто...");
            SetInfo("Database connection closed");
            AddLog("Database connection closed");
            lbStatus.Text = "Status : Disconnected";
            lbStatus.ForeColor = Color.Red;
            dbConnected = false;
            btnDisconnectDb.Enabled = false;
            btnConnectDb.Enabled = true;
        }

        private void StopServer()
        {
            KickAllClients();
            serverWasStopped = true;
            //threadListener.Interrupt();
            if (listenSocket != null)
            {
                listenSocket.Dispose();
            }

            //listenSocket.Shutdown(SocketShutdown.Both);
            //listenSocket.Close();

            lbServerStatus.Text = "SERVER IS SLEEPING";
            lbServerStatus.ForeColor = Color.Green;
            SetInfo("Server stopped");
            AddLog("Server stopped");

            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;

            if (dbConnected)
            {
                btnDisconnectDb.Enabled = true;
            }
            else
            {
                btnConnectDb.Enabled = true;
            }
        }

        private void ExitApp()
        {
            StopServer();

            if (dbConnected)
            {
                DbDisconnect();
            }
        }
    }
}
