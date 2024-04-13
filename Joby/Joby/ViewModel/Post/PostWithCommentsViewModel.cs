using Joby.ViewModel.Comment;
using Joby.ViewModel.React;

namespace Web1.ViewModel.Post
{
    public class PostWithCommentsViewModel
    {
        public Guid Id  { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public List<CommentToDisplayViewModel> Comments { get; set; }
        public List<ReactToDisplayViewModel> Reacts { get; set; }    
    }
}
