using CS.VM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Response
{
    public class GetApplicationResponse
    {
        public int Total { get; set; }
        public List<ApplicationViewModel> Data { get; set; }
    }
}
