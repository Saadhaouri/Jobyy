using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using Joby.ViewModel.Post;
using JObyy.Core.Application.Dto_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web1.ViewModel.Post;

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var postsDto = _postService.GetPosts();
            var postsViewModel = _mapper.Map<IEnumerable<PostWithCommentsViewModel>>(postsDto);
            return Ok(postsViewModel);
        }

       
        [HttpGet("userId")] 
        public IActionResult GetPostByUserId(string userId ) {
            var post = _postService.GetPostsByUserId(userId); 
            if (post == null)
            {
                return NotFound(" User Does not have a post ");
            }  
            var postsofUser = _mapper.Map<IEnumerable<PostWithCommentsViewModel>>(post);
             return Ok(postsofUser);
        
        } 
         [HttpGet("{postId}")]
        public IActionResult GetPostById(Guid postId)
        {
            var postDto = _postService.GetPostById(postId);

            if (postDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            var postViewModel = _mapper.Map<PostWithCommentsViewModel>(postDto);
            return Ok(postViewModel);
        }
     

        [HttpPost]
        public IActionResult AddPost([FromBody] PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postDto = _mapper.Map<PostDto>(postViewModel);
            _postService.AddPost(postDto);

            return Ok("Post add succfuly");
        }

        [HttpPut("{postId}")]
        public IActionResult UpdatePost(Guid postId, [FromBody] PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPostDto = _postService.GetPostById(postId);

            if (existingPostDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _mapper.Map(postViewModel, existingPostDto);
            _postService.UpdatePost(existingPostDto);

            return NoContent();
        }

        [HttpDelete("{postId}")]
        public IActionResult DeletePost(Guid postId)
        {
            var existingPostDto = _postService.GetPostById(postId);

            if (existingPostDto == null)
            {
                return NotFound(); // Or return a specific error response
            }

            _postService.DeletePost(postId);

            return NoContent();
        }
    }
}
