using Application.Common.Models;

namespace Infrastructure.Mailing.SmtpService
{
    public interface ISmtpClientService
    {
        Task Send(MailModel model);
    }
}