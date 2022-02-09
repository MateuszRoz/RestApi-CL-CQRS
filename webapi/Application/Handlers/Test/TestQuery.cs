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
        public Task<Unit> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            string a = "test";

            throw new NotImplementedException();
        }
    }
}
