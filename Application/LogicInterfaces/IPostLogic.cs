using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<Post>> GetAsync(int id);
}