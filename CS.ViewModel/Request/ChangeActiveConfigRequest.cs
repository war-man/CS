using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CS.VM.Request
{
    public class ChangeActiveConfigRequest
    {
        public List<DeviceConfigKey> Ids { get; set; }
        public bool IsActive { get; set; }
        public string AreaCode { get; set; }
        public string Message { get; set; }
    }

    public class DeviceConfigKey
    {
        [JsonRequired]
        public Guid ApplicationId { get; set; }
        [JsonRequired]
        public Guid DeviceId { get; set; }
    }

}
