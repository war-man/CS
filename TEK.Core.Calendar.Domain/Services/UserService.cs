using AutoMapper;
using CS.VM.Response;
using CS.VM.Request;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using CS.EF.Models;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TEK.Core.Calendar.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Authenticate(AuthenticateRequest model)
        {
            var user = await _unitOfWork.GetRepository<User>().FindAsync(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return token;
        }

        public async Task<User> GetUserByID(string id)
        {
            var user = await _unitOfWork.GetRepository<User>().FindAsync(x => x.Id.ToLower() == id.ToLower());

            return user;
        }

        public async Task<User> LogIn(AuthenticateRequest request)
        {
            var user = await _unitOfWork.GetRepository<User>().FindAsync(x => x.Username == request.Username && x.Password == x.Password);

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _unitOfWork.GetRepository<User>().GetAll().ToListAsync();

            return users;
        }

        public async Task<User> AddNewUser(AddNewUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.Id = newUserID();
            _unitOfWork.GetRepository<User>().Add(user);
            await _unitOfWork.CommitAsync();
            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var s = await _unitOfWork.GetRepository<User>().FindAsync(x => x.Id == user.Id);

            if (s != null)
            {
                s.FirstName = user.FirstName;
                s.LastName = user.LastName;
                s.Birthday = user.Birthday;
                s.Phone = user.Phone;
                s.IsActive = user.IsActive;
                s.Address = user.Address;
                s.Username = user.Username;
                s.Password = user.Password;
                s.Role = user.Role;
                await _unitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        private string GenerateJwtToken(User user)
        {
            var mySecret = "2504166E48DC19294B86773F798DEE7996D3973E";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "http://mysite1.com";
            var myAudience = "http://myaudience1.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,(user.FirstName + " " + user.LastName).ToString()),
                    new Claim(ClaimTypes.MobilePhone,user.Phone.ToString()),
                    new Claim(ClaimTypes.DateOfBirth,user.Birthday.ToString()),
                    new Claim(ClaimTypes.Role,user.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("2504166E48DC19294B86773F798DEE7996D3973E");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "id").Value.ToString();

                // return account id from JWT token if validation successful
                return accountId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        private string newUserID()
        {
            int cc = _unitOfWork.GetRepository<User>().GetAll().Count();
            if (cc < 9)
            {
                return "US00" + (cc + 1);
            }
            return "US0" + (cc + 1);
        }
    }
}
