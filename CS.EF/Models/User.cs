using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace CS.EF.Models
{
    [Table("User", Schema = "public")]
    public class User
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("gender")]
        public bool Gender { get; set; }
        [Column("birthday")]
        public DateTime? Birthday { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        [Column("is_approve")]
        public bool IsApprove { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        [JsonIgnore]
        public string Password { get; set; }
        [Column("role")]
        [JsonIgnore]
        public string Role { get; set; }
    }
}
