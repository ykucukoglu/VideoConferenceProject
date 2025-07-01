using Conference.WebApp.Models.Meeting;

namespace Conference.WebApp.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<MeetingsResponse> GetAllMeetingsAsync();
        Task DeleteMeetingAsync(string id);
    }
}
