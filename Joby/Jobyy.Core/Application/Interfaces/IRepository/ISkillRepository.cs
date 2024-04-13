using Joby.Domain.Models;

namespace JObyy.Core.Application.Interfaces.IRepository
{
    public interface ISkillRepository : IDisposable
    {
        IEnumerable<Skill> GetSkills();
        Skill GetSkillById(string skillId);
        void InsertSkill(Skill skill);
        void DeleteSkill(string skillId);
        void UpdateSkill(Skill skill);
        void Save();
    }
}
