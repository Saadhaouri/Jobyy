using System.ComponentModel.DataAnnotations;

namespace Joby.Domain.Models
{
    public class Opportunity
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<OpportunitySkill> OpportunitySkills { get; set; }

    }
}
