using CS.EF.Models;
using CS.VM.Models;
using CS.VM.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    public interface ICommandService
    {
        Task<List<CommandViewModel>> GetCommand(Guid deviceId);
        Task<List<CommandViewModel>> GetCommand(Guid deviceId, string packageName);
        Task<bool> DeleteCommand(Guid commandId);
        Task<Command> AddCommand(AddCommandRequest request);
    }
}
