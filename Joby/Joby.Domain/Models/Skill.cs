namespace Joby.Domain.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property for the many-to-many relationship with UserModel
        public ICollection<UserSkill> UserSkills { get; set; }

        // Navigation property for the many-to-many relationship with OpportunityModel
        public ICollection<OpportunitySkill> OpportunitySkills { get; set; }

        // Other properties as needed
    }

}
