using Joby.Domain.Models;

namespace JObyy.Core.Application.Interfaces.IRepository
{
    public interface ICommentRepository : IDisposable
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(Guid commentId);
        void InsertComment(Comment comment);
        void DeleteComment(Guid commentId);
        void UpdateComment(Comment comment);
        void Save();
    }
}
