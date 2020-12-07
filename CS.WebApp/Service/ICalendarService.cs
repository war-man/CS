using CS.VM.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.WebApp.Service
{
    public interface ICalendarService
    {
        Task<bool> CreateCalendar(AddShiftRequest request);
    }
}
