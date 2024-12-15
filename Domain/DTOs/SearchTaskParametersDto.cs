namespace Domain.DTOs;

public class SearchTaskParametersDto
{
    public int? TaskId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    public SearchTaskParametersDto(int taskId, string? title, string? body)
    {
        TaskId = taskId;
        Title = title;
        Body = body;
    }
}