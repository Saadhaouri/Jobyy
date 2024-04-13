using JObyy.Core.Application.Dto_s;

namespace Joby.Core.Application.Interfaces.IServices
{
    public interface IExperienceService
    {
        public IEnumerable<ExperienceDto> GetExperiences();
        public ExperienceDto GetExperienceById(string experienceId);
        public void AddExperience(ExperienceDto experience);
        public void UpdateExperience(ExperienceDto experience);
        public void DeleteExperience(string experienceId);
    }

}
