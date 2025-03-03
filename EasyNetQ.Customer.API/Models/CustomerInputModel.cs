namespace EasyNetQ.Customers.API.Models
{
    public class CustomerInputModel
    {
        public CustomerInputModel(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
