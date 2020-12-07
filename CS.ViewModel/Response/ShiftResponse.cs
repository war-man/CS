using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class ShiftResponse
    {
        public int Total { get; set; }
        public List<Shift> Data { get; set; }
    }
}
