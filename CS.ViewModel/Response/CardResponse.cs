using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class CardResponse
    {
        public int Total { get; set; }
        public List<Card> Data { get; set; }
    }
}
