using AutoMapper;
using CS.EF.Models;
using CS.VM.Request;
using System;
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

            if (s != null)
                throw new Exception("Bệnh nhân đã có thẻ");

            var card = new Card
            {
                Id = newCardID(),
                CardNumber = newCardNumber(),
                Money = createCardRequest.Money,
                CreatedDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddYears(1),
                PatientId = createCardRequest.PatientId,
                Status = "OK"
            };

            _unitOfWork.GetRepository<Card>().Add(card);
            await _unitOfWork.CommitAsync();
            return card;
        }

        public async Task<Card> TopUp(TopUpRequest topUpRequest)
        {
            var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == topUpRequest.CardNumber && x.Status != "BLOCKED" && x.Status != "CHANGED" && x.Status != "RETURNED");

            if (card == null) throw new Exception("Thẻ không tồn tại hoặc bị khóa!");

            card.Money += topUpRequest.Money;
            card.ExpiredDate = DateTime.Now.AddYears(1);

            _unitOfWork.GetRepository<Card>().Update(card);
            await _unitOfWork.CommitAsync();

            return card;
        }

        public async Task<Card> ReturnCard(int CardNumber)
        {
            var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == CardNumber);

            if (card == null) throw new Exception("Card không tồn tại!");

            card.Money = 0;
            card.PatientId = "";
            card.Status = "RETURNED";

            _unitOfWork.GetRepository<Card>().Update(card);
            await _unitOfWork.CommitAsync();

            return card;
        }

        //public async Task<Card> ChangeCard(int CardNumber)
        //{
        //    var s = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == CardNumber);

        //    if (s == null)
        //        throw new Exception("Bệnh nhân chưa có thẻ");

        //    //hủy thẻ cũ, set money về 0
        //    var card = s;
        //    card.Money = 0;
        //    card.PatientId = "";
        //    card.Status = "CHANGED";

        //    _unitOfWork.GetRepository<Card>().Update(card);

        //    //tạo thẻ mới, lấy money từ thẻ cũ qua
        //    var card2 = new Card
        //    {
        //        Id = newCardID(),
        //        CardNumber = newCardNumber(),
        //        Money = s.Money,
        //        CreatedDate = DateTime.Now,
        //        ExpiredDate = DateTime.Now.AddYears(1),
        //        PatientId = PatientId,
        //        Status = "OK"
        //    };

        //    _unitOfWork.GetRepository<Card>().Add(card2);
        //    await _unitOfWork.CommitAsync();
        //    return card2;
        //}

        public async Task<Card> BlockCard(int CardNumber)
        {
            var card = await _unitOfWork.GetRepository<Card>().FindAsync(x => x.CardNumber == CardNumber);

            if (card == null) throw new Exception("Card không tồn tại!");

            card.Status = "BLOCKED";

            _unitOfWork.GetRepository<Card>().Update(card);
            await _unitOfWork.CommitAsync();

            return card;
        }

        private string newCardID()
        {
            int cc = _unitOfWork.GetRepository<Card>().GetAll().Count();
            if (cc < 10)
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
    }
}
