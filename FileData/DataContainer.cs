using Domain.Models;
using Task = Domain.Models.Task;

namespace FileData;

public class DataContainer
{
    public ICollection<AuthenticationUser> Users { get; set; }
    public ICollection<Task> Tasks { get; set; }
}