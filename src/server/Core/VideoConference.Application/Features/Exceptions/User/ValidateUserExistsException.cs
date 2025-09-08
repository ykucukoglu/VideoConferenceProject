using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoConference.Application.Bases;

namespace VideoConference.Application.Features.Exceptions.User
{
    public class ValidateUserExistsException : BaseException
    {
        public ValidateUserExistsException() : base("Kullanıcı bulunamadı!") { }
    }
}
