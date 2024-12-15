namespace Domain.DTOs;

public class TaskUpdateDto
{
    public int Id { get; }
    public int? OwnerId { get; set; }
    public string? Title { get; set; }
    public bool? IsCompleted { get; set; }

    public TaskUpdateDto(int id)
    {
        Id = id;
    }
}