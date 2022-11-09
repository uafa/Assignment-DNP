using Domain;

namespace Application.DAOinterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);  //todo should it be PostCreationDto
    Task<Post?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task<IEnumerable<Post>> GetAsync(int id);
}