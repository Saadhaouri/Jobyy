namespace Joby.Domain.Models
{
    public class React
    {
        public Guid Id { get; set; }

        // Type of react, you can replace string with an enum or another suitable type
        public string TypeOfReact { get; set; }

        // Relationship with Post
        public Guid PostId { get; set; }
        public Post Post { get; set; }

        // Relationship with User
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
