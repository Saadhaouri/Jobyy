using Joby.Domain.Models;
using Joby.Infrastructure.Data;
using JObyy.Core.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private JobyDbContext context;

        public UserRepository(JobyDbContext context)
        {
            this.context = context;

        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.Include(u => u.Educations).
                Include(u => u.Experiences).Include(e => e.Skills).ToList();
        }
          
        public User GetUserById(string userId)
        {
            return context.Users.Include(e => e.Experiences).Include(i => i.Educations).Include(e => e.Skills).FirstOrDefault(e => e.Id == userId) ?? throw new InvalidOperationException("  User not found");

        }


        public void InsertUser(User user)
        {
            // Assign a new string if one is not provided
           

            context.Users.Add(user);
        }

        public void DeleteUser(string userId)
        {
            User user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
            }
        }

      

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool UpdateUser(User model)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == model.Id);

         if (user != null)
            {
                return false ;
            }

            context.Users.Update(model);
            context.SaveChanges();

            return true;
        }
    }

}
