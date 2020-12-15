using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Request
{
    public class ChangeInvoiceStatusRequest
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
    }
}
