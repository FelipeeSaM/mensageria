using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingEvents.Shared.Models
{
    public class SuccessSubscriberCreated
    {
        public SuccessSubscriberCreated(string email, string template, Dictionary<string, string> parameters)
        {
            Email = email;
            Template = template;
            Parameters = parameters;
        }

        public string Email { get; set; }
        public string Template { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
