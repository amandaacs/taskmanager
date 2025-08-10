using System;
using TaskManager.TaskManager.Application.DTOs;
using TaskManager.TaskManager.Application.Interfaces;

namespace TaskManager.TaskManager.Application.UseCases;

public class ListTodos
{
    private readonly ITodoRepository _todoRepository;

    public ListTodos(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<TodoResponse>> ExecuteAsync()
    {
        var todos = await _todoRepository.GetAllTodosAsync();
        return todos.Select(todo => new TodoResponse
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            ExpirationDate = todo.ExpirationDate,
            Status = todo.Status
        });
        
    }
}
