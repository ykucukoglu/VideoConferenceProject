using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.Team.AddTeam;
using VideoConference.Application.Features.Queries.Team.GetByIdTeam;

namespace Conference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamsController : Controller
    {
        readonly IMediator _mediator;
        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddAsync([FromBody] AddTeamCommandRequest addTeamCommandRequest)
        //{
        //    AddTeamCommandResponse response = await _mediator.Send(addTeamCommandRequest);
        //    return CreatedAtAction(
        //        nameof(GetByIdAsync),
        //        "Teams",
        //        new { id = response.TeamId },
        //        response
        //    );
        //}

        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        //{
        //    GetByIdTeamQueryResponse team = await _mediator.Send(new GetByIdTeamQueryRequest() { Id = id });
        //    if (team == null) return NotFound();
        //    return Ok(team);
        //}

        [HttpGet("{id:guid}", Name = "GetTeamById")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var team = await _mediator.Send(new GetByIdTeamQueryRequest { Id = id });
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddTeamCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtRoute(
                "GetTeamById",            // Route name
                new { id = response.TeamId },
                response
            );
        }

    }
}
