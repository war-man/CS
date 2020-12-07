using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CS.VM.Request
{
    public class AddDeviceConfigRequest
    {
        [JsonRequired]
        public Guid DeviceId { get; set; }

        [JsonRequired]
        public List<DeviceConfigModel> DeviceConfigs { get; set; }
    }

    public class DeviceConfigModel
    {
        [JsonRequired]
        public Guid ApplicationId { get; set; }
        [JsonRequired]
        public Guid VersionId { get; set; }
        public ActionCommand ActionCommand { get; set; }
        public DateTime? LogTime { get; set; }
        public string Message { get; set; }
    }

}


