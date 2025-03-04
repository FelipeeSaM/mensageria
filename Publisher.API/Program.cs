using EasyNetQ;
using Publisher.API.Bus;

namespace Publisher.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var bus = RabbitHutch.CreateBus("host=localhost");
            builder.Services.AddSingleton(bus);
            builder.Services.AddSingleton<IBusService, BusService>();

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
