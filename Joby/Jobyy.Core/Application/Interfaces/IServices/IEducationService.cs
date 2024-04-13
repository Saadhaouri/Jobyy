using JObyy.Core.Application.Dto_s;

namespace Joby.Core.Application.Interfaces.IServices
{
    public interface IEducationService
    {
        public IEnumerable<EducationDto> GetEducations();
        public EducationDto GetEducationById(string educationId);
        public void AddEducation(EducationDto education);
        public void UpdateEducation(EducationDto education);
        public void DeleteEducation(string educationId);
    }

}
