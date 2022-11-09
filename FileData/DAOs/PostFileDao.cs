using Application.DAOinterfaces;
using Domain;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(a => a.PostId);
            postId++;
        }

        post.PostId = postId;
        post.TimeStamp = DateTime.Now;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(t =>
            t.PostId == id
        );
        return Task.FromResult(existing);
    }

    public Task DeleteAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(p => p.PostId == id);
        if (existing == null)
        {
            throw new Exception($"Post with id {id} does not exist!");
        }

        context.Posts.Remove(existing);
        context.SaveChanges();

        return Task.CompletedTask;
    }
    
    public Task<IEnumerable<Post>> GetAsync(int id)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        
        if (id != 0)
        {
            posts = posts.Where(post =>
                post.PostId == id);
        }
        return Task.FromResult(posts);
    }
}