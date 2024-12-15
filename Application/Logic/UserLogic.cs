using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{ 
    private readonly IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        this._userDao = userDao;
    }

    public async Task<AuthenticationUser> CreateAsync(UserCreationDto dto)
    {
        AuthenticationUser? existing = await _userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateUserName(dto);
        AuthenticationUser toCreate = new AuthenticationUser()
        {
            Username = dto.UserName,
            Domain = dto.Domain,
            Email = dto.Email,
            Name = dto.Name,
            Password = dto.PassWord,
            Role = dto.Role,
            SecurityLevel = dto.SecurityLevel
        };
        
        AuthenticationUser created = await _userDao.CreateAsync(toCreate);
        
        return created;
    }

    public async Task<AuthenticationUser> ValidateLogin(AuthUserLoginDto dto)
    {
        AuthenticationUser? existing = await _userDao.GetByUsernameAsync(dto.Username);
        if (existing == null)
            throw new Exception("User does not exist!");

        if (dto.Password != existing.Password)
        {
            throw new Exception("Wrong password");
        }
        
        return existing;

    }

    private void ValidateUserName(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}