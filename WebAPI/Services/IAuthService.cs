using Domain;
using Domain.DTOs;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(UserCreationDto user);
}