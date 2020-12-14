using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class PatientCardResponse
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string CardId { get; set; }
        public int CardNumber { get; set; }
        public int Money { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int CardStatus { get; set; }

        public PatientCardResponse(Patient patient, Card card)
        {
            PatientId = patient.Id;
            Name = patient.Name;
            Phone = patient.Phone;
            Address = patient.Address;
            Birthday = patient.Birthday;
            Gender = patient.Gender;
            CardId = card.Id;
            CardNumber = card.CardNumber;
            Money = card.Money;
            CreatedDate = card.CreatedDate;
            ExpiredDate = card.ExpiredDate;
            CardStatus = card.Status;
        }

        public PatientCardResponse(Patient patient)
        {
            PatientId = patient.Id;
            Name = patient.Name;
            Phone = patient.Phone;
            Address = patient.Address;
            Birthday = patient.Birthday;
            Gender = patient.Gender;
        }

        public PatientCardResponse(Card card)
        {
            CardId = card.Id;
            CardNumber = card.CardNumber;
            Money = card.Money;
            CreatedDate = card.CreatedDate;
            ExpiredDate = card.ExpiredDate;
            CardStatus = card.Status;
        }

        public PatientCardResponse()
        {

        }
    }
}
