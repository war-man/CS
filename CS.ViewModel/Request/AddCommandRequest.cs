using Newtonsoft.Json;
using System;

namespace CS.VM.Request
{
    public class AddCommandRequest
    {
        [JsonRequired]
        public Guid DeviceId { get; set; }
        [JsonRequired]
        public Guid ApplicationId { get; set; }
        [JsonRequired]
        public string CommandDescription { get; set; }
        [JsonRequired]
        public string PackageName { get; set; }
        public ActionCommand ActionCommand { get; set; }
    }
}
