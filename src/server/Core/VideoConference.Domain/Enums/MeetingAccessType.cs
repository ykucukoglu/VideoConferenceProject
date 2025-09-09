namespace VideoConference.Domain.Enums
{
    public enum MeetingAccessType : byte
    {
        Public = 0,   // Herkes direkt katılabilir
        Private = 1,  // Onay gerektirir
        Lobby = 2     // Önce lobide bekler
    }
}
