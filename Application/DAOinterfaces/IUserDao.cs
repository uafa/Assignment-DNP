using Domain;
using Domain.DTOs;

namespace Application.DAOinterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(UserCreationDto dto);
    Task<User?> GetByUsernameAsync(string username);
    
    Task<IEnumerable<User>> GetAsync();
}