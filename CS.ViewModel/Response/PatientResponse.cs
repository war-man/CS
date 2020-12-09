using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class PatientResponse
    {
        public int Total { get; set; }
        public List<Patient> Data { get; set; }
    }
}
