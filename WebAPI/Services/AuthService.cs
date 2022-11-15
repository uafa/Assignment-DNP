using System.ComponentModel.DataAnnotations;
using Application.DAOinterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using EfcDataAccess.DAOs;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserLogic userLogic;

    public AuthService(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        SearchUserParametersDto dto = new SearchUserParametersDto(username);
        User? existingUser = await userLogic.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return await Task.FromResult(existingUser);
    }

    public async Task RegisterUser(UserCreationDto user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be empty!");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be empty!");
        }
        
        User? existingUser = await userLogic.GetByUsernameAsync(user.Username);
        
        if (existingUser != null)
        {
            throw new Exception("Username already taken!");
        }
    }
}