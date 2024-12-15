using Domain.DTOs;
using Task = Domain.Models.Task;

namespace Application.LogicInterfaces;

public interface ITaskLogic
{
    Task<Task> CreateAsync(TaskCreationDto dto);
    Task<IEnumerable<Task>> GetAsync(SearchTaskParametersDto dto);
}