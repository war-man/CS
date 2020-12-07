using CS.EF.Models;
using System.Collections.Generic;

namespace CS.VM.Response
{
    public class UploadLogsResponse
    {
        public List<ApplicationLog> ApplicationLogs { get; set; }
    }
}
