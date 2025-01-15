using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.DTOs.Meetings;
using VideoConference.Application.Features.Commands.Meeting.DeleteMeeting;
using VideoConference.Application.Features.Queries.Meeting.GetAllMeeting;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Entities;

namespace VideoConference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
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
