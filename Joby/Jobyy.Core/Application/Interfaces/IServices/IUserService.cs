using JObyy.Core.Application.Dto_s;

namespace Joby.Core.Application.Interfaces.IServices
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUserById(string userId);
        void AddUser(UserDto user);
        
        void DeleteUser(string userId);
        void UpdateUser(string userId, UserDto userDto);
    }

}
