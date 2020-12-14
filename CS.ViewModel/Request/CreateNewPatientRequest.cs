using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class CreateNewPatientRequest
    { 
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
