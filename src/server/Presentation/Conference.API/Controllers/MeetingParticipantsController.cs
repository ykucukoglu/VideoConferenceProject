using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.MeetingParticipants.UpdateParticipant;
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
        [HttpPost("updatestatus")]
        public async Task<IActionResult> UpdateParticipantStatus([FromBody] UpdateParticipantStatusCommandRequest updateParticipantStatus)
        {
            UpdateParticipantStatusCommandResponse response = await _mediator.Send(updateParticipantStatus);
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
