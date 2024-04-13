using Microsoft.AspNetCore.Identity;

namespace Joby.Domain.Models
{
    public class UserSkill
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string SkillId { get; set; }
        public Skill Skill { get; set; }
    }

}
