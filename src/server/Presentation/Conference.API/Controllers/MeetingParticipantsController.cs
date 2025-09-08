using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.MeetingParticipants.InviteParticipant;

namespace Conference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingParticipantsController : Controller
    {
        readonly IMediator _mediator;

        public MeetingParticipantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("invite")]
        public async Task<IActionResult> InviteParticipant([FromBody] InviteParticipantCommandRequest inviteParticipantCommandRequest)
        {
            InviteParticipantCommandResponse response = await _mediator.Send(inviteParticipantCommandRequest);
            return Ok(response);
        }
    }
}
