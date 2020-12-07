using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    public interface IVersionService : IService<Version, IRepository<Version>>
    {
        /// <summary>
        /// Adds the or update version.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<VersionViewModel> AddOrUpdateVersion(AddOrUpdateVersionRequest request);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetVersionResponse> GetAll(GetVersionRequest request);
    }
}
