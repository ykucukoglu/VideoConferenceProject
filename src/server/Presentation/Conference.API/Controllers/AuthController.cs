using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.Features.Commands.Auth.Login;
using VideoConference.Application.Features.Commands.Auth.RefreshToken;
using VideoConference.Application.Features.Commands.Auth.Register;
using VideoConference.Application.Features.Commands.Auth.Revoke;
using VideoConference.Application.Features.Commands.Auth.RevokeAll;

namespace Conference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            RegisterCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            RefreshTokenCommandResponse response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPut("revoke")]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            await _mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
