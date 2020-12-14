using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class ReturnCardResponse
    {
        public string Id { get; set; }
        public int CardNumber { get; set; }
        public int OldMoney { get; set; }
        public int Money { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string PatientId { get; set; }
        public int Status { get; set; }
    }
}
