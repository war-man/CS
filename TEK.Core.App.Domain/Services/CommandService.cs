using AutoMapper;
using CS.Common.Common;
using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Core.App.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TEK.Core.Service.Interfaces.ICommandService" />
    public class CommandService : ICommandService
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
        /// Initializes a new instance of the <see cref="CommandService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        public CommandService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        public async Task<List<CommandViewModel>> GetCommand(Guid deviceId)
        {
            var deviceCommands = await _unitOfWork.GetRepository<Command>().GetAll().Where(x => x.DeviceId == deviceId).AsNoTracking().ToListAsync();
            return _mapper.Map<List<CommandViewModel>>(deviceCommands);
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <returns></returns>
        public async Task<List<CommandViewModel>> GetCommand(Guid deviceId, string packageName)
        {
            var deviceCommands = await _unitOfWork.GetRepository<Command>().GetAll().Where(x => x.DeviceId == deviceId && x.PackageName == packageName).AsNoTracking().ToListAsync();
            return _mapper.Map<List<CommandViewModel>>(deviceCommands);
        }

        /// <summary>
        /// Deletes the command.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteCommand(Guid commandId)
        {
            var command = await _unitOfWork.GetRepository<Command>().FindAsync(x => x.Id == commandId);

            if (command == null)
                return false;
            _unitOfWork.GetRepository<Command>().Delete(command);
            await _unitOfWork.CommitAsync();
            return true;
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Command> AddCommand(AddCommandRequest request)
        {
            var device = await _unitOfWork.GetRepository<Device>().FindAsync(x => x.Id == request.DeviceId);

            var application = await _unitOfWork.GetRepository<Application>().FindAsync(x => x.Id == request.ApplicationId);

            if (device == null || application == null)
                throw new Exception(ErrorMessages.NotFounDeviceOrApp);

            var command = _mapper.Map<Command>(request);

            _unitOfWork.GetRepository<Command>().Add(command);
            await _unitOfWork.CommitAsync();
            return command;
        }
    }
}
