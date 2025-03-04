using EasyNetQ.Publish.API.Bus;

namespace EasyNetQ.Publish.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var bus = RabbitHutch.CreateBus("host=localhost");

            // Add services to the container.
            builder.Services.AddScoped<IBusService, EasyNetQService>(
                c => new EasyNetQService(bus)
            );

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
