using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class PatientCardRequest
    {
        public string PatientId { get; set; }
        public int CardNumber { get; set; } = 0;
    }
}
