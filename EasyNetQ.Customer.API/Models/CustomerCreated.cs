namespace EasyNetQ.Customers.API.Models
{
    public class CustomerCreated
    {
        public CustomerCreated(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
