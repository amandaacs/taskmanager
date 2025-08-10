using System;
using TaskManager.TaskManager.Application.DTOs;
using TaskManager.TaskManager.Application.Interfaces;
using TaskManager.TaskManager.Domain.Entities;

namespace TaskManager.TaskManager.Application.UseCases;

public class UpdateTodo
{
    private readonly ITodoRepository _todoRepository;

    public UpdateTodo(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoResponse> ExecuteAsync(int id, UpdateTodoRequest request)
    {
        var todoToUpdate = await _todoRepository.GetByIdAsync(id);
        if (todoToUpdate == null)
        {
            throw new KeyNotFoundException("Tarefa não encontrada");
        }
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("O título não pode estar em branco");
        }
        if (request.ExpirationDate < DateTime.UtcNow)
        {
            throw new ArgumentException("A data limite deve estar no futuro");
        }
        todoToUpdate.Title = request.Title;
        todoToUpdate.Description = request.Description;
        todoToUpdate.ExpirationDate = request.ExpirationDate;
        todoToUpdate.Status = request.Status;


        todoToUpdate.CompletedDate = request.Status == Domain.Enums.Status.Concluida ? DateTime.UtcNow : null;

        await _todoRepository.UpdateTodoAsync(todoToUpdate);

        return new TodoResponse
        {
            Id = todoToUpdate.Id,
            Title = todoToUpdate.Title,
            Description = todoToUpdate.Description,
            ExpirationDate = todoToUpdate.ExpirationDate,
            CompletedDate = todoToUpdate.CompletedDate,
            Status = todoToUpdate.Status
        };
    }
}
