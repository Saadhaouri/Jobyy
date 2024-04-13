using Joby.ViewModel;
using Joby.ViewModel.User;
using JObyy.Core.Application.Dto_s;

namespace Web1.ViewModel.User
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileImage { get; set; }
        public string ResumeUrl { get; set; }
        public UserContactViewModel Contact { get; set; }
        public List<EducationViewModel> Educations { get; set; }
        public List<ExperienceViewModel> Experiences { get; set; }
        public List<SkillViewModel > Skills { get; set; }

    }
}
