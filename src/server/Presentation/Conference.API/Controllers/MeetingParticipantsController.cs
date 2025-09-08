using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.MeetingParticipants.InviteParticipant;
using VideoConference.Application.Features.Commands.MeetingParticipants.JoinParticipant;
using VideoConference.Application.Features.Queries.Meeting.GetAllMeeting;

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

        [HttpPost("join")]
        public async Task<IActionResult> JoinMeeting([FromBody] JoinParticipantCommandRequest dto)
        {
            JoinParticipantCommandResponse response = await _mediator.Send(dto);

            return Ok(response);
        }

        [HttpPost("leave")]
        public async Task<IActionResult> LeaveMeeting([FromBody] LeaveParticipantCommandRequest dto)
        {
            LeaveParticipantCommandResponse response = await _mediator.Send(dto);

            return Ok(response);
        }

        [HttpPost("accept")]
        public async Task<IActionResult> AcceptParticipant([FromBody] AcceptParticipantCommandRequest dto)
        {
            AcceptParticipantCommandResponse response = await _mediator.Send(dto);
            return Ok(response);
        }

        [HttpGet("{meetingId:guid}")]
        public async Task<IActionResult> GetParticipants(Guid meetingId)
        {
            GetAllMeetingParticipantQueryResponse response = await _mediator.Send(new GetAllMeetingParticipantQueryRequest { MeetingId = meetingId});
            return Ok(response);
        }
    }
}
