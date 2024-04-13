using Joby.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class Post
{
    [Key]
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public string privacy { get; set; } 
    [ForeignKey("UserId")]
    public string UserId { get; set; }
    public User User { get; set; }
    public List<Comment> Comments { get; set; }
    public List<React> Reacts { get; set; }
    public string ImageUrl { get; set; }
}

