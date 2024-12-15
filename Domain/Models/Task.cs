using System.Security.Claims;

namespace Domain.Models;

public class Task
{
    public int TaskId { get; set; }
    public AuthenticationUser Owner { get; set; }
    public string Title { get; set; }
    
    public string body { get; set; } 

}

    