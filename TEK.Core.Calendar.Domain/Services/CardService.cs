using AutoMapper;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Core.Calendar.Domain.Services
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Card> GetCardByPatientId(string patientId)
        {
            var s = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.PatientId == patientId);

            return s;
        }

        public async Task<Card> CreateNewCard(CreateCardRequest createCardRequest)
        {
            var s = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.PatientId == createCardRequest.PatientId);

            var p = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == createCardRequest.PatientId);

            if (s != null)
                throw new Exception("Bệnh nhân đã có thẻ");

            if (p == null)
                throw new Exception("Bệnh nhân không tồn tại trong hệ thống");

            var card = new Card
            {
                Id = newCardID(),
                CardNumber = newCardNumber(),
                Money = createCardRequest.Money,
                CreatedDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddYears(1),
                PatientId = createCardRequest.PatientId,
                Status = 1
            };

            _unitOfWork.GetRepository<Card>().Add(card);
            await _unitOfWork.CommitAsync();
            return card;
        }

        public async Task<Card> TopUp(TopUpRequest topUpRequest)
        {
            var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == topUpRequest.CardNumber && x.Status == 1);

            if (card == null) throw new Exception("Thẻ không tồn tại hoặc bị từ chối");

            card.Money += topUpRequest.Money;
            card.ExpiredDate = DateTime.Now.AddYears(1);

            _unitOfWork.GetRepository<Card>().Update(card);
            await _unitOfWork.CommitAsync();

            return card;
        }

        public async Task<ReturnCardResponse> ReturnCard(int CardNumber)
        {
            var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == CardNumber);

            if (card == null) throw new Exception("Thẻ không tồn tại");

            var cardResponse = new ReturnCardResponse
            {
                Id = card.Id,
                CardNumber = card.CardNumber,
                OldMoney = card.Money,
                Money = 0,
                CreatedDate = card.CreatedDate,
                ExpiredDate = card.ExpiredDate,
                PatientId = "",
                Status = 3
            };

            card.Money = 0;
            card.PatientId = "";
            card.Status = 3;

            _unitOfWork.GetRepository<Card>().Update(card);
            await _unitOfWork.CommitAsync();

            return cardResponse;
        }

        public async Task<Card> ChangeCard(int CardNumber)
        {
            var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == CardNumber && x.Status == 1);

            if (card == null)
                throw new Exception("Bệnh nhân chưa có thẻ hoặc thẻ bị từ chối");

            //tạo thẻ mới, lấy money từ thẻ cũ qua
            var card2 = new Card
            {
                Id = newCardID(),
                CardNumber = newCardNumber(),
                Money = card.Money,
                CreatedDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddYears(1),
                PatientId = card.PatientId,
                Status = 1
            };

            _unitOfWork.GetRepository<Card>().Add(card2);

            //hủy thẻ cũ, set money về 0
            card.Money = 0;
            card.PatientId = "";
            card.Status = 2;

            _unitOfWork.GetRepository<Card>().Update(card);
            await _unitOfWork.CommitAsync();
            return card2;
        }

        public async Task<Card> BlockCard(int CardNumber)
        {
            var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == CardNumber);

            if (card == null) throw new Exception("Card không tồn tại");

            card.Status = 4;

            _unitOfWork.GetRepository<Card>().Update(card);
            await _unitOfWork.CommitAsync();

            return card;
        }

        public async Task<CardResponse> GetAllCards()
        {
            var result = await _unitOfWork.GetRepository<Card>().GetAll().OrderBy(x => x.Id).ToListAsync();

            return new CardResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<PatientResponse> GetAllPatients()
        {
            var result = await _unitOfWork.GetRepository<Patient>().GetAll().OrderBy(x => x.Id).ToListAsync();

            return new PatientResponse
            {
                Total = result.Count,
                Data = result
            };
        }

        public async Task<Patient> AddNewPatient(AddNewPatientRequest request)
        {
            var patient = _mapper.Map<Patient>(request);
            patient.Id = newPatientID();
            _unitOfWork.GetRepository<Patient>().Add(patient);
            await _unitOfWork.CommitAsync();
            return patient;
        }

        public async Task<List<AuditLog>> GetAllAuditLogs()
        {
            var result = await _unitOfWork.GetRepository<AuditLog>().GetAll().OrderBy(x => x.Id).ToListAsync();

            return result;
        }

        public async Task<List<RevenueStatistic>> GetRevenueStatistics()
        {
            var audits = await _unitOfWork.GetRepository<AuditLog>().GetAll().OrderBy(x => x.Id).ToListAsync();
            var revStats = new List<RevenueStatistic>();

            foreach (AuditLog audit in audits)
            {
                if (!audit.Data.GetProperty("Action").TryGetProperty("Exception", out var _))
                {
                    var actionName = audit.Data.GetProperty("Action").GetProperty("ActionName").GetString();
                    if (actionName == "CreateNewCard" || actionName == "ReturnCard" || actionName == "TopUp")
                    {
                        var rev = new RevenueStatistic
                        {
                            Action = actionName,
                            CardNumber = (actionName == "TopUp"
                                ? audit.Data.GetProperty("Action").GetProperty("ActionParameters").GetProperty("topUpRequest").GetProperty("CardNumber").GetInt32()
                                : audit.Data.GetProperty("Action").GetProperty("ResponseBody").GetProperty("Value").GetProperty("Result").GetProperty("CardNumber").GetInt32()),
                            Date = audit.InsertedDate,
                            Amount = actionName == "TopUp"
                                ? audit.Data.GetProperty("Action").GetProperty("ActionParameters").GetProperty("topUpRequest").GetProperty("Money").GetInt32()
                                : actionName == "CreateNewCard" ? audit.Data.GetProperty("Action").GetProperty("ActionParameters").GetProperty("createCardRequest").GetProperty("Money").GetInt32()
                                : audit.Data.GetProperty("Action").GetProperty("ResponseBody").GetProperty("Value").GetProperty("Result").GetProperty("OldMoney").GetInt32()
                        };

                        revStats.Add(rev);
                    }
                    else if (actionName == "ChangeCardStatus")
                    {
                        var aN = audit.Data.GetProperty("Action").GetProperty("ResponseBody").GetProperty("Value").GetProperty("Result").GetProperty("Status").GetString();
                        if (aN == "RETURNED")
                        {
                            var rev = new RevenueStatistic
                            {
                                Action = "ReturnCard",
                                CardNumber = audit.Data.GetProperty("Action").GetProperty("ResponseBody").GetProperty("Value").GetProperty("Result").GetProperty("CardNumber").GetInt32(),
                                Date = audit.InsertedDate,
                                Amount = audit.Data.GetProperty("Action").GetProperty("ResponseBody").GetProperty("Value").GetProperty("Result").GetProperty("OldMoney").GetInt32()
                            };

                            revStats.Add(rev);
                        }
                    }
                }
            }

            return revStats;
        }

        public async Task<List<RevenueStatistic>> GetRevenueStatisticsByAction(string Action)
        {
            var lstRS = await GetRevenueStatistics();

            var lstRSr = new List<RevenueStatistic>();
            foreach(var RS in lstRS)
            {
                if (RS.Action == Action)
                {
                    lstRSr.Add(RS);
                }
            }

            return lstRSr;
        }

        public async Task<List<RevenueStatistic>> GetRevenueStatisticsByDate(DateTime Date)
        {
            var lstRS = await GetRevenueStatistics();

            var lstRSr = new List<RevenueStatistic>();
            foreach (var RS in lstRS)
            {
                if (RS.Date.Date == Date.Date)
                {
                    lstRSr.Add(RS);
                }
            }

            return lstRSr;
        }

        public async Task<List<RevenueStatistic>> GetRevenueStatisticsByActionAndDate(string Action, DateTime Date)
        {
            var lstRS = await GetRevenueStatistics();

            var lstRSr1 = new List<RevenueStatistic>();
            foreach (var RS in lstRS)
            {
                if (RS.Date.Date == Date.Date)
                {
                    lstRSr1.Add(RS);
                }
            }

            var lstRSr2 = new List<RevenueStatistic>();
            foreach (var RS in lstRSr1)
            {
                if (RS.Action == Action)
                {
                    lstRSr2.Add(RS);
                }
            }

            return lstRSr2;
        }

        public async Task<PatientCardResponse> GetFullPatientCard(PatientCardRequest patientCardRequest)
        {
            if (patientCardRequest.CardNumber == 0)
            {
                var p = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == patientCardRequest.PatientId);
                var c = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.PatientId == patientCardRequest.PatientId);
                if (c == null)
                    return new PatientCardResponse(p);
                if (p == null)
                    return new PatientCardResponse(c);
                return new PatientCardResponse(p, c);
            }
            else if (string.IsNullOrEmpty(patientCardRequest.PatientId))
            {
                var c = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == patientCardRequest.CardNumber);
                var p = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Id == c.PatientId);
                if (c == null)
                    return new PatientCardResponse(p);
                if (p == null)
                    return new PatientCardResponse(c);
                return new PatientCardResponse(p, c);
            }

            return null;
        }

        private string newCardID()
        {
            int cc = _unitOfWork.GetRepository<Card>().GetAll().Count();
            if (cc < 9)
            {
                return "C00" + (cc + 1);
            }
            return "C0" + (cc + 1);
        }

        private int newCardNumber()
        {
            Random rd = new Random();

            return rd.Next(100000000, 999999999);
        }

        private string newPatientID()
        {
            int cc = _unitOfWork.GetRepository<Patient>().GetAll().Count();
            if (cc < 9)
            {
                return "P00" + (cc + 1);
            }
            return "P0" + (cc + 1);
        }
    }
}
