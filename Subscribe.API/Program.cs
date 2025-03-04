using EasyNetQ;
using Subscribe.API.Bus;
using Newtonsoft.Json;

namespace Subscribe.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var bus = RabbitHutch.CreateBus("host=localhost");
            builder.Services.AddSingleton(bus);
            builder.Services.AddHostedService<SubscriberConsumer>();
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
