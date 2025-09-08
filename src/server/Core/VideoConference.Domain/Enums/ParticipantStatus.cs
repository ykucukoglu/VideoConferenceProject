using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConference.Domain.Enums
{
    public enum ParticipantStatus : byte
    {
        Pending = 0,        // Davet gönderildi
        Approved = 1,       // Organizator onayladı
        Declined = 2,       // Organizator reddetti
        Joined = 3,         // Katıldı
        Left = 4           // Çıktı
    }
}
