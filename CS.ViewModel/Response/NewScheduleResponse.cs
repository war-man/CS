using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class NewScheduleResponse
    {
        public string Id { get; set; }



        public string PatientId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }



        public string Room { get; set; }
        public string Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }



        public int Order { get; set; }
        public int Status { get; set; }
        public bool BHYT { get; set; }
    }
}
