namespace Domain.DTOs;

public class TaskCreationDto
{
    public string TaskId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public TaskCreationDto(string taskId, string title, string body)
    {
        TaskId = taskId; 
        Title = title; 
        Body = body;
    }
}