using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class DoctorResponse
    {
        public int Total { get; set; }
        public List<Doctor> Data { get; set; }
    }
}
