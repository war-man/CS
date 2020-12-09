using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Card", Schema = "public")]
    public class Card
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("card_number")]
        public int CardNumber { get; set; }
        [Column("money")]
        public int Money { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("expired_date")]
        public DateTime ExpiredDate { get; set; }
        [Column("patient_id")]
        public string PatientId { get; set; }
        [Column("status")]
        public string Status { get; set; }
    }
}
