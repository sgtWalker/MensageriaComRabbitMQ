
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Subscriber.Marketing.API.Entities;
using System.Text;
using System.Text.Json;

namespace Subscriber.Marketing.API.Subscribers
{
    public class CustomerCreatedSubscriber : IHostedService
    {
        private readonly IModel _channel;
        private const string QUEUE = "customer-created";

        public CustomerCreatedSubscriber()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("subscriber-customers-connection");

            _channel = connection.CreateModel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            
            consumer.Received += (sender, eventArgs) =>
            {
                var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

                var @event = JsonSerializer.Deserialize<CustomerCreated>(content);

                Console.WriteLine($"Message received: {content}");

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(queue: QUEUE, autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
