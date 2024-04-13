using AutoMapper;
using Joby.Core.Application.Interfaces.IServices;
using JObyy.Core.Application.Dto_s;
using JObyy.Core.Application.Interfaces.IRepository;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper; // Assuming you are using AutoMapper for mapping between DTO and Model

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public IEnumerable<PostDto> GetPosts()
    {
        var posts = _postRepository.GetPosts();
        return _mapper.Map<IEnumerable<PostDto>>(posts);
    }

    public PostDto GetPostById(Guid postId)
    {
        var post = _postRepository.GetPostById(postId);
        return _mapper.Map<PostDto>(post);
    }

    public List<PostDto> GetPostsByUserId(string userId)
    {
        var postsOfUser = _postRepository.GetPostByUserId(userId);
        return _mapper.Map<List<PostDto>>(postsOfUser);

    }

    public void AddPost(PostDto post)
    {
        var postModel = _mapper.Map<Post>(post);
        // You can perform additional business logic/validation here before saving
        _postRepository.InsertPost(postModel);
        _postRepository.Save();
    }

    public void UpdatePost(PostDto post)
    {
        var postModel = _mapper.Map<Post>(post);
        // You can perform additional business logic/validation here before updating
        _postRepository.UpdatePost(postModel);
        _postRepository.Save();
    }

    public void DeletePost(Guid postId)
    {
        // You can perform additional business logic/validation here before deleting
        _postRepository.DeletePost(postId);
        _postRepository.Save();
    }

   
}

