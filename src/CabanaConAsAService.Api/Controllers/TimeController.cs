using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NodaTime;
using CabanaConAsAService.Application.Queries;
using CabanaConAsAService.Application.Responses;

namespace CabanaConAsAService.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class TimeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IsItCabanaConTimeYetResponse>> IsItCabanaConTimeYet()
        {
            var query = new IsItCabanaConTimeYetQuery(LocalDateTime.FromDateTime(DateTime.Now));
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}