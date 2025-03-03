using EasyNetQ;
using EasyNetQ.Customers.API.Bus;
using Newtonsoft.Json;

namespace EasyNetQ.Customers.API {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var bus = RabbitHutch.CreateBus("host=localhost");
            builder.Services.AddSingleton<IBusService, EasyNetQService>(
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
