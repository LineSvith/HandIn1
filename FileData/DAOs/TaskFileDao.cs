using Application.DaoInterfaces;
using Domain.DTOs;
using Task = Domain.Models.Task;

namespace FileData.DAOs;

public class TaskFileDao : ITaskDao
{
    private readonly FileContext context;

    public TaskFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Task> CreateAsync(Task newTask)
    {
        int taskId = 1;
        if (context.Tasks.Any())
        {
            taskId = context.Tasks.Max(t => t.TaskId);
            taskId++;
        }

        newTask.TaskId = taskId;

        context.Tasks.Add(newTask);
        context.SaveChanges();

        return System.Threading.Tasks.Task.FromResult(newTask);
    }

    public Task<IEnumerable<Task>> GetAsync(SearchTaskParametersDto dto)
    {
        IEnumerable<Task> result = context.Tasks.AsEnumerable();

        if (!string.IsNullOrEmpty(dto.Title))
        {
            result = context.Tasks.Where(post => post.Title == dto.Title);
        }

        if (!string.IsNullOrEmpty(dto.Body))
        {
            result = context.Tasks.Where(post => post.body == dto.Body);
        }

        if (dto.TaskId != null)
        {
            result = result.Where(r => r.TaskId == dto.TaskId);
        }

        return System.Threading.Tasks.Task.FromResult(result);
    }
}