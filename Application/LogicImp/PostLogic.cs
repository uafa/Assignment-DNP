using Application.DAOinterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.LogicImp;

public class PostLogic : IPostLogic
{
    private readonly IUserDao userDao;
    private readonly IPostDao postDao;

    public PostLogic(IUserDao userDao, IPostDao postDao)
    {
        this.userDao = userDao;
        this.postDao = postDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByUsernameAsync(dto.Username);
        if (user == null)
        {
            throw new Exception($"User with the username{dto.Username} was not found!");
        }

        ValidatePost(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public async Task DeleteAsync(int id)
    {
        Post? existing = await postDao.GetByIdAsync(id);
        
        if (existing == null)
        {
            throw new Exception($"Todo with ID {id} was not found!");
        }

        await postDao.DeleteAsync(id);
    }

    public Task<IEnumerable<Post>> GetAsync(int id)
    {
        return postDao.GetAsync(id);
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new Exception("Title of the post can not be empty!");
        }
        
        if (string.IsNullOrEmpty(dto.Body))
        {
            throw new Exception("Body of the post can not be empty!");
        }
    }
}