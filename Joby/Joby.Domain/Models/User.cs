using Microsoft.AspNetCore.Identity;


namespace Joby.Domain.Models;

public class User : IdentityUser
{
    //[Key] 

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ProfileImage { get; set; }
    public string ResumeUrl { get; set; }
    public UserContact Contact { get; set; }
    public List<Education> Educations { get; set; }
    public List<Experience> Experiences { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
    public ICollection<Company> Companies { get; set; }
    public ICollection<Job> Jobs { get; set; }
    public ICollection<Skill> Skills { get; set; }

}
