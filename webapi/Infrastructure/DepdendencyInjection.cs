using Application.Common.Interfaces;
using Infrastructure.Mailing;
using Infrastructure.Mailing.SmtpService;
using Infrastructure.Presistance.ApplicationSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMailKit(optionBuilder =>
            //{
            //    optionBuilder.UseMailKit(new MailKitOptions()
            //    {
            //        //get options from sercets.json
            //        Server = "smtp.gmail.com",//configuration["Server"],
            //        Port = 465,
            //        SenderName = "Test",
            //        SenderEmail = "Test",

            //        // can be optional with no authentication 
            //        Account = "mat.rozpara@gmail.com",
            //        Password = "Visual2005",
            //        // enable ssl or tls
            //        Security = true
            //    });
            //});

            services.AddTransient<ISmtpClientService, SmptClientService>();
            services.AddTransient<IApplicationSettingsService, ApplicationSettingsService>();
            services.AddSingleton<IMailDispatcherService, MailDispatcherService>();
            
            return services;
        }
    }
}
