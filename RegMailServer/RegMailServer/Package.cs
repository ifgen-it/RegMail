using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace RegMailServer
{
    public class Package
    {
        public string command;
        public string info;
        public List<Mail> body;

        public Package()
        {
            command = null;
            info = null;
            body = null;
        }

        public Package(string Command, List<Mail> Body)
        {
            command = Command;
            body = Body;
            info = null;
        }

        public byte[] ToXMLByteArray()
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(Package));
            using (var ms = new MemoryStream())
            {
                xmlSer.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public static Package XMLByteArrayToPackage(byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(Package));
                ms.Write(bytes, 0, bytes.Length);
                ms.Seek(0, SeekOrigin.Begin);
                Package pack = (Package)xmlSer.Deserialize(ms);
                return pack;
            }
        }
    }
}
