namespace CS.VM.Request
{
    public class GetApplicationRequest : PagingBaseRequest
    {
        public string Name { get; set; }
        public string PackageName { get; set; }
    }
}
