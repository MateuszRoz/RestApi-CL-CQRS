using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class PerformenceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _sw;
        public PerformenceBehaviour()
        {
            _sw = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _sw.Start();
            var response = await next();
            _sw.Stop();

            if (_sw.Elapsed.Seconds > 10)
                throw new Exception("test");

            return response;
        }
    }
}
