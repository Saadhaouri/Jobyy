using AutoMapper;
using Joby.Domain.Models;
using JObyy.Core.Application.Dto_s;

namespace Core.Application.Mapping
{
    public class MappingProfil : Profile
    {

        public MappingProfil()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}
