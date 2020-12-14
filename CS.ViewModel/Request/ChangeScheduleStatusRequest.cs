using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class ChangeScheduleStatusRequest
    {
        public string Id { get; set; }
        public int Status { get; set; }
    }
}
