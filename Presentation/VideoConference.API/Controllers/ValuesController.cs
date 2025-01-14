using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoConference.Application.DTOs.Meetings;
using VideoConference.Application.Repositories.UnitOfWorks;
using VideoConference.Domain.Entities;

namespace VideoConference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ValuesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var meets = await _unitOfWork.GetReadRepository<Meeting>().GetAllAsync();
            var mapping = _mapper.Map<List<MeetingDTO>>(meets);

            return Ok(mapping);
        }
    }
}
