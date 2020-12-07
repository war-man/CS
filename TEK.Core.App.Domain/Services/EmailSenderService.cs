using CS.VM.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TEK.Email.Interfaces;
using CS.EF.Models;

namespace TEK.Core.App.Domain.Services
{
    public class EmailSenderService : IEmailSender
    {
        /// <summary>
        /// The email settings
        /// </summary>
        private readonly EmailSettings _emailSettings;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSenderService"/> class.
        /// </summary>
        /// <param name="emailSettings">The email settings.</param>
        public EmailSenderService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        /// <summary>
        /// Sends the email device.
        /// </summary>
        /// <param name="devices">The devices.</param>
        /// <returns></returns>
        public Task<bool> SendEmailDevice(List<Device> devices)
        {
            var body = @"<html>
            <body>
            Hi <b>Admin</b> !
            <h2>Danh sách các thiết bị đang không hoạt động. Vui lòng kiểm tra lại.</h2>";
            body += @"<table align='left' style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd;width: 100%;'>";
            body += @"<tr>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Tên thiết bị</th>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Mã thiết bị</th> 
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Tên phiên bản</th> 
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Ip</th>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Khu</th>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Trạng thái</th>
                      </tr>";
            //foreach (var item in devices)
            //{
            //    var versionName = item.Version != null ? item.Version.Name : "";
            //    body += $"<tr>" +
            //        $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.Name}</b></td>" +
            //        $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.Code}</b></td>" +
            //        $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{versionName}</b></td>" +
            //        $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.Ip}</b></td>" +
            //        $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.AreaCode ?? ""}</b></td>" +
            //        $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>Không hoạt động</b></td>" +
            //        $"</tr>";
            //    body += @"<tr>";
            //}
            body += "</table>";
            return SendMail(body);
        }
        /// <summary>
        /// Sends the email device configuration.
        /// </summary>
        /// <param name="deviceConfigs">The device configs.</param>
        /// <returns></returns>
        public async Task<bool> SendEmailDeviceConfig(List<DeviceConfig> deviceConfigs)
        {
            var body = @"<html>
            <body>
            Hi <b>Admin</b> !
            <h2>Danh sách các thiết bị đang không hoạt động. Vui lòng kiểm tra lại.</h2>";
            body += @"<table align='left' style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd;width: 100%;'>";
            body += @"<tr>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Tên thiết bị</th>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Tên ứng dụng</th> 
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Package</th> 
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Tên phiên bản</th> 
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Khu</th>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Lời nhắn</th>
                        <th style='border-bottom: 1px solid #caecf0;text-align: left;border: 1px solid #dddddd'>Trạng thái</th>
                      </tr>";
            foreach (var item in deviceConfigs)
            {
                body += $"<tr>" +
                    $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.DeviceName}</b></td>" +
                    $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.ApplicationName}</b></td>" +
                    $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.PackageName}</b></td>" +
                    $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.VersionName}</b></td>" +
                    $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.AreaCode ?? ""}</b></td>" +
                    $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>{item.Message ?? ""}</b></td>" +
                    $"<td style='border-bottom: 1px solid #caecf0;border: 1px solid #dddddd'><b>Không hoạt động</b></td>" +
                    $"</tr>";
                body += @"<tr>";
            }
            body += "</table>";
            return await SendMail(body);
        }
        /// <summary>
        /// Sents the mail.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<bool> SendMail(string body)
        {
            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(_emailSettings.Email.MailFrom),
                    Subject = "[Thiết bị] Trạng thái đang không hoạt động",
                    IsBodyHtml = true,
                    Body = body
                };
                message.To.Add(new MailAddress(_emailSettings.Email.MailTo));

                SmtpClient smtp = new SmtpClient
                {
                    Port = _emailSettings.Email.Port,
                    Host = _emailSettings.Email.Host,
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(_emailSettings.Email.MailFrom, _emailSettings.Email.PasswordMailFrom),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                await smtp.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
