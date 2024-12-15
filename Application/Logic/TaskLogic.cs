using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Task = Domain.Models.Task;

namespace Application.Logic;

public class TaskLogic : ITaskLogic
{
    private readonly ITaskDao _taskDao;
    private readonly IUserDao _userDao;

    public TaskLogic(ITaskDao taskDao, IUserDao userDao)
    {
        this._taskDao = taskDao;
        this._userDao = userDao;
    }

    public async Task<Task> CreateAsync(TaskCreationDto dto)
    {
        AuthenticationUser? ownerUsername = await _userDao.GetByUsernameAsync(dto.TaskId);
        if (ownerUsername == null)
            throw new Exception("You need to Login first!");

        Task toCreate = new Task
        {
            Owner = ownerUsername,
            body = dto.Body,
            Title = dto.Title
        };

        Task created = await _taskDao.CreateAsync(toCreate);

        return created;
    }
    public Task<IEnumerable<Task>> GetAsync(SearchTaskParametersDto searchParameters)
    {
        return _taskDao.GetAsync(searchParameters);
    }
}