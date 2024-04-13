using Joby.Domain.Models;
using Joby.Infrastructure.Data;
using Jobyy.Core.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReactRepository : IReactRepository, IDisposable
    {
        private JobyDbContext context;

        public ReactRepository(JobyDbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<React> GetReacts()
        {
            return context.Reacts.ToList();
        }

        public React GetReactById(Guid reactId)
        {
            return context.Reacts.Find(reactId) ?? throw new InvalidOperationException(" Reaction not found ");
        }

        public void InsertReact(React react)
        {
            if (react == null)
            {
                throw new ArgumentNullException(nameof(react));
            }

            // Assign a new Guid if one is not provided
            if (react.Id == Guid.Empty)
            {
                react.Id = Guid.NewGuid();
            }

            context.Reacts.Add(react);
        }

        public void DeleteReact(Guid reactId)
        {
            React react = context.Reacts.Find(reactId) ?? throw new InvalidOperationException(" Reaction not found ");
            if (react != null)
            {
                context.Reacts.Remove(react);
            }
        }

        public void UpdateReact(React react)
        {
            if (react == null)
            {
                throw new ArgumentNullException(nameof(react));
            }

            context.Entry(react).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

    }
}
