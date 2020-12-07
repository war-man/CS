using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("Room", Schema = "public")]
    public class Room
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
