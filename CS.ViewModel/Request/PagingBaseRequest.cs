namespace CS.VM.Request
{
    public class PagingBaseRequest
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
