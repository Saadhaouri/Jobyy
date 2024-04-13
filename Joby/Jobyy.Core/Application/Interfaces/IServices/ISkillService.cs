using JObyy.Core.Application.Dto_s;

namespace Joby.Core.Application.Interfaces.IServices
{
    public interface ISkillService
    {
        public IEnumerable<SkillDto> GetSkills();
        public SkillDto GetSkillById(string skillId);
        public void AddSkill(SkillDto skill);
        public void UpdateSkill(SkillDto skill);
        public void DeleteSkill(string skillId);
    }
}
