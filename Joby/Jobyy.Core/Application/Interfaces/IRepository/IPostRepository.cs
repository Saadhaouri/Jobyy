namespace JObyy.Core.Application.Interfaces.IRepository
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<Post> GetPosts();
        Post GetPostById(Guid postId);
        List<Post> GetPostByUserId(string userId);
        void InsertPost(Post post);
        void DeletePost(Guid postId);
        void UpdatePost(Post post);
        void Save();
    }
}
