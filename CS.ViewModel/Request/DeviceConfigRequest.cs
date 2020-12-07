namespace CS.VM.Request
{
    public class DeviceConfigRequest : PagingBaseRequest
    {
        public string ApplicationName { get; set; }
        public string VersionName { get; set; }
        public string DeviceName { get; set; }
        public string AreaCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
