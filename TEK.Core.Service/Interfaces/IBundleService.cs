using CS.EF.Models;
using CS.VM.Request;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface IBundleService
    {
        Task<Bundle> UploadFile(AddOrUpdateVersionRequest request);
    }
}
