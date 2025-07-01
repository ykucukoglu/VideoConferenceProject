using Conference.WebApp.Models.Meeting;
using Conference.WebApp.Services.Interfaces;
using Newtonsoft.Json;

namespace Conference.WebApp.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly HttpClient _httpClient;

        public MeetingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public class MeetingsResponse
        //{
        //    public List<Meeting> Meetings { get; set; }
        //}

        public async Task<MeetingsResponse> GetAllMeetingsAsync()
        {
            var response = await _httpClient.GetAsync("api/meeting");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

           return  JsonConvert.DeserializeObject<MeetingsResponse>(responseString);
        }

        //public async Task<List<Meeting>> GetAllMeetingsAsync()
        //{
        //    var response = await _httpClient.GetAsync("api/meeting");
        //    response.EnsureSuccessStatusCode();

        //    var responseString = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<List<Meeting>>(responseString);
        //}

        public async Task DeleteMeetingAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/meeting/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
