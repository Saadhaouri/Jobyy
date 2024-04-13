using AutoMapper;
using Joby.ViewModel.Comment;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            var commentsDto = _commentService.GetComments();
            var commentsViewModel = _mapper.Map<IEnumerable<CommentViewModel>>(commentsDto);
            return Ok(commentsViewModel);
        }

        [HttpGet("{commentId}")]
        public IActionResult GetCommentById(Guid commentId)
        {
            var commentDto = _commentService.GetCommentById(commentId);

            if (commentDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            var commentViewModel = _mapper.Map<CommentViewModel>(commentDto);
            return Ok(commentViewModel);
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] CommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
                var commentDto = _mapper.Map<CommentDto>(commentViewModel);
                _commentService.AddComment(commentDto);

                // Assuming _commentService.AddComment sets the CommentId property in the DTO

                // Return the newly created comment view model with a 201 Created status
                return Ok();
           
        
            
        }

        [HttpPut("{commentId}")]
        public IActionResult UpdateComment(Guid Id, [FromBody] CommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCommentDto = _commentService.GetCommentById(Id);

            if (existingCommentDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _mapper.Map(commentViewModel, existingCommentDto);
            _commentService.UpdateComment(existingCommentDto);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteComment(Guid Id)
        {
            var existingCommentDto = _commentService.GetCommentById(Id);

            if (existingCommentDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _commentService.DeleteComment(Id);

            return NoContent();
        }
    }
}
