using EasyNetQ;
using EasyNetQ.Console;
using Newtonsoft.Json;

const string EXCHANGE = "curso-rabbitmq";
const string QUEUE = "person-created";
const string ROUTING_KEY = "hr.person-created";

var person = new Person("Eu mesmo", "1234567", new DateTime(1992, 12, 1));

// Criando canal
var bus = RabbitHutch.CreateBus("host=localhost");

#region mais rapido
//// Publicando mensagem
//await bus.PubSub.PublishAsync(person);

//// Consumindo mensagem
//await bus.PubSub.SubscribeAsync<Person>("marketing", msg => 
//    {
//    var json = JsonConvert.SerializeObject(msg);
//    Console.WriteLine(json);
//    }
//);
#endregion


// Tendo maior controle
var advanced = bus.Advanced;

// publicando
var exchange = advanced.ExchangeDeclare(EXCHANGE, "topic");
var queue = advanced.QueueDeclare(QUEUE);

advanced.Publish(exchange, ROUTING_KEY, true, new Message<Person>(person));

// consumindo
advanced.Consume<Person>(queue, (msg, info) => {
    var json = JsonConvert.SerializeObject(msg.Body);
    Console.WriteLine("dsadsa");
    Console.WriteLine(json);
});

Console.ReadLine();