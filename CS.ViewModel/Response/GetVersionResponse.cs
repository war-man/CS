using CS.VM.Models;
using System.Collections.Generic;

namespace CS.VM.Response
{
    public class GetVersionResponse
    {
        public int Total { get; set; }
        public List<VersionViewModel> Data { get; set; }
    }
}
