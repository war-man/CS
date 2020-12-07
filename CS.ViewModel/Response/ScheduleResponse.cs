using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class ScheduleResponse
    {
        public int Total { get; set; }
        public List<Schedule> Data { get; set; }
    }
}
