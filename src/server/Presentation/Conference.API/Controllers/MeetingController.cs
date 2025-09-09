using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.Meeting.AddMeeting;
using VideoConference.Application.Features.Commands.Meeting.DeleteMeeting;
using VideoConference.Application.Features.Commands.Meeting.JoinMeeting;
using VideoConference.Application.Features.Queries.Meeting.GetAllMeeting;
using VideoConference.Application.Features.Queries.Meeting.GetByIdMeeting;

namespace Conference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        readonly IMediator _mediator;

        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllMeetingQueryRequest());
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteMeetingCommandRequest deleteMeetingCommandRequest)
        {
            DeleteMeetingCommandResponse response = await _mediator.Send(deleteMeetingCommandRequest);
            return Ok(response);
        }

        [HttpGet("{id:guid}", Name = "GetMeetingById")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var meeting = await _mediator.Send(new GetByIdMeetingQueryRequest { Id = id });
            if (meeting == null) return NotFound();
            return Ok(meeting);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddMeetingCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtRoute(
                "GetMeetingById",
                new { id = response.MeetingId },
                response
            );
        }

        [HttpPost("{meetingId}/join")]
        public async Task<IActionResult> JoinMeeting([FromBody] JoinMeetingCommandRequest request)
        {
            JoinMeetingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
