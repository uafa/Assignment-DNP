using Application.DAOinterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly Context context;

    public PostEfcDao(Context context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        var existing = context.Posts
            .Include(post => post.User)
            .Where(todo => todo.PostId == id);

       Post? post = existing.First();
       return post;
    }

    public Task DeleteAsync(int id)
    {
        context.Remove(context.Posts.FindAsync(id));
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        IQueryable<Post> query = context.Posts.Include(post => post.User).AsQueryable();
        IEnumerable<Post> posts = await query.ToListAsync();
        
        return posts;
    }
}