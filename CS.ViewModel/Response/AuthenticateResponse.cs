using CS.EF.Models;
using System.Text.Json.Serialization;

namespace CS.VM.Response
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string JwtToken { get; set; }

        public AuthenticateResponse(User user, string jwtToken)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Role = user.Role;
            JwtToken = jwtToken;
        }
    }
}
