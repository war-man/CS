using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class CreateCardRequest
    {
        public int Money { get; set; }
        public string PatientId { get; set; }
    }
}
