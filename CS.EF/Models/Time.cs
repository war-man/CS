using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Time", Schema = "public")]
    public class Time
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("time")]
        public string ShiftTime { get; set; }
    }
}
