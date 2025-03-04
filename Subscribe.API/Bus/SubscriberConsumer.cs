using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Subscribe.API.Bus
{
    public class SubscriberConsumer : BackgroundService
    {
        private readonly IAdvancedBus _bus;
        private const string EXCHANGE = "nome-exchange";
        private const string QUEUE_NAME = "minha-fila";
        private const string ROUTING_KEY = "routing-key-aqui";

        public SubscriberConsumer(IBus bus)
        {
            _bus = bus.Advanced;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Declara a exchange
            var exchange = _bus.ExchangeDeclare(EXCHANGE, ExchangeType.Topic);

            // Declara a fila e faz o binding com a exchange
            var queue = _bus.QueueDeclare(QUEUE_NAME);
            _bus.Bind(exchange, queue, ROUTING_KEY);

            // Consome mensagens da fila
            _bus.Consume(queue, (body, properties, info) => {
                byte[] byteArray = body.ToArray();
                var mensagem = System.Text.Encoding.UTF8.GetString(byteArray);
                Console.WriteLine($"Mensagem: {mensagem}");
            });

            return Task.CompletedTask;
        }
    }
}
