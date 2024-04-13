using Jobyy.Core.Application.Dto_s;

namespace JObyy.Core.Application.Dto_s
{
    public class PostWithCommentDto
    { 

        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public List<CommentDto> Comments { get; set; } 
         public List<ReactDto> Reacts { get; set; }
    }
}
