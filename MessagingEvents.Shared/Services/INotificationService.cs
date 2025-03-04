using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingEvents.Shared.Services
{
    public interface INotificationService
    {
        Task SendEmail(string email, string template, Dictionary<string, string> parameters);
        Task SendSms(string phone, string template, Dictionary<string, string> parameters);
    }
}
