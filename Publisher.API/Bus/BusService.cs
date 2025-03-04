using EasyNetQ;
using EasyNetQ.Topology;

namespace Publisher.API.Bus
{
    public class BusService : IBusService
    {
        private readonly IAdvancedBus _bus;
        private const string EXCHANGE = "nome-exchange";

        public BusService(IBus bus)
        {
            _bus = bus.Advanced;
        }

        public void Publish<T>(string routingKey, T message)
        {
            var exchange = _bus.ExchangeDeclare(EXCHANGE, ExchangeType.Topic);
            _bus.Publish(exchange, routingKey, true, new Message<T>(message));
        }
    }
}
