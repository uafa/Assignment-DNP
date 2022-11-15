using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto dto);
    Task<User?> GetByUsernameAsync(string username);
    Task<IEnumerable<User>> GetAsync();
}