
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joby.Domain.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } // Foreign key referencing the User who posted the comment 

        [ForeignKey(nameof(PostId))]
        public Guid PostId { get; set; }
        public string Content { get; set; } // Content of the comment
        public DateTime CreationDate { get; set; }
        public User User { get; set; }
        public Post Post { get;  set; }
    }
}
