using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Invoice", Schema = "public")]
    public class Invoice
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("schedule_id")]
        public string ScheduleId { get; set; }
        [Column("patient_id")]
        public string PatientId { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("cost")]
        public int Cost { get; set; }
        [Column("create_by")]
        public string CreateBy { get; set; }
        [Column("status")]
        public int Status { get; set; }
    }
}
