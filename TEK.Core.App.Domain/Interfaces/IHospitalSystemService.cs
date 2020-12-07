using System.Threading.Tasks;
using TEK.Gateway.Domain.BusinessObjects;

namespace TEK.Payment.Domain.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHospitalSystemService
    {
        /// <summary>
        /// Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetRawClinicListResponse> GetRawClinicList(GetRawClinicListRequest request);

        /// <summary>
        /// Gets the raw patient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetRawPatientResponse> GetRawPatient(GetRawPatientRequest request);
    }
}
