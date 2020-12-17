using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class AddNewUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsApprove { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
