using JObyy.Core.Application.Dto_s;

namespace Joby.Core.Application.Interfaces.IServices
{
    public interface IPostService
    {
        public IEnumerable<PostDto> GetPosts();
        public PostDto GetPostById(Guid postId);
       public List<PostDto>  GetPostsByUserId(string userId);
        public void AddPost(PostDto post);
        public void UpdatePost(PostDto post);
        public void DeletePost(Guid postId);
    }

}
