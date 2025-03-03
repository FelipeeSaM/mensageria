using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

const string EXCHANGE = "curso-rabbitmq";

var person = new Person ("Eu mesmo", "1234567", new DateTime(1993, 12, 1));


var connectionFactory = new ConnectionFactory 
{
    HostName = "localhost",
};

var connection = connectionFactory.CreateConnection("nomeDaConexao");

var channel = connection.CreateModel();

var json = JsonSerializer.Serialize(person);

var arrayBytes = Encoding.UTF8.GetBytes(json);

channel.BasicPublish(EXCHANGE, "hr.routing-key", null, arrayBytes);

Console.WriteLine(json);

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
