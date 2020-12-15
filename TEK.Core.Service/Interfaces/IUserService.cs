using CS.VM.Request;
using CS.VM.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
