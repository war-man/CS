using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CS.VM.Request
{
    public class AddOrUpdateVersionRequest
    {
        public Guid Id { get; set; }
        [JsonRequired]
        public Guid ApplicationId { get; set; }
        public bool IsActive { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public int Code { get; set; }
        [JsonRequired]
        public BundleInfomation BundleInfomation { get; set; }
    }

    public class BundleInfomation
    {
        [JsonRequired]
        public IFormFile BundleFile { get; set; }
        [JsonRequired]
        public string ReleaseNote { get; set; }
    }
}
