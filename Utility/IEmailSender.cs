using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Utility
{
    public interface IEmailSender
    {
        Task sendEmailAsync(string email, string subject, string htmlMessage);
    }
}
