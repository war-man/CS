using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Core.App.Domain.Services
{
    public class VersionService : IVersionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBundleService _bundleService;
        public VersionService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IBundleService bundleService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bundleService = bundleService;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public CS.EF.Models.Version Add(CS.EF.Models.Version entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.Version>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public async Task<CS.EF.Models.Version> AddAsync(CS.EF.Models.Version entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.Version>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<CS.EF.Models.Version>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.Version>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(CS.EF.Models.Version entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.Version>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<CS.EF.Models.Version>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(CS.EF.Models.Version entity)
        {
            _unitOfWork.GetRepository<CS.EF.Models.Version>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<CS.EF.Models.Version>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public CS.EF.Models.Version Find(Expression<Func<CS.EF.Models.Version, bool>> match)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.Version>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<CS.EF.Models.Version> FindAll(Expression<Func<CS.EF.Models.Version, bool>> match)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<CS.EF.Models.Version>> FindAllAsync(Expression<Func<CS.EF.Models.Version, bool>> match)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public async Task<CS.EF.Models.Version> FindAsync(Expression<Func<CS.EF.Models.Version, bool>> match)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public CS.EF.Models.Version Get(Guid id)
        {
            return _unitOfWork.GetRepository<CS.EF.Models.Version>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<CS.EF.Models.Version> GetAll()
        {
            return _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<CS.EF.Models.Version>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public async Task<CS.EF.Models.Version> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public CS.EF.Models.Version Update(CS.EF.Models.Version entity, Guid id)
        {
            if (entity == null)
                return null;

            CS.EF.Models.Version existing = _unitOfWork.GetRepository<CS.EF.Models.Version>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<CS.EF.Models.Version>().Update(entity);
                _unitOfWork.Commit();
            }

            return existing;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public async Task<CS.EF.Models.Version> UpdateAsync(CS.EF.Models.Version entity, Guid id)
        {
            if (entity == null)
                return null;

            CS.EF.Models.Version existing = await _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<CS.EF.Models.Version>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Adds the or update version.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<VersionViewModel> AddOrUpdateVersion(AddOrUpdateVersionRequest request)
        {
            var version = await _unitOfWork.GetRepository<CS.EF.Models.Version>().FindAsync(x => x.Id == request.Id);
            var application = await _unitOfWork.GetRepository<Application>().FindAsync(x => x.Id == request.ApplicationId);

            if (application == null)
                throw new Exception(ErrorMessages.NotFoundApplication);

            if (version == null)
            {
                var bundle = await _bundleService.UploadFile(request);
                var newVersion = _mapper.Map<CS.EF.Models.Version>(request);
                newVersion.ApplicationName = application.Name;
                newVersion.Bundles.Add(bundle);
                _unitOfWork.GetRepository<CS.EF.Models.Version>().Add(newVersion);
                version = newVersion;
            }
            else
            {
                version.IsActive = request.IsActive;
                version.Code = request.Code;
                version.Name = request.Name;
                version.ApplicationName = application.Name;
                version.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<CS.EF.Models.Version>().Update(version);
            }

            await _unitOfWork.CommitAsync();
            var response = _mapper.Map<VersionViewModel>(version);
            response.Bundles = _mapper.Map<List<BundleViewModel>>(version.Bundles);
            return response;
        }

        public async Task<GetVersionResponse> GetAll(GetVersionRequest request)
        {
            var versions = _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll();

            if (!string.IsNullOrEmpty(request.ApplicationName))
                versions = versions.Where(x => x.ApplicationName.ToLower().Contains(request.ApplicationName.ToLower()));

            var total = await versions.CountAsync();

            var result = await versions.Skip(request.Skip).Take(request.Take).OrderByDescending(x => x.UpdatedDate).ToListAsync();

            var versionViews = new List<VersionViewModel>();
            foreach (var item in result)
            {
                var version = _mapper.Map<VersionViewModel>(item);

                version.Bundles = item.Bundles.Select(x => _mapper.Map<BundleViewModel>(x));
                versionViews.Add(version);
            }

            return new GetVersionResponse
            {
                Data = versionViews,
                Total = total
            };
        }
    }
}
