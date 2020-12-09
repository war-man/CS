using CS.EF.Models;
using CS.VM.Request;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface ICardService
    {
        Task<Card> GetCardByPatientId(string patientId);
        Task<Card> CreateNewCard(CreateCardRequest createCardRequest);
        Task<Card> TopUp(TopUpRequest topUpRequest);
        Task<Card> ReturnCard(int CardNumber);
        //Task<Card> ChangeCard(int CardNumber);
        Task<Card> BlockCard(int CardNumber);
    }
}
