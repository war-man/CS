using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Shift", Schema = "public")]
    public class Shift
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("room_id")]
        public string RoomId { get; set; }
        [Column("doctor_id")]
        public string DoctorId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("time_id")]
        public string TimeId { get; set; }
    }
}
