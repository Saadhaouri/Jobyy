using Joby.Infrastructure.Data;
using JObyy.Core.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private JobyDbContext context;

        public PostRepository(JobyDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Post> GetPosts()
        {
            return context.Posts.Include(e => e.Comments).Include(e => e.Reacts).ToList();

        }

        public Post GetPostById(Guid postId)
        {
            return context.Posts.Include(e => e.Comments).Include(v => v.Reacts).FirstOrDefault(t => t.Id == postId) ?? throw new InvalidOperationException();
        }

        public void InsertPost(Post post)
        {
            // Assign a new string if one is not provided
            if (post.Id == Guid.Empty)
            {
                post.Id = Guid.NewGuid();
            }

            context.Posts.Add(post);
        }

        public void DeletePost(Guid postId)
        {
            Post post = context.Posts.Find(postId);
            if (post != null)
            {
                context.Posts.Remove(post);
            }
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        public List<Post> GetPostByUserId(string userId)
        {

            return context.Posts
                         .Include(e => e.Comments)
                         .Include(e => e.Reacts)
                         .Where(p => p.UserId == userId)
                         .ToList();
        }
    }

}
