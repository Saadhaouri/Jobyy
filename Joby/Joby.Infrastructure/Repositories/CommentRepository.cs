using Joby.Domain.Models;
using Joby.Infrastructure.Data;
using JObyy.Core.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository, IDisposable
    {
        private JobyDbContext context;

        public CommentRepository(JobyDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.ToList();
        }

        public Comment GetCommentById(Guid commentId)
        {
            return context.Comments.Find(commentId);
        }

        public void InsertComment(Comment comment)
        {
            // Assign a new string if one is not provided


            context.Comments.Add(comment);
        }

        public void DeleteComment(Guid commentId)
        {
            Comment comment = context.Comments.Find(commentId);
            if (comment != null)
            {
                context.Comments.Remove(comment);
            }
        }

        public void UpdateComment(Comment comment)
        {
            context.Entry(comment).State = EntityState.Modified;
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
    }

}
