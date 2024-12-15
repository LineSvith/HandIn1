using Domain.DTOs;
using Task = Domain.Models.Task;

namespace HttpClients.ClientInterfaces;

public interface ITaskService
{
    System.Threading.Tasks.Task CreateAsync(TaskCreationDto dto);
    Task<ICollection<Task>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains);

    System.Threading.Tasks.Task UpdateAsync(TaskUpdateDto dto);

    Task<TaskBasicDto> GetByIdAsync(int id);

    System.Threading.Tasks.Task DeleteAsync(int id);

}