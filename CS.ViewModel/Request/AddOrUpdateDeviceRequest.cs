using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CS.VM.Request
{
    public class AddOrUpdateDeviceRequest
    {
        public Guid Id { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public string Code { get; set; }
        public List<Guid> ApplicationIds { get; set; }
        public bool IsActive { get; set; }
        public string Ip { get; set; }
        public string AreaCode { get; set; }
        public DeviceType Type { get; set; }
    }
}
