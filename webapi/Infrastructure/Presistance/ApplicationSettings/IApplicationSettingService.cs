using Infrastructure.Presistance.ApplicationSettings.Models;

namespace Infrastructure.Presistance.ApplicationSettings
{
    public interface IApplicationSettingsService
    {
        MailingSettings MailingSettings { get; set; }
        MailOperator GetCurrentMailOperator();
    }
}