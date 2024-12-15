using Application.LogicInterfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task = Domain.Models.Task;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{

    private readonly ITaskLogic taskLogic;

    public TasksController(ITaskLogic taskLogic)
    {
        this.taskLogic = taskLogic;
    }

    [HttpPost]
    [Route("createTask"),Authorize]
    public async Task<ActionResult<Task>> CreateAsync([FromBody]TaskCreationDto dto)
    {
        try
        {
            Task created = await taskLogic.CreateAsync(dto);
            return Created($"/tasks/{created.TaskId}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Task>>> GetAsync([FromQuery] int taskId, [FromQuery] string? title, [FromQuery] string? body)
    {
        try
        {
            SearchTaskParametersDto parameters = new(taskId, title, body);
            var tasks = await taskLogic.GetAsync(parameters);
            return Ok(tasks);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}