namespace Domain.DTOs;

public class UserLoginDto
{
    public string userName { get; set; }
    public bool login { get; set; }

    public UserLoginDto(string userName, bool login)
    {
        this.userName = userName;
        this.login = login;
    }
}