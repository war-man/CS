using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using CS.VM.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;
using static CS.Common.Common.Constants;

namespace TEK.Core.App.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.Service.Interfaces.IApplicationService" />
    public class ApplicationService : IApplicationService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public ApplicationService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Default Service
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public Application Add(Application entity)
        {
            _unitOfWork.GetRepository<Application>().Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Device.</returns>
        public async Task<Application> AddAsync(Application entity)
        {
            _unitOfWork.GetRepository<Application>().Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count()
        {
            return _unitOfWork.GetRepository<Application>().Count();
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.GetRepository<Application>().CountAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Application entity)
        {
            _unitOfWork.GetRepository<Application>().Delete(entity);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            _unitOfWork.GetRepository<Application>().Delete(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Application entity)
        {
            _unitOfWork.GetRepository<Application>().Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.Int32.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.GetRepository<Application>().Delete(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public Application Find(Expression<Func<Application, bool>> match)
        {
            return _unitOfWork.GetRepository<Application>().Find(match);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<Application> FindAll(Expression<Func<Application, bool>> match)
        {
            return _unitOfWork.GetRepository<Application>().GetAll().Where(match).ToList();
        }

        /// <summary>
        /// find all as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<Application>> FindAllAsync(Expression<Func<Application, bool>> match)
        {
            return await _unitOfWork.GetRepository<Application>().GetAll().Where(match).ToListAsync();
        }

        /// <summary>
        /// find as an asynchronous operation.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Device.</returns>
        public async Task<Application> FindAsync(Expression<Func<Application, bool>> match)
        {
            return await _unitOfWork.GetRepository<Application>().GetAll().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public Application Get(Guid id)
        {
            return _unitOfWork.GetRepository<Application>().GetById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public ICollection<Application> GetAll()
        {
            return _unitOfWork.GetRepository<Application>().GetAll().ToList();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>ICollection&lt;Device&gt;.</returns>
        public async Task<ICollection<Application>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<Application>().GetAll().ToListAsync();
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public async Task<Application> GetAsync(Guid id)
        {
            return await _unitOfWork.GetRepository<Application>().GetAsyncById(id);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Device.</returns>
        public Application Update(Application entity, Guid id)
        {
            if (entity == null)
                return null;

            Application existing = _unitOfWork.GetRepository<Application>().GetById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Application>().Update(entity);
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
        public async Task<Application> UpdateAsync(Application entity, Guid id)
        {
            if (entity == null)
                return null;

            Application existing = await _unitOfWork.GetRepository<Application>().GetAsyncById(id);
            if (existing != null)
            {
                _unitOfWork.GetRepository<Application>().Update(entity);
                await _unitOfWork.CommitAsync();
            }

            return existing;
        }
        #endregion

        /// <summary>
        /// Adds the or update application.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<ApplicationViewModel> AddOrUpdateApplication(AddOrUpdateApplicationRequest request)
        {
            var application = await _unitOfWork.GetRepository<Application>().FindAsync(x => x.Id == request.Id);

            List<CS.EF.Models.Version> versions = new List<CS.EF.Models.Version>();

            if (request.VersionIds != null && request.VersionIds.Count > 0)
            {
                versions = await _unitOfWork.GetRepository<CS.EF.Models.Version>().GetAll().Where(x => request.VersionIds.Contains(x.Id)).ToListAsync();
            }

            if (application == null)
            {
                var newApp = _mapper.Map<Application>(request);

                foreach (var item in versions)
                {
                    newApp.Versions.Add(item);
                }
                _unitOfWork.GetRepository<Application>().Add(newApp);
                application = newApp;
            }
            else
            {
                var deviceConfigs = _unitOfWork.GetRepository<DeviceConfig>().GetAll().Where(x => x.ApplicationId == application.Id);

                foreach (var item in deviceConfigs)
                {
                    item.ApplicationName = request.Name;
                    _unitOfWork.GetRepository<DeviceConfig>().Update(item);
                }

                foreach (var item in versions)
                {
                    application.Versions.Add(item);
                }
                application.Name = request.Name;
                application.IsActive = request.IsActive;
                application.PackageName = request.PackageName;
                application.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<Application>().Update(application);
            }

            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.PackageNameHaveExist);
            }

            var result = _mapper.Map<ApplicationViewModel>(application);
            result.Versions = _mapper.Map<List<VersionViewModel>>(application.Versions);

            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<GetApplicationResponse> GetAll(GetApplicationRequest request)
        {
            var applications = _unitOfWork.GetRepository<Application>().GetAll();

            if (!string.IsNullOrEmpty(request.Name))
                applications = applications.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            if (!string.IsNullOrEmpty(request.PackageName))
                applications = applications.Where(x => x.PackageName.ToLower().Contains(request.PackageName.ToLower()));

            var total = await applications.CountAsync();

            var result = await applications.OrderByDescending(x => x.UpdatedDate).Skip(request.Skip).Take(request.Take).ToListAsync();

            var data = new List<ApplicationViewModel>();

            foreach (var item in result)
            {
                var app = _mapper.Map<ApplicationViewModel>(item);
                app.Versions = _mapper.Map<List<VersionViewModel>>(item.Versions);
                data.Add(app);
            }

            return new GetApplicationResponse
            {
                Total = total,
                Data = data
            };
        }
    }
}
