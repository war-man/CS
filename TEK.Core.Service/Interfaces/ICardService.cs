using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface ICardService
    {
        Task<CardResponse> GetAllCards();
        Task<PatientResponse> GetAllPatients();
        Task<Patient> AddNewPatient(AddNewPatientRequest request);
        Task<Card> GetCardByPatientId(string patientId);
        Task<Card> CreateNewCard(CreateCardRequest createCardRequest);
        Task<Card> TopUp(TopUpRequest topUpRequest);
        Task<ReturnCardResponse> ReturnCard(int CardNumber);
        Task<Card> ChangeCard(int CardNumber);
        Task<Card> BlockCard(int CardNumber);
        Task<List<AuditLog>> GetAllAuditLogs();
        Task<List<RevenueStatistic>> GetRevenueStatistics();
        Task<List<RevenueStatistic>> GetRevenueStatisticsByAction(string Action);
        Task<List<RevenueStatistic>> GetRevenueStatisticsByDate(DateTime Date);
        Task<List<RevenueStatistic>> GetRevenueStatisticsByActionAndDate(string Action, DateTime Date);
        Task<PatientCardResponse> GetFullPatientCard(PatientCardRequest patientCardRequest);
    }
}
