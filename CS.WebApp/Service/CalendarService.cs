using CS.VM.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CS.WebApp.Service
{
    public class CalendarService : ICalendarService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CalendarService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreateCalendar(AddShiftRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("");

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/Shift/add", httpContent);
            var result = await response.Content.ReadAsStringAsync();


            return response.IsSuccessStatusCode;
        }
    }
}
