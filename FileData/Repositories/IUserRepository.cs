using Domain;
using Domain.DTOs;

namespace FileData.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
    User GetUser(string username);

    Task AddUser(UserCreationDto user);
}