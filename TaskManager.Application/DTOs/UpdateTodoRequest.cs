using System;
using System.ComponentModel.DataAnnotations;
using TaskManager.TaskManager.Domain.Enums;

namespace TaskManager.TaskManager.Application.DTOs;

public class UpdateTodoRequest
{
    [Required(ErrorMessage = "O título não pode estar vazio")]
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime ExpirationDate { get; set; }
    [Required(ErrorMessage = "O status é obrigatório")]
    public Status Status { get; set; }
}
