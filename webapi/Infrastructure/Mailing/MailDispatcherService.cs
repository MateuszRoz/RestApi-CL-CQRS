using Application.Common.Interfaces;
using Application.Common.Models;
using Infrastructure.Mailing.SmtpService;
using Infrastructure.Presistance.ApplicationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mailing
{
    public class MailDispatcherService : IMailDispatcherService
    {
       private readonly ISmtpClientService _smtpClientService;
        public MailDispatcherService(ISmtpClientService smtpClientService)
        {
            _smtpClientService = smtpClientService;
        }

        public async Task Send(MailModel model)
        {
            await _smtpClientService.Send(model);
        }
    }
}
