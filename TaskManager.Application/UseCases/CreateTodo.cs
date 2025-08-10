using System;
using TaskManager.TaskManager.Application.DTOs;
using TaskManager.TaskManager.Application.Interfaces;
using TaskManager.TaskManager.Domain.Entities;

namespace TaskManager.TaskManager.Application.UseCases;

public class CreateTodo
{
    private readonly ITodoRepository _todoRepository;

    public CreateTodo(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoResponse> ExecuteAsync(CreateTodoRequest request)
    {
        if (request.ExpirationDate < DateTime.UtcNow)
        {
            throw new ArgumentException("A data limite não pode ser no passado.");
        }

        var todo = new Todo
        {
            Title = request.Title,
            Description = request.Description,
            ExpirationDate = request.ExpirationDate,
            CompletedDate = null,
            Status = Domain.Enums.Status.Pendente
        };

        await _todoRepository.AddTodoAsync(todo);

        return new TodoResponse
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            ExpirationDate = todo.ExpirationDate,
            Status = todo.Status
        };
    }
}
