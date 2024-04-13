using Joby.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace JObyy.Core.Application.Interfaces.IRepository
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(string userId);
        void InsertUser(User user);
        void DeleteUser(string userId);
        public bool UpdateUser(User model);
        void Save();
    }
}
