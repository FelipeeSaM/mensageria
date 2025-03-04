
using MessagingEvents.Shared.Models;
using MessagingEvents.Shared.Services;
using Newtonsoft.Json;

namespace EasyNetQ.Subscribe.API.Models
{
    public class SuccessSubscriber : IHostedService
    {
        const string SUBSCRIBE_CREATED_QUEUE = "customer-created";
        private readonly IAdvancedBus _bus;
        public IServiceProvider Services { get; }

        public SuccessSubscriber(IServiceProvider services, IBus bus)
        {
            Services = services;
            _bus = bus.Advanced;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var queue = _bus.QueueDeclare(SUBSCRIBE_CREATED_QUEUE);
            _bus.Consume<SuccessSubscriberCreated>(queue, async (msg, info) => {
                var json = JsonConvert.SerializeObject(msg.Body);
                await SendEmail(msg.Body);
                Console.WriteLine($"Mensagem recebida: {json}");
            });
        }

        private async Task SendEmail(SuccessSubscriberCreated body)
        {
            using (var scope = Services.CreateScope()) {
                var service = scope.ServiceProvider.GetRequiredService<INotificationService>();
                await service.SendEmail(body.Email, SUBSCRIBE_CREATED_QUEUE, new Dictionary<string, string> { {"name", body.Email} });
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
