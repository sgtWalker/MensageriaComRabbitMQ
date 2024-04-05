namespace Publisher.Customers.API.Entities
{
    public class CustomerCreated
    {
        public CustomerCreated(int id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
