using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class AddShiftRequest
    {
        public string RoomId { get; set; }
        public string DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string TimeId { get; set; }
    }
}
