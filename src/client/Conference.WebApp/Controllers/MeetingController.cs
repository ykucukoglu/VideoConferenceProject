using Conference.WebApp.Services;
using Conference.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conference.WebApp.Controllers
{

    public class MeetingController : Controller
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public async Task<IActionResult> Index()
        {
            var meetings = await _meetingService.GetAllMeetingsAsync();
            return View(meetings);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _meetingService.DeleteMeetingAsync(id);
            return RedirectToAction("Index");
        }
    }
}
