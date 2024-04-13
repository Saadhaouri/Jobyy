using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using Joby.Domain.Models;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IRepository;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;


    private readonly IMapper _mapper; // Assuming you are using AutoMapper for mapping between DTO and Model

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;


        _mapper = mapper;
    }

    public IEnumerable<UserDto> GetUsers()
    {
        var users = _userRepository.GetUsers();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public UserDto GetUserById(string userId)
    {
        var user = _userRepository.GetUserById(userId);
        return _mapper.Map<UserDto>(user);
    }

    public void AddUser(UserDto user)
    {
      
        // Insert the user
        var userModel = _mapper.Map<User>(user);
        _userRepository.InsertUser(userModel);
        _userRepository.Save();


    }


    public void UpdateUser(string userId, UserDto userDto)
    {
        var user = _userRepository.GetUserById(userId) ?? throw new InvalidOperationException();

        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Biography = userDto.Biography;
        user.DateOfBirth = userDto.DateOfBirth;
        user.ProfileImage = userDto.ProfileImage;
        user.ResumeUrl = userDto.ResumeUrl;

        // Check if Contact property is null, if yes, create a new instance

        user.Contact = new UserContact
        {
            City = userDto.Contact?.City,
            Country = userDto.Contact?.Country,
            Email = userDto.Contact?.Email,
            Phone = userDto.Contact?.Phone,
        };

        user.Educations  = _mapper.Map<List<Education>>(userDto.Educations);
        user.Experiences = _mapper.Map<List<Experience>>(userDto.Experiences);
        user.Skills      = _mapper.Map<List<Skill>>(userDto.Skills);

        //_userRepository.UpdateUser(userModel);
       _userRepository.Save();
    }

    public void DeleteUser(string userId)
    {
        // You can perform additional business logic/validation here before deleting
        _userRepository.DeleteUser(userId);
        _userRepository.Save();
    }
}
