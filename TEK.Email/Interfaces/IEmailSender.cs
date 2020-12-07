using CS.EF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEK.Email.Interfaces
{
    public interface IEmailSender
    {
        /// <summary>
        /// Sends the email device.
        /// </summary>
        /// <param name="devices">The devices.</param>
        /// <returns></returns>
        Task<bool> SendEmailDevice(List<Device> devices);
        /// <summary>
        /// Sends the email device configuration.
        /// </summary>
        /// <param name="deviceConfigs">The device configs.</param>
        /// <returns></returns>
        Task<bool> SendEmailDeviceConfig(List<DeviceConfig> deviceConfigs);
    }
}
