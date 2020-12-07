using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.UoW.IService{CS.EF.Models.Application, TEK.Core.UoW.IRepository{CS.EF.Models.Application}}" />
    public interface IApplicationService : IService<Application, IRepository<Application>>
    {
        /// <summary>
        /// Adds the or update application.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<ApplicationViewModel> AddOrUpdateApplication(AddOrUpdateApplicationRequest request);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetApplicationResponse> GetAll(GetApplicationRequest request);
    }
}
