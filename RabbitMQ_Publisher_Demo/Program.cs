using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ_Publisher_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");            

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "mukesh17032024",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            const string message = "Hello MG! I'm RabbitMQ publisher.";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "mukesh17032024",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {message}");

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}