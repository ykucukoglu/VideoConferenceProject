using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.Community.AddCommunity;
using VideoConference.Application.Features.Commands.Team.AddTeam;
using VideoConference.Application.Features.Queries.Community.GetByIdCommunity;
using VideoConference.Application.Features.Queries.Team.GetByIdTeam;

namespace Conference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommunityController : Controller
    {
        readonly IMediator _mediator;

        public CommunityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}", Name = "GetCommunityById")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var team = await _mediator.Send(new GetByIdCommunityQueryRequest { Id = id });
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddCommunityCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtRoute(
                "GetCommunityById",            
                new { id = response.CommunityId },
                response
            );
        }
    }
}
