using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Models
{
    public sealed class EmailSettings
    {
        public Email Email { get; set; }
    }

    public class Email
    {
        public string MailTo { get; set; }
        public string MailFrom { get; set; }
        public string PasswordMailFrom { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
