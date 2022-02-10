using Application.Common.Models;
using Infrastructure.Presistance.ApplicationSettings;
using Infrastructure.Presistance.ApplicationSettings.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mailing.SmtpService
{
    public class SmptClientService : ISmtpClientService
    {
        private readonly SmtpClient _smtpClient;
        public SmptClientService(IApplicationSettingsService settings)
        {
            var mailOperator = settings.GetCurrentMailOperator();
            _smtpClient = new SmtpClient
            {
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = mailOperator.Host,
                EnableSsl = mailOperator.Ssl,
                Port = mailOperator.Port,
                Credentials = new NetworkCredential(mailOperator.Login, mailOperator.Password),
            };
        }
        public async Task Send(MailModel model)
        {
            try
            {
                await _smtpClient.SendMailAsync("mat.rozpara@gmail.comm", model.email, model.subject, model.body);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
