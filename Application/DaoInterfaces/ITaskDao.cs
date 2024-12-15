using Domain.DTOs;
using Task = Domain.Models.Task;

namespace Application.DaoInterfaces;

public interface ITaskDao
{
    Task<Task> CreateAsync(Task newTask);
    Task<IEnumerable<Task>> GetAsync(SearchTaskParametersDto dto);
    
}