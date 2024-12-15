namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int SecurityLevel { get; set; }
    
}