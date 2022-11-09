using Domain;
using Domain.DTOs;

namespace Application.DAOinterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    
    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
}