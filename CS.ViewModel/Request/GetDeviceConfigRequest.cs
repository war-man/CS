using System;

namespace CS.VM.Request
{
    public class GetDeviceConfigRequest
    {
        public Guid? DeviceId { get; set; }
        public Guid? ApplicationId { get; set; }
    }
}
