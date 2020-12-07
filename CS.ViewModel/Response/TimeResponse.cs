using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class TimeResponse
    {
        public int Total { get; set; }
        public List<Time> Data { get; set; }
    }
}
