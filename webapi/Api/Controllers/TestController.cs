using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handlers.Test;
using System.Threading;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestController(IMediator mediator, ILogger<TestController> logger)
        {
            _mediator = mediator;
        }



        [HttpGet]
        public async Task<int> Get()
        {
            await _mediator.Send(new TestQuery(), CancellationToken.None);

            return await Task.FromResult(1);
        }
    }
}
