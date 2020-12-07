using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class EmailSender
    {
        public string FromMail { get; set; }
        public string FromMailPassword { get; set; }
        public string ToMail { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
