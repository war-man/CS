using CS.VM.Models;
using System.Collections.Generic;

namespace CS.VM.Response
{
    public class DeviceConfigResponse
    {
        public int Total { get; set; }
        public List<DeviceConfigViewModel> Data { get; set; }
    }
}
