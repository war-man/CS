using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Patient", Schema = "public")]
    public class Patient
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("address")]
        public string Address { get; set; }
    }
}
