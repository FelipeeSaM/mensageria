using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingEvents.Shared.Services
{
    public class NotificationService : INotificationService
    {
        public Task SendEmail(string email, string template, Dictionary<string, string> parameters)
        {
            Console.WriteLine($"email: {email}, template: {template}, parâmetros: {parameters["nome"]}");
            return Task.CompletedTask;
        }

        public Task SendSms(string phone, string template, Dictionary<string, string> parameters)
        {
            Console.WriteLine($"numero: {phone}, template: {template}, parâmetros: {parameters["nome"]}");
            return Task.CompletedTask;
        }
    }
}
