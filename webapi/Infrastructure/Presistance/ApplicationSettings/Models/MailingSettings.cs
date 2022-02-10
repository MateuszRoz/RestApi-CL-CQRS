using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistance.ApplicationSettings.Models
{
    public class MailingSettings
    {
        public MailingOperator Operator { get; set; }
        public List<MailOperator> Operators { get; set; }
    }

    public class MailOperator
    {
        public MailingOperator Operator { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
