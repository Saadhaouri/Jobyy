

using JObyy.Core.Application.Dto_s;

namespace JObyy.Core.Application.Interfaces.IServices
{
    public interface ICommentService
    {
        public IEnumerable<CommentDto> GetComments();
        public CommentDto GetCommentById(Guid commentId);
        public void AddComment(CommentDto comment);
        public void UpdateComment(CommentDto comment);
        public void DeleteComment(Guid commentId);
        
    }
}

