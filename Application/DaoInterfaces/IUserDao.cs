using Domain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<AuthenticationUser> CreateAsync(AuthenticationUser user);
    Task<AuthenticationUser?> GetByUsernameAsync(string userName);
    
}