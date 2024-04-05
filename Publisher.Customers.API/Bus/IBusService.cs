namespace Publisher.Customers.API.Bus
{
    public interface IBusService
    {
        Task Publish<T>(string routingKey, T message);
    }
}
