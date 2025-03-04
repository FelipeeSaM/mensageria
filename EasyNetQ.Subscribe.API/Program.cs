using EasyNetQ.Subscribe.API.Models;
using MessagingEvents.Shared.Services;

namespace EasyNetQ.Subscribe.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var bus = RabbitHutch.CreateBus("host=localhost");
            builder.Services.AddSingleton<IBus>(bus);
            builder.Services.AddHostedService<SuccessSubscriber>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
