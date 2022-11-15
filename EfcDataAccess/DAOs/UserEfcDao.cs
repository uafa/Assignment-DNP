using Application.DAOinterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly Context context;
    
    public UserEfcDao(Context context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password
        };
        
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        User? existingUser =
            await context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
        return existingUser;
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        IQueryable<User> usersQuery = context.Users.AsQueryable();

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }
}