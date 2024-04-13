using Jobyy.Core.Application.Dto_s;

namespace JObyy.Core.Application.Dto_s
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string privacy { get; set; }
        public List<CommentDto> Comments { get; set; } 
        public List<ReactDto>  Reacts { get; set; } 
        public string ImageUrl { get; set; }
    }
}
