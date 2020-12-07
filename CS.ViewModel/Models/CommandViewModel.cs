using System;

namespace CS.VM.Models
{
    public class CommandViewModel
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid ApplicationId { get; set; }
        public ActionCommand ActionCommand { get; set; }
        public string CommandDescription { get; set; }
        public string PackageName { get; set; }
    }
}
