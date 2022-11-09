using System.ComponentModel.DataAnnotations;
using Domain;
using Domain.DTOs;
using FileData.Repositories;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> ValidateUser(string username, string password)
    {

        User? existingUser = _userRepository.GetUser(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(UserCreationDto user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be empty!");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be empty!");
        }
        
        User? existingUser = _userRepository.GetUser(user.Username);
        
        if (existingUser != null)
        {
            throw new Exception("Username already taken!");
        }

        return _userRepository.AddUser(user);
    }
}