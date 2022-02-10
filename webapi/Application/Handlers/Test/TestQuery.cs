using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Test
{
    public class TestQuery : IRequest
    {
    }

    public class TestQueryHandler : IRequestHandler<TestQuery>
    {
        private readonly IMailDispatcherService _mailService;

        public TestQueryHandler(IMailDispatcherService mailService)
        {
            _mailService = mailService;
        }

        public async Task<Unit> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            string a = "test";
            await _mailService.Send(new MailModel("mateuszrozpara@sourceful.nl","test","Test"));


            throw new NotImplementedException();
        }
    }
}
