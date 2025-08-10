using System;
using TaskManager.TaskManager.Application.DTOs;
using TaskManager.TaskManager.Application.Interfaces;

namespace TaskManager.TaskManager.Application.UseCases;

public class FindTaskById
{
    private readonly ITodoRepository _todoRepository;
    public FindTaskById(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoResponse> ExecuteAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        if (todo == null)
        {
            throw new KeyNotFoundException("Tarefa não encontrada!");
        }
        return new TodoResponse
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            ExpirationDate = todo.ExpirationDate,
            Status = todo.Status,
            CompletedDate = todo.CompletedDate
        };
    }
}
