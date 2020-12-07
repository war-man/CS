using AutoMapper;
using CS.VM.Request;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Core.App.Domain.Services
{
    public class BundleService : IBundleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BundleService(IUnitOfWork unitOfWork,
           IMapper mapper,
           IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CS.EF.Models.Bundle> UploadFile(AddOrUpdateVersionRequest request)
        {
            var bundle = new CS.EF.Models.Bundle();
            var file = request.BundleInfomation.BundleFile;
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                try
                {
                    var folderName = @"Bundle/";
                    var pathToSave = Path.Combine("wwwroot/", folderName);
                    Directory.CreateDirectory(pathToSave);

                    var fullPath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    bundle = _mapper.Map<CS.EF.Models.Bundle>(request);

                    var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
                    var host = _httpContextAccessor.HttpContext.Request.Host;
                    var pathBase = _httpContextAccessor.HttpContext.Request.PathBase;
                    bundle.Link = $"{scheme}://{host}{pathBase}/{folderName}{fileName}";
                    bundle.VersionId = request.Id;
                    _unitOfWork.GetRepository<CS.EF.Models.Bundle>().Add(bundle);
                    await _unitOfWork.CommitAsync();
                    return bundle;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return bundle;
        }
    }
}
