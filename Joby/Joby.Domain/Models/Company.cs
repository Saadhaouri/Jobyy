using System.ComponentModel.DataAnnotations;

namespace Joby.Domain.Models
{
    public class Company
    {

        [Key]
        public Guid Id { get; set; }
        public string Logo { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public DateTime FoundedDate { get; set; }
        public string Location { get; set; }
        // Foreign key
        public string UserId { get; set; }
        // Navigation property
        public ICollection<User> Users { get; set; }
        // Collection navigation property for jobs
        public ICollection<Job> Jobs { get; set; }
        // Additional properties
        public string Website { get; set; }
        public CompanyContact Contact { get; set; }
        public List<Opportunity> Opportunities { get; set; }
        // Social media links
        public string LinkedInProfile { get; set; }
        public string TwitterProfile { get; set; }
        public string FacebookProfile { get; set; }
    }
}
