namespace CS.VM.Request
{
    public class GetDeviceRequest : PagingBaseRequest
    {
        public string AreaCode { get; set; }
        public string DeviceName { get; set; }
        public DeviceType? Type { get; set; }
        public bool? IsActive { get; set; }
    }
}
