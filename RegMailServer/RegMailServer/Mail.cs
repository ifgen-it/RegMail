using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace RegMailServer
{
    public class Mail
    {
        public int id;
        public string title;
        public DateTime date;
        public string to;
        public string from;
        public List<string> tags;
        public string message;

        public Mail()
        {
            id = -1;
            title = null;
            date = DateTime.Today;
            to = null;
            from = null;
            tags = null;
            message = null;
        }

        public Mail(string Title, DateTime Date, string To, string From, List<string> Tags, string Message)
        {
            id = -1;
            title = Title;
            date = Date;
            to = To;
            from = From;
            tags = Tags;
            message = Message;
        }

        public override string ToString()
        {
            string br = "******************************************************************************";
            string allTags = "";
            if (tags != null)
            {
                for (int i = 0; i < tags.Count; i++)
                {
                    allTags += tags[i];
                    if (i < tags.Count - 1)
                    {
                        allTags += " ";
                    }
                }
            }

            StringBuilder res = new StringBuilder();
            res.Append(br);
            res.AppendLine();
            res.Append("Title : " + title);
            res.AppendLine();
            res.Append("Date : " + date.ToString("dd-MM-yyyy"));
            res.AppendLine();
            res.Append("To : " + to);
            res.AppendLine();
            res.Append("From : " + from);
            res.AppendLine();
            res.Append("Tags : " + allTags);
            res.AppendLine();
            res.Append("Message : " + message);
            res.AppendLine();

            return res.ToString();
        }

    }
}
