using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace RegMailServer
{
    class Client
    {
        private static int idCounter = 0;

        public Socket Socket { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }


        public Client()
        {
            Socket = null;
            Name = null;
            Id = ++idCounter;

        }

    }
}
