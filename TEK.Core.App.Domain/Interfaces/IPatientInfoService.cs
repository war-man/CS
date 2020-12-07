using CS.EF.Models;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPatientInfoService : IService<QueueNumber, IRepository<QueueNumber>>
    {
        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Task&lt;Patient&gt;.</returns>
        Task<Patient> GetByCode(string code);
    }
}
