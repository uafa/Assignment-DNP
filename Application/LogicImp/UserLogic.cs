using Application.DAOinterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.LogicImp;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;
    
    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDto dto)
    {

        User? existing = await userDao.GetByUsernameAsync(dto.Username);   
        Console.WriteLine(existing);
        if (existing != null)
        {
            throw new Exception("Username already taken!");
        }

        ValidateData(dto);

        User created = await userDao.CreateAsync(dto);

        return created;
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return userDao.GetByUsernameAsync(username);
    }

    public Task<IEnumerable<User>> GetAsync()
    {
        return userDao.GetAsync();
    }

    private void ValidateData(UserCreationDto dto)
    {
        string userName = dto.Username;

        //Username
        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");

        //Password
        string password = dto.Password;

        if (password.Length < 8)
            throw new Exception("Password must be more than 8 characters!");
        
        //Email
        string email = dto.Email;

        if (!email.Contains('@') || !email.Contains('.'))
            throw new Exception("Email is invalid!");

    }
}