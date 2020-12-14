using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Schedule", Schema = "public")]
    public class Schedule
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("shift_id")]
        public string ShiftId { get; set; }
        [Column("patient_id")]
        public string PatientId { get; set; }
        [Column("order")]
        public int Order { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("BHYT")]
        public bool BHYT { get; set; }
    }
}
