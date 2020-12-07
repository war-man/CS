using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Doctor", Schema = "public")]
    public class Doctor
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}
