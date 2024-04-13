using AutoMapper;
using Joby.Domain.Models;
using Joby.ViewModel;
using Joby.ViewModel.Comment;
using Joby.ViewModel.Company;
using Joby.ViewModel.Post;
using Joby.ViewModel.React;
using Joby.ViewModel.User;
using Jobyy.Core.Application.Dto_s;
using JObyy.Core.Application.Dto_s;
using Web1.ViewModel.Post;
using Web1.ViewModel.User;

namespace Core.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Model to DTO mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<ReactDto, React>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            //CreateMap<Post, PostWithCommentDto>().ReverseMap();
            CreateMap<UserContact, UserContactDto>().ReverseMap();
            CreateMap<CompanyContact, CompanyContactDto>().ReverseMap();
            CreateMap<Opportunity, OpportunityDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<SignUpUser, SignUpUserDto>().ReverseMap();
            CreateMap<SignInUser, SignInUserDto>().ReverseMap();

            // DTO to ViewModel mappings
            CreateMap<UserDto, UserViewModel>().ReverseMap();
            CreateMap<UserContactDto, UserContactViewModel>().ReverseMap();
            CreateMap<EducationDto, EducationViewModel>().ReverseMap();
            CreateMap<ExperienceDto, ExperienceViewModel>().ReverseMap();
            CreateMap<CompanyDto, CompanyViewModel>().ReverseMap();
            CreateMap<PostDto, PostWithCommentsViewModel>().ReverseMap();
            CreateMap<JobDto, JobViewModel>().ReverseMap();
            CreateMap<CommentDto, CommentViewModel>().ReverseMap(); 
            CreateMap<ReactDto, ReactViewModel>().ReverseMap();
            CreateMap<ReactDto, ReactToDisplayViewModel>().ReverseMap();
            CreateMap<CommentDto, CommentToDisplayViewModel>().ReverseMap();
            CreateMap<CompanyContactDto, CompanyContactViewModel>().ReverseMap();
            CreateMap<PostDto, PostViewModel>().ReverseMap();
            CreateMap<OpportunityDto, OpportunityViewModel>().ReverseMap();
            CreateMap<OpportunityDto, OpportunityDisplayViiewModel>().ReverseMap();
            CreateMap<SkillDto, SkillViewModel>().ReverseMap();
            CreateMap<SignUpUserDto , RegisterViewModel>().ReverseMap();
            CreateMap<SignUpUserDto, SignInViewModel>().ReverseMap();

        }
    }
}
