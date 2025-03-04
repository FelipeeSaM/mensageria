namespace EasyNetQ.Publish.API.Models
{
    public class PublishModelDto
    {
        public PublishModelDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
