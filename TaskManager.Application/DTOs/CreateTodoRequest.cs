using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.TaskManager.Application.DTOs;

public class CreateTodoRequest
{
    [Required(ErrorMessage ="O título não pode estar vazio")]
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime ExpirationDate { get; set; }
}
