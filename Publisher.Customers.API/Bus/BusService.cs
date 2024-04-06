
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Publisher.Customers.API.Bus
{
    public class BusService : IBusService
    {
        private const string EXCHANGE = "publisher-customers";
        private const string QUEUE = "customer-created";
        private readonly IModel _channel;

        public BusService()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            var connection = connectionFactory.CreateConnection("publisher-customers-connection");

            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(exchange: EXCHANGE, type: "topic", durable: false, autoDelete: false);
            _channel.QueueDeclare(queue: QUEUE, durable: false, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue: QUEUE, exchange: EXCHANGE, routingKey: QUEUE);
        }

        public Task Publish<T>(string routingKey, T message)
        {
            var byteArray = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            _channel.BasicPublish(exchange: EXCHANGE, routingKey: routingKey, basicProperties: null, body: byteArray);

            return Task.CompletedTask;
        }
    }
}
