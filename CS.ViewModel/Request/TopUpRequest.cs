using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class TopUpRequest
    {
        public int CardNumber { get; set; }
        public int Money { get; set; }
    }
}
