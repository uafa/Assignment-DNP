using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FileContext fileContext;
    private readonly IUserLogic userLogic;

    public UserRepository(FileContext fileContext, IUserLogic userLogic)
    {
        this.fileContext = fileContext;
        this.userLogic = userLogic;
    }

    public IEnumerable<User> GetUsers()
    {
        return fileContext.Users;
    }

    public User GetUser(string username)
    {
        User? user = fileContext.Users.FirstOrDefault(u => u.Username.Equals(username));
        return user;
    }

    public Task AddUser(UserCreationDto user)
    {
        return userLogic.CreateAsync(user);
    }
}