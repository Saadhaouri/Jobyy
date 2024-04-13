

namespace JObyy.Core.Application.Dto_s
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileImage { get; set; }
        public string ResumeUrl { get; set; }
        public UserContactDto Contact { get; set; }
        public List<EducationDto> Educations { get; set; }
        public List<ExperienceDto> Experiences { get; set; }
        public List<CommentDto> Comments { get; set; }

        public List<SkillDto> Skills { get; set; }
    }

}
