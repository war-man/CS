using System;

namespace CS.VM.Request
{
    public class UploadLogsRequest
    {
        public Guid DeviceId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
