namespace EasyNetQ.Publish.API.Models
{
    public class PublishModel
    {
        public PublishModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
