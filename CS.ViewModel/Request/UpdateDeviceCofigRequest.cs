using Newtonsoft.Json;
using System;

namespace CS.VM.Request
{
    public class UpdateDeviceCofigRequest
    {
        [JsonRequired]
        public Guid VersionId { get; set; }
        [JsonRequired]
        public Guid ApplicationId { get; set; }
        [JsonRequired]
        public Guid DeviceId { get; set; }
        public DateTime? LogTime { get; set; }
        public string Message { get; set; }
    }
}
