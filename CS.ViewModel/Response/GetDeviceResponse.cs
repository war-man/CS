using CS.VM.Models;
using System.Collections.Generic;

namespace CS.VM.Response
{
    public class GetDeviceResponse
    {
        public int Total { get; set; }
        public List<DeviceViewModel> Data { get; set; }
    }
}
