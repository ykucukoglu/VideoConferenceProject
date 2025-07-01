using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.Meeting.DeleteMeeting;
using VideoConference.Application.Features.Queries.Meeting.GetAllMeeting;

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
    }
}
