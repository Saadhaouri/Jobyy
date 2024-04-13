using AutoMapper;
using JObyy.Core.Application.Interfaces.IRepository;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IServices;
using Joby.Domain.Models;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper; 

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public IEnumerable<CommentDto> GetComments()
    {
        var comments = _commentRepository.GetComments();
        return _mapper.Map<IEnumerable<CommentDto>>(comments);
    }
    public CommentDto GetCommentById(Guid commentId)
    {
        var comment = _commentRepository.GetCommentById(commentId);
        return _mapper.Map<CommentDto>(comment);
    }
    public void AddComment(CommentDto comment)
    {
        var commentModel = _mapper.Map<Comment>(comment);
        _commentRepository.InsertComment(commentModel);
        _commentRepository.Save();
    }
    public void UpdateComment(CommentDto comment)
    {
        var commentModel = _mapper.Map<Comment>(comment);
        _commentRepository.UpdateComment(commentModel);
        _commentRepository.Save();
    }
    public void DeleteComment(Guid commentId)
    {
        _commentRepository.DeleteComment(commentId);
        _commentRepository.Save();
    }
}
