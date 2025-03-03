using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

const string EXCHANGE = "curso-rabbitmq";

var person = new Person ("Eu mesmo", "1234567", new DateTime(1993, 12, 1));

#region publicando
var connectionFactory = new ConnectionFactory 
{
    HostName = "localhost",
};

var connection = connectionFactory.CreateConnection();

var channel = connection.CreateModel();

var json = JsonSerializer.Serialize(person);

var arrayBytes = Encoding.UTF8.GetBytes(json);

channel.BasicPublish(EXCHANGE, "hr.routing-key", null, arrayBytes);

Console.WriteLine($"Publicando mensagem: {json}");
#endregion

#region consumindo
var consummerChannel = connection.CreateModel();
var consumer = new EventingBasicConsumer(consummerChannel);

consumer.Received += (sender, eventArgs) => {
    var contentArray = eventArgs.Body.ToArray();
    var jsonString = Encoding.UTF8.GetString(contentArray);

    var message = JsonSerializer.Deserialize<Person>(jsonString);

    Console.WriteLine($"recebendo mensagem: {jsonString}");

    consummerChannel.BasicAck(eventArgs.DeliveryTag, false);
};

#endregion

Console.ReadLine();

class Person {
    public Person(string fullName, string document, DateTime birthday) {
        FullName = fullName;
        Document = document;
        Birthday = birthday;
    }
    public string FullName { get; set; }
    public string Document { get; set; }
    public DateTime Birthday { get; set; }
}
