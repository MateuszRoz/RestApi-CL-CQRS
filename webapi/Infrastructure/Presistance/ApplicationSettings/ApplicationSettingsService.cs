using Infrastructure.Presistance.ApplicationSettings.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistance.ApplicationSettings
{
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        public ApplicationSettingsService(IConfiguration config)
        {
            MailingSettings = config.GetSettings<MailingSettings>("MailingSettings");
        }
        public MailingSettings MailingSettings { get; set; }

        public MailOperator GetCurrentMailOperator()
        {
            return MailingSettings.Operators.FirstOrDefault(a => a.Operator == MailingSettings.Operator);
        }
    }
}
