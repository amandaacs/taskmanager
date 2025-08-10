using System;
using TaskManager.TaskManager.Domain.Enums;

namespace TaskManager.TaskManager.Application.DTOs;

public class TodoResponse
{
public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public Status Status { get; set; }
}
