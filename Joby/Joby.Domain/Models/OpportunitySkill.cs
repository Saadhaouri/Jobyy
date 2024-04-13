namespace Joby.Domain.Models
{
    public class OpportunitySkill
    {
        public string OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; }

        public string SkillId { get; set; }
        public Skill Skill { get; set; }
    }

}
