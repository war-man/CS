using CS.VM.Request;
using CS.WebApp.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.WebApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost,Route("Create")]
        public IActionResult Create([FromBody]AddShiftRequest request )
        {
           
            var result = _calendarService.CreateCalendar(request);
            return View();
        }
    }
}
