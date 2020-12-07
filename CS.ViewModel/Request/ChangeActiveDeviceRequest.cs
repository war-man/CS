using System;
using System.Collections.Generic;

namespace CS.VM.Request
{
    public class ChangeActiveDeviceRequest
    {
        public List<Guid> Ids { get; set; }
        public bool IsActive { get; set; }
        public string AreaCode { get; set; }
        public string Message { get; set; }
    }
}
