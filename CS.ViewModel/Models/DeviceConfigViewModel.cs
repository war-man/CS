using System;

namespace CS.VM.Models
{
    public class DeviceConfigViewModel
    {
        public Guid DeviceId { get; set; }
        public string DeviceName { get; set; }
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string PackageName { get; set; }
        public Guid VersionId { get; set; }
        public string VersionName { get; set; }
        public int VersionCode { get; set; }
        public bool IsActive { get; set; }
        public string Message { get; set; }
        public string AreaCode { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? LogTime { get; set; }
    }
}
