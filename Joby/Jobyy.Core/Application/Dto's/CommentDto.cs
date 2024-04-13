namespace JObyy.Core.Application.Dto_s
{


    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }



}
