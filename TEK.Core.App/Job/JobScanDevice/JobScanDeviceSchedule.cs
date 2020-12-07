using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;

namespace TEK.Core.App.Job.JobScanDevice
{
    public class JobScanDeviceSchedule : IJob
    {
        private readonly ILogger<JobScanDeviceSchedule> _logger;
        private readonly IServiceProvider _provider;
        public JobScanDeviceSchedule(ILogger<JobScanDeviceSchedule> logger,
            IServiceProvider provider
            )
        {
            _logger = logger;
            _provider = provider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = _provider.CreateScope())
            {
                try
                {
                    _logger.LogInformation("Job Scan device run----------!");
                    var deviceConfig = scope.ServiceProvider.GetService<IDeviceConfigService>();
                    var task = deviceConfig.ScanDeviceConfig();
                    task.Wait();
                    _logger.LogInformation("Job Scan device done----------!");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error", ex.Message);
                }
            }
            return Task.CompletedTask;
        }
    }
}